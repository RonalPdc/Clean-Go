using System;
using System.ServiceProcess;

namespace Clean_Go_NotificationService
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                CleanGoService servicio = new CleanGoService();
                servicio.IniciarConsola();
                Console.WriteLine("Servicio de Notificaciones Clean&Go corriendo en modo interactivo.");
                Console.WriteLine("Presione ENTER para detener y salir...");
                Console.ReadLine();
                servicio.DetenerConsola();
            }
            else
            {
                ServiceBase[] servicios = new ServiceBase[] { new CleanGoService() };
                ServiceBase.Run(servicios);
            }
        }
    }
}
