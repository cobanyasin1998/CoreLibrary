using Hangfire;
using System.Diagnostics;

namespace HangFire.Web.BackgroundJobs
{
    public static class RecurringJobs
    {
        public static void ReportingJob()
        {
            Hangfire.RecurringJob.AddOrUpdate("reportjob1", () => EmailReport(),
                cronExpression:"0 0/1 * 1/1 * ? *");
        }

        public static void EmailReport()
        {
            Debug.WriteLine("Rapor, email olarak gönderildi");

        }
    }
}
