using System;
using System.Windows.Forms;

namespace BatteryMonitor.Utilities
{
    public class Battery
    {
        /// <summary>
        /// Pc charging status.
        /// </summary>
        public bool IsCharging { get; private set; }

        /// <summary>
        /// Alert checked.
        /// </summary>
        public bool ChkAlert { get; private set; }

        /// <summary>
        /// Alert emmited.
        /// </summary>
        public bool AuxAlert { get; set; }

        /// <summary>
        /// Min battery level.
        /// </summary>
        public uint LowBattLevel { get; private set; } = 20;

        /// <summary>
        /// Max battery level.
        /// </summary>
        public uint HighBattLevel { get; private set; } = 80;

        /// <summary>
        /// Alert Message.
        /// </summary>
        public string Msg { get; private set; }

        /// <summary>
        /// Object to check the Battery Status.
        /// </summary>
        private PowerStatus Status { get; } = SystemInformation.PowerStatus;

        /// <summary>
        /// Available alerts
        /// </summary>
        public enum Alerts
        {
            Any, LowBattery, HighBattery
        }

        /// <summary>
        /// Current alert
        /// </summary>
        public Alerts Alert { get; private set; } = Alerts.Any;

        /// <summary>
        /// Previus alert.
        /// </summary>
        public Alerts PrevAlert { get; /*TODO: Change to private set*/set; } = Alerts.Any;

        #region PowerStatusProperties

        public BatteryChargeStatus ChargeStatus => Status.BatteryChargeStatus;

        public string BatteryFullLifetime => Status.BatteryFullLifetime == -1 ? "--" : Status.BatteryFullLifetime.ToString();
        public float BatteryLifePercent => Status.BatteryLifePercent;
        public string BatteryLifeRemaining => Status.BatteryLifeRemaining == -1 ? "--" : TimeSpan.FromSeconds(Status.BatteryLifeRemaining).ToString(@"hh\:mm");

        public string PowerLineStatus => Status.PowerLineStatus == System.Windows.Forms.PowerLineStatus.Offline ? "Desconectado" : "Cargando";

        #endregion PowerStatusProperties

        public Battery() => PowerModeChanged();

        public void ChangeLowBattLevel(uint lowBattLevel) => LowBattLevel = lowBattLevel;

        public void ChangeHighBattLevel(uint highBattLevel) => HighBattLevel = highBattLevel;

        /// <summary>
        /// Check if the pc is charging.
        /// </summary>
        public void PowerModeChanged() => IsCharging = Status.PowerLineStatus == System.Windows.Forms.PowerLineStatus.Online;

        public bool CheckPowerLevel()
        {
            if (!IsCharging && Status.BatteryLifePercent <= (double)LowBattLevel / 100)
            {
                Msg = $@"Batería al {BatteryLifePercent:P0}. Conecte la fuente de poder.";
                Alert = Alerts.LowBattery;
            }
            else if (IsCharging && Status.BatteryLifePercent >= (double)HighBattLevel / 100)
            {
                Msg = $@"Batería al {BatteryLifePercent:P0}. Desconecte la fuente de poder.";
                Alert = Alerts.HighBattery;
            }
            else
                Alert = Alerts.Any;

            if (Alert == Alerts.Any) return false;
            if (PrevAlert == Alert && AuxAlert) return false;
            PrevAlert = Alert;
            AuxAlert = true;
            return true;
        }

        /// <summary>
        /// Check if the alert was checked.
        /// </summary>
        public void WaitForResp()
        {
            if (!ChkAlert)
                AuxAlert = false;
        }

        public bool Checked()
        {
            // ReSharper disable once RedundantAssignment
            var resp = false;
            switch (Alert)
            {
                case Alerts.HighBattery when IsCharging:
                    Msg = @"Recuerde que la vida de la batería podría verse afectada";
                    break;

                case Alerts.LowBattery when !IsCharging:
                    Msg = @"No se ha detectado la conexión, puede perder información no salvada";
                    break;

                case Alerts.Any:
                    Msg = @"No había ninguna notificación";
                    break;

                default:
                    //throw new ArgumentOutOfRangeException();
                    resp = true;
                    break;
            }

            ChkAlert = true;
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            return resp;
        }
    }
}