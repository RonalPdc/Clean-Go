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

            // Definir que se ejecute bajo la cuenta de sistema local (LocalSystem)
            processInstaller.Account = ServiceAccount.LocalSystem;

            // Datos del servicio
            serviceInstaller.ServiceName = "CleanGoNotificationService";
            serviceInstaller.DisplayName = "Clean&Go Notification Service";
            serviceInstaller.Description = "Servicio de notificaciones automáticas mediante Telegram y chatbot interactivo para clientes de la lavandería Clean&Go.";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            // Añadir instaladores al proyecto
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
