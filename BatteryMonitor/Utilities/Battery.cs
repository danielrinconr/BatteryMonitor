using System;
using System.Windows.Forms;
using Microsoft.Win32;
using static BatteryMonitor.Utilities.Battery.Alerts;

namespace BatteryMonitor.Utilities
{
    public class Battery
    {
        #region Properties

        /// <summary>
        /// Object to check the Battery Status.
        /// </summary>
        private PowerStatus Status { get; } = SystemInformation.PowerStatus;


        /// <summary>
        /// Pc charging status.
        /// </summary>
        public bool IsCharging => Status.PowerLineStatus == System.Windows.Forms.PowerLineStatus.Online;

        /// <summary>
        /// Alert checked.
        /// </summary>
        public bool ChkAlert { get; private set; }

        /// <summary>
        /// Alert emitted.
        /// </summary>
        public bool AuxAlert { get; set; }

        /// <summary>
        /// Min battery level.
        /// </summary>
        public uint LowBatteryLvl { get; private set; } = 20;

        /// <summary>
        /// Max battery level.
        /// </summary>
        public uint HighBatteryLvl { get; private set; } = 80;

        /// <summary>
        /// Alert Message.
        /// </summary>
        public string Msg { get; private set; }

        /// <summary>
        /// Available alerts
        /// </summary>
        public enum Alerts
        {
            LowBattery, HighBattery, Any
        }

        public bool[] AlertStatus { get; private set; }

        /// <summary>
        /// Current alert
        /// </summary>
        public Alerts Alert { get; private set; } = Any;

        /// <summary>
        /// Previous alert.
        /// </summary>
        public Alerts PrevAlert { get; private set; } = Any;

        #endregion
        #region PowerStatusProperties

        public BatteryChargeStatus ChargeStatus => Status.BatteryChargeStatus;

        public string BatteryFullLifetime => Status.BatteryFullLifetime == -1 ? "--" : Status.BatteryFullLifetime.ToString();

        public string BatteryLifeRemaining => Status.BatteryLifeRemaining == -1 ? "--" : TimeSpan.FromSeconds(Status.BatteryLifeRemaining).ToString(@"hh\:mm");

        public float BatteryLifePercent => Status.BatteryLifePercent;

        public string PowerLineStatus => Status.PowerLineStatus == System.Windows.Forms.PowerLineStatus.Offline ? "Desconectado" : "Cargando";

        #endregion PowerStatusProperties

        public Battery()
        {
            if (AlertStatus == null)
                AlertStatus = new[] { true, true };
        }
        public Battery(bool[] enableAlert) => AlertStatus = enableAlert;

        public void ChangeAlertStatus(bool[] newAlertStatus)
        {
            if (newAlertStatus.Length != AlertStatus.Length)
                throw new Exception($"El arreglo debe tener tamaño {AlertStatus.Length}");
            AlertStatus = newAlertStatus;
        }

        #region Change Private Properties
        public void ChangeLowBatteryLvl(uint lowBatteryLvl) => LowBatteryLvl = lowBatteryLvl;

        public void ChangeHighBatteryLvl(uint highBatteryLvl) => HighBatteryLvl = highBatteryLvl;

        public void ChangePrevAlert(Alerts alert) => PrevAlert = alert;
        #endregion

        public bool CheckPowerLevel()
        {
            if (AlertStatus[(int)LowBattery])
            {
                if (!IsCharging && Status.BatteryLifePercent <= (double)LowBatteryLvl / 100)
                {
                    Msg = $@"Batería al {BatteryLifePercent:P0}. Conecte la fuente de poder.";
                    Alert = LowBattery;
                }
            }
            if (AlertStatus[(int)HighBattery])
            {
                if (IsCharging && Status.BatteryLifePercent >= (double)HighBatteryLvl / 100)
                {
                    Msg = $@"Batería al {BatteryLifePercent:P0}. Desconecte la fuente de poder.";
                    Alert = HighBattery;
                }
            }
            else
                Alert = Any;

            if (Alert == Any || PrevAlert == Alert && AuxAlert) return false;
            PrevAlert = Alert;
            AuxAlert = true;
            return true;
        }

        ///// <summary>
        ///// Check if the alert was checked.
        ///// </summary>
        //public void WaitForResp()
        //{
        //    if (!ChkAlert)
        //        AuxAlert = false;
        //}

        /// <summary>
        /// Occur when the user press BtnChecked and check if an warning message should be sent.
        /// </summary>
        /// <returns></returns>
        public bool Checked()
        {
            var alert = false;
            switch (Alert)
            {
                case HighBattery when IsCharging:
                    Msg = @"Recuerde que la vida de la batería podría verse afectada";
                    alert = true;
                    break;

                case LowBattery when !IsCharging:
                    Msg = @"No se ha detectado la conexión, puede perder información no guardada";
                    alert = true;
                    break;

                case Any:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            ChkAlert = true;
            return alert;
        }

        public void ResetAlert() => Alert = Any;

        public void AddPowerModeChanged(PowerModeChangedEventHandler powerModeChanged) => SystemEvents.PowerModeChanged += powerModeChanged;
    }
}