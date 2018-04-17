using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace AdminisReport
{
    public partial class AdminisService : ServiceBase
    {
        public AdminisService() => InitializeComponent();
        private Timer iTimer;

        protected override void OnStart(string[] args)
        {
            iTimer = new System.Timers.Timer();
            int iTempoDecorrido = 1;
            iTempoDecorrido = iTempoDecorrido * 60000;
            iTimer.AutoReset = true;
            iTimer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            iTimer.Interval = iTempoDecorrido;
            iTimer.Start();
        }

        protected override void OnStop()
        {
        }


        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            iTimer.Stop();
            var text = "Run at" + DateTime.Now.ToLongDateString();
            try
            {
                string name = DateTime.Now.ToString(format: "yyyy-mmm-dd_HHMMSS");
                System.IO.File.WriteAllText(@"C:\temp\" + name+".txt", text);
            }
            catch (Exception ex)
            {
                //COLOCAR O TRATAMENTO DE ERROS AQUI
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            iTimer.Start();
        }

    }
}
