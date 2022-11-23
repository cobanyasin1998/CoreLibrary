using System;
using System.Drawing;
using System.IO;

namespace HangFire.Web.BackgroundJobs
{
    public class DelayedJobs
    {
        public static string AddWaterMarkJob(string fileName,string waterMarkText)
        {

         return    Hangfire.BackgroundJob.Schedule(()=> ApplyWatermark(fileName, waterMarkText),
                TimeSpan.FromSeconds(1));
        }


        public static void ApplyWatermark(string fileName, string waterMarkText)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", fileName);

            using (var bitMap = Bitmap.FromFile(path))
            {
                using (Bitmap tempBitMap = new Bitmap(bitMap.Width, bitMap.Height))
                {
                    using (Graphics grp = Graphics.FromImage(tempBitMap))
                    {
                        grp.DrawImage(bitMap, 0, 0);

                        var font = new Font(FontFamily.GenericSansSerif, 25, FontStyle.Bold);
                        var color = Color.FromArgb(255, 0, 0);
                        var brush = new SolidBrush(color);
                        var point = new Point(20, bitMap.Height - 50);

                        grp.DrawString(waterMarkText, font, brush, point);

                        tempBitMap.Save(Path.Combine(Directory.GetCurrentDirectory(),
                            "wwwroot/pictures/watermark",fileName));
                    }
                }
            }




        }
    }
}
