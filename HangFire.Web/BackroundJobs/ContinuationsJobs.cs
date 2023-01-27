using System.Diagnostics;

namespace HangFire.Web.BackroundJobs
{
    public class ContinuationsJobs
    {

        public static void WaterMarkSatatus(string id,string filename)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Status(filename));
        }

        public static void Status( string filename)
        {
            //buraya watermark attığımız resme water mark atıldı diyelim istiyoruz.
            Debug.WriteLine($"{filename} : rsime water mark eklendi.");
        }
    }
}
