using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;

namespace BatteryMonitor.Utilities
{
    public class Voice
    {
        private readonly SpeechSynthesizer _synth;

        /// <summary>
        /// List of available voices in the computer.
        /// </summary>
        public List<string> Voices { get; private set; }

        /// <summary>
        /// Name for identify the device that triggers the notification.
        /// </summary>
        public string PcName { get; private set; }

        /// <summary>
        /// Notifications queue.
        /// </summary>
        private Queue<string> Msgs { get; }

        /// <summary>
        /// Task for dequeue and trigger notifications.
        /// </summary>
        private Task TskSpeakMsgs { get; set; }

        /// <summary>
        /// Object to cancel the Task notifications.
        /// </summary>
        private CancellationTokenSource CancellationToken { get; set; }

        /// <summary>
        /// Action when the synth completed a notification.
        /// </summary>
        private Action SpkCompleted { get; }

        /// <summary>
        /// Object to control de computer volume.
        /// </summary>
        private CoreAudioDevice DefaultPlaybackDevice { get; set; }

        public double Volume  => DefaultPlaybackDevice.Volume;
        public string AudioDeviceName  => DefaultPlaybackDevice.FullName;

        /// <summary>
        /// Save if the volume was muted.
        /// </summary>
        private bool WasMuted { get; set; }

        /// <summary>
        /// Volume previous to trigger alert to return when the notification was ended.
        /// </summary>
        private double PrevVol { get; set; }

        /// <summary>
        /// Default notification volume.
        /// </summary>
        public uint NotVolume { get; set; } = 60;

        /// <summary>
        /// Auxiliary copy of the NotVolume to increase in each repetition.
        /// </summary>
        public uint AuxNotVolume { get; set; }

        /// <summary>
        /// To load the volume controller in an independent thread and could cancel.
        /// </summary>
        private Task TskLoadVolController { get; }

        /// <summary>
        /// Current Voice to speech notifications.
        /// </summary>
        public string CurrentVoice { get; private set; }

        //public bool IsSpeaking => _synth.State == SynthesizerState.Speaking;

        public Voice(Action speakCompleted)
        {
            try
            {
                _synth = new SpeechSynthesizer();
                GetVoices();
                // Load an spanish voice or the first.
                ChangeCurrentVoice(Voices.FirstOrDefault(x => x.Contains("Spanish")) ?? Voices[0]);
                Msgs = new Queue<string>();
                SpkCompleted = speakCompleted;
                _synth.StateChanged += SynthStateChanged;
                TskLoadVolController = Task.Run(LoadVolumeSett);
            }
            catch (Exception exc)
            {
                throw new Exception($"Error en la configuración de la voz de la aplicación:\n{exc.Message}");
            }
        }

        #region LoadMeethods
        public void GetVoices()
        {
            var installedVoices = _synth.GetInstalledVoices();

            if (installedVoices.Count == 0) throw new Exception(@"No se encontraron voces instaladas");

            if (Voices == null)
                Voices = new List<string>();

            // Output information about all of the installed voices.
            Debug.WriteLine(@"Installed voices -");

            foreach (var voice in installedVoices)
            {
                var info = voice.VoiceInfo;
                var infoDescription = info.Description;
                string auxVoice;
                if (infoDescription.StartsWith("Microsoft"))
                    auxVoice = infoDescription;
                else
                {
                    // For now it's only possible to use the Microsoft Voices.
                    //auxVoice = info.Name;
                    continue;
                }
                if (!Voices.Contains(auxVoice))
                    Voices.Add(auxVoice);

                //GetVoiceInfo(info, infoDescription, voice);
            }

            /*
                        void GetVoiceInfo(VoiceInfo info, string infoDescription, InstalledVoice voice)
                        {
                            var audioFormats = info.SupportedAudioFormats.Aggregate("", (current, fmt) => current + $"{fmt.EncodingFormat}\n");

                            Debug.WriteLine(@" Name:          " + info.Name);
                            Debug.WriteLine(@" Culture:       " + info.Culture);
                            Debug.WriteLine(@" Age:           " + info.Age);
                            Debug.WriteLine(@" Gender:        " + info.Gender);
                            Debug.WriteLine(@" Description:   " + infoDescription);
                            Debug.WriteLine(@" ID:            " + info.Id);
                            Debug.WriteLine(@" Enabled:       " + voice.Enabled);
                            Debug.WriteLine(info.SupportedAudioFormats.Count != 0
                                ? $@" Audio formats: {audioFormats}"
                                : @" No supported audio formats found");

                            Debug.WriteLine(
                                $@" Additional Info - {info.AdditionalInfo.Keys.Aggregate("", (current, key) => current + $"  {key}: {info.AdditionalInfo[key]}\n")}");
                        }
            */
        }

