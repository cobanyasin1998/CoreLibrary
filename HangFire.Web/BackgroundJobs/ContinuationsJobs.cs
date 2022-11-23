using System.Diagnostics;

namespace HangFire.Web.BackgroundJobs
{
    public static class ContinuationsJobs
    {

        public static void WriteWaterMarkStatusJob(string id, string fileName)
        {

            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine("ContinuationsJobs tetiklendi"));
        }

    }
}
