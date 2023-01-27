using Hangfire;
using System.Diagnostics;

namespace HangFire.Web.BackroundJobs
{
    public class ReccurinJobs
    {
        public static void ReportingJobs()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob1", () => EmailReport(), Cron.Minutely);
        }
        public static void EmailReport()
        {
            //buraya email olarak göndermek istediğiniz verileri vs ne dilerseniz onu yazabilirisniz.
            Debug.WriteLine("Rapor email olarak gönderildi.");
        }
    }
}
