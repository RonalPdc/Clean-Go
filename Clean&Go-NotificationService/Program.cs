using System;
using System.Threading;
using System.Configuration;

namespace Clean_Go_NotificationService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Servicio de Notificaciones y ChatBot Clean&Go Iniciado...");
            
            TelegramBotProcessor processor = new TelegramBotProcessor();
            int notificationInterval = int.Parse(ConfigurationManager.AppSettings["IntervaloNotificacionesMs"]);
            int chatbotInterval = int.Parse(ConfigurationManager.AppSettings["IntervaloChatBotMs"]);

            int timeElapsed = 0;

            while (true)
            {
                if (timeElapsed % notificationInterval == 0)
                {
                    processor.ProcesarNotificacionesPendientes();
                }

                if (timeElapsed % chatbotInterval == 0)
                {
                    processor.ProcesarConsultasChatBot();
                }

                Thread.Sleep(1000);
                timeElapsed += 1000;
            }
        }
    }
}
