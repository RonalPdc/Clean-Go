using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Clean_Go_NotificationService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        private ServiceProcessInstaller processInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

                        processInstaller.Account = ServiceAccount.LocalSystem;

                        serviceInstaller.ServiceName = "CleanGoNotificationService";
            serviceInstaller.DisplayName = "Clean&Go Notification Service";
            serviceInstaller.Description = "Servicio de notificaciones automáticas mediante Telegram y chatbot interactivo para clientes de la lavandería Clean&Go.";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

                        Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
