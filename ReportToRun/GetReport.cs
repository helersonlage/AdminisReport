using System.Collections.Generic;

namespace ReportToRun
{
    public class GetReport
    {

        public List<ItemReportToRun> CheckReportToRun(string logfilelocation)
        {
            return ReadCvs.ReadCvsFile(logfilelocation);
        }
                
    }
}