        public string GetMicrosoftVoiceName(string voice)
        {
            var voiceName = voice.Split('-');
            return voiceName[0].Trim();
        }

        public void ChangeCurrentVoice(string voice)
        {
            CurrentVoice = voice;
            string voiceName;
            if (voice.StartsWith("Microsoft"))
                voiceName = GetMicrosoftVoiceName(CurrentVoice);
            else throw new Exception(@"Por ahora sólo se pueden usar voces de Microsoft.");
            // eSpeak is not available for exception that cannot be caught.
            //else if (voice.StartsWith("eSpeak"))
            //    voiceName = voice;
            SelectVoice(voiceName);
        }

        private void LoadVolumeSett()
        {
            try
            {
                DefaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;
                Debug.WriteLine(DefaultPlaybackDevice.FullName);
            }
            catch (ArgumentNullException exp)
            {
                Debug.WriteLine(exp.Message);
            }
            Debug.WriteLine("Volume control Loaded");
        }
        #endregion

        public void Close()
        {
            // Before destruct the object, delete the event handler.
            _synth.StateChanged -= SynthStateChanged;
            // Clear the notification queue.
            Msgs.Clear();
        }

        public void ChangePcName(string pcName) => PcName = pcName;

        private void SelectVoice(string voiceName) => _synth.SelectVoice(voiceName);

        public void ChangeSynthVolume(int vol) => _synth.Volume = vol;

        public void ChangeNotVolume(uint vol)
        {
            NotVolume = vol;
            AuxNotVolume = NotVolume;
        }

        public async void AddMessage(string msg)
        {
            try
            {
                // Wait until the Volume Controller is loaded.
                if (TskLoadVolController.Status == TaskStatus.Running)
                    TskLoadVolController.Wait();
                Msgs.Enqueue(msg);
                if (DefaultPlaybackDevice == null)
                    throw new Exception("There is no device to play alert.");

                // ReSharper disable once AssignmentInConditionalExpression
                if (WasMuted = DefaultPlaybackDevice.IsMuted)
                    await DefaultPlaybackDevice.SetMuteAsync(false);

                PrevVol = DefaultPlaybackDevice.Volume;
                if (PrevVol <= 5) PrevVol = 5;
                await DefaultPlaybackDevice.SetVolumeAsync(AuxNotVolume);

                await SpeakMsgs();
                Debug.WriteLine($"Launching new thread with the message: {msg}");
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        private Task SpeakMsgs()
        {
            CancellationToken = new CancellationTokenSource();
            var token = CancellationToken.Token;
            TskSpeakMsgs = Task.Run(() =>
            {
                Prompt prompt = null;
                try
                {
                    if (_synth.State != SynthesizerState.Paused)
                    {
                        while (Msgs.Count > 0)
                        {
                            prompt = _synth.SpeakAsync(Msgs.Dequeue());
                            Thread.Sleep(100);
                            while (_synth.State == SynthesizerState.Speaking)
                            {
                                token.ThrowIfCancellationRequested();
                                Thread.Sleep(100);
                            }
                        }
                        SpkCompleted();
                    }
                    DefaultPlaybackDevice?.SetVolumeAsync(PrevVol, token);
                    if (WasMuted)
                        DefaultPlaybackDevice?.SetMuteAsync(true, token);
                }
                catch (Exception canceledException)
                {
                    if (prompt != null) _synth.SpeakAsyncCancel(prompt);
                    else _synth.SpeakAsyncCancelAll();
                    Debug.WriteLine("Task was cancelled");
                    Debug.WriteLine(canceledException.Message);
                }
            }, token);
            return TskSpeakMsgs;
        }

        // ReSharper disable once MemberCanBeMadeStatic.Local
        private void SynthStateChanged(object sender, StateChangedEventArgs e)
        {
        }

        public void Pause()
        {
            try
            {
                _synth.Pause();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Resume()
        {
            try
            {
                _synth.Resume();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Checked() => CancellationToken?.Cancel();
    }
}