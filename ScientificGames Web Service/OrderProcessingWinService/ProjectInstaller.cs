namespace OrderProcessingWinService
{
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.ServiceProcess;

    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        private readonly ServiceProcessInstaller process;
        private readonly ServiceInstaller service;

        public ProjectInstaller()
        {
            //InitializeComponent();
            process = new ServiceProcessInstaller {Account = ServiceAccount.LocalSystem};
            service = new ServiceInstaller {ServiceName = "SG Order Processing Service"};

            Installers.Add(process);
            Installers.Add(service);
        }
    }
}
