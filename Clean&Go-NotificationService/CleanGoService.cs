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
        private CancellationTokenSource _cts;

        private int _intervaloNotificaciones;

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
            _cts = new CancellationTokenSource();

            _processor.IniciarChatBot(_cts.Token);

            string intervaloNotifStr = ConfigurationManager.AppSettings["IntervaloNotificacionesMs"];

            if (!int.TryParse(intervaloNotifStr, out _intervaloNotificaciones))
                _intervaloNotificaciones = 1000;

            _hiloTrabajo = new Thread(EjecutarCiclo);
            _hiloTrabajo.IsBackground = true;
            _hiloTrabajo.Start();
        }

        protected override void OnStop()
        {
            _ejecutando = false;

            if (_cts != null)
            {
                _cts.Cancel();
            }

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

                if (contadorMs >= 3600000)
                    contadorMs = 0;
            }
        }
    }
}
