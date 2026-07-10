using System;
using System.ServiceProcess;
using System.Threading;
using System.Configuration;

namespace Clean_Go_NotificationService
{
    public class CleanGoService : ServiceBase
    {
        private Thread _hiloTrabajo;
        private bool _ejecutando = false;
        private TelegramBotProcessor _processor;

        private int _intervaloNotificaciones;
        private int _intervaloChatBot;

        public CleanGoService()
        {
            ServiceName = "CleanGoNotificationService";
            CanStop = true;
            CanPauseAndContinue = false;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            _ejecutando = true;
            _processor = new TelegramBotProcessor();

            string intervaloNotifStr = ConfigurationManager.AppSettings["IntervaloNotificacionesMs"];
            string intervaloChatStr = ConfigurationManager.AppSettings["IntervaloChatBotMs"];

            if (!int.TryParse(intervaloNotifStr, out _intervaloNotificaciones))
                _intervaloNotificaciones = 10000;

            if (!int.TryParse(intervaloChatStr, out _intervaloChatBot))
                _intervaloChatBot = 5000;

            _hiloTrabajo = new Thread(EjecutarCiclo);
            _hiloTrabajo.IsBackground = true;
            _hiloTrabajo.Start();
        }

        protected override void OnStop()
        {
            _ejecutando = false;
            if (_hiloTrabajo != null && _hiloTrabajo.IsAlive)
            {
                _hiloTrabajo.Join(3000);
            }
        }

        private void EjecutarCiclo()
        {
            int contadorMs = 0;

            while (_ejecutando)
            {
                Thread.Sleep(1000);
                contadorMs += 1000;

                if (contadorMs % _intervaloNotificaciones == 0)
                {
                    try
                    {
                        _processor.ProcesarNotificacionesPendientes();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.EventLog.WriteEntry("CleanGoService", "Error notificaciones: " + ex.Message, System.Diagnostics.EventLogEntryType.Warning);
                    }
                }

                if (contadorMs % _intervaloChatBot == 0)
                {
                    try
                    {
                        _processor.ProcesarConsultasChatBot();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.EventLog.WriteEntry("CleanGoService", "Error chatbot: " + ex.Message, System.Diagnostics.EventLogEntryType.Warning);
                    }
                }

                if (contadorMs >= 3600000)
                    contadorMs = 0;
            }
        }
    }
}
