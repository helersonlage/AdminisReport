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
using ReportToRun;

namespace AdminisReport
{
    public partial class AdminisService : ServiceBase
    {
        public AdminisService() => InitializeComponent();
        private Timer iTimer;
        private List<ItemReportToRun> itemreports = new List<ItemReportToRun>();

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
            itemreports.AddRange(new GetReport().CheckReportToRun(new ReadAppFile().Getlogfilelocation()));

            iTimer.Stop();
            var text = "Run at" + DateTime.Now.ToLongDateString();
            try
            {
                StringBuilder texto = new StringBuilder();
                texto.AppendLine(DateTime.Now.ToUniversalTime().ToString());

                foreach (var item in itemreports)
                {
                    texto.AppendLine(item.Name.ToString() + ";" + item.DayRun.ToString());
                }     

                string name = DateTime.Now.ToString(format: "yyyy-mmm-dd_HHMMSS");
                System.IO.File.WriteAllText(@"C:\temp\" + name+".txt", texto.ToString());
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
