using System.Configuration;

namespace AdminisReport
{
    internal class ReadAppFile
    {
        public ReadAppFile()
        {
        }

        public string Getlogfilelocation()
        {
            string logfilelocation = ConfigurationManager.AppSettings["logfilelocation"];
            return logfilelocation;
        }
    }
}
