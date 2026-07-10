using System.ServiceProcess;

namespace Clean_Go_NotificationService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBase[] servicios = new ServiceBase[] { new CleanGoService() };
            ServiceBase.Run(servicios);
        }
    }
}
