using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportToRun
{
    public class ReadCvs
    {

        internal static List<ItemReportToRun> ReadCvsFile(string logfilelocation)
        {
            var file = ReadFile(logfilelocation: logfilelocation);
            return mapping(file);
        }

        private static List<string[]> ReadFile(string logfilelocation)
        {
            var cvs = File.ReadAllLines(logfilelocation)
                         .Skip(1)
                         .Select(t => t.Split(';'))
                         .ToList();

            return cvs;
        }

        private static List<ItemReportToRun> mapping(List<string[]> cvsList)
        {
            var ReportListRun = new List<ItemReportToRun>();
            ItemReportToRun item;
            int Intparse = 0;

            foreach (var line in cvsList)
            {
                item = new ItemReportToRun();
                item.Name = line[0].Trim().ToString();
                item.DayRun = int.TryParse(line[1].Trim().ToString(), out Intparse) ? Intparse : 0;
                item.HoraRun = int.TryParse(line[2].Trim().ToString(), out Intparse) ? Intparse : 0;
                item.Parameter = string.IsNullOrEmpty(line[2].Trim().ToString()) ? line[2].Trim().ToString() : string.Empty;
                ReportListRun.Add(item);
            }

            return ReportListRun;
        }

       
    }
}
