namespace AdminisReport
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Adminis = new System.ServiceProcess.ServiceProcessInstaller();
            this.AdminisService = new System.ServiceProcess.ServiceInstaller();
            // 
            // Adminis
            // 
            this.Adminis.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.Adminis.Password = null;
            this.Adminis.Username = null;
            // 
            // AdminisService
            // 
            this.AdminisService.Description = "Adminis";
            this.AdminisService.DisplayName = "Adminis";
            this.AdminisService.ServiceName = "Adminis";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.Adminis,
            this.AdminisService});

        }

        #endregion
        public System.ServiceProcess.ServiceInstaller AdminisService;
        public System.ServiceProcess.ServiceProcessInstaller Adminis;
    }
}