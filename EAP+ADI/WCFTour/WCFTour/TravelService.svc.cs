using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace WCFTour
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TravelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TravelService.svc or TravelService.svc.cs at the Solution Explorer and start debugging.
    public class TravelService : ITravelService
    {
        public string UploadFile(HttpPostedFileBase file)
        {
            var filename = Path.GetFileName(file.FileName);
            UploadFile(filename, file.InputStream);
            string FilePath = Path.
                Combine(HostingEnvironment.MapPath("~/Assets/Uploads"), filename);
            return FilePath;
        }
        private long CurrentTime()
        {
            var Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }
        public void UploadFile(string filename, Stream stream)
        {
            string filePath = CurrentTime() + Path.Combine(HostingEnvironment.MapPath("~/Assets/Uploads"), filename);
            int length = 0;
            using(FileStream write = new FileStream(filePath, FileMode.Create))
            {
                int readCount;
                var buffer = new byte[8129];
                while((readCount = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    write.Write(buffer, 0, readCount);
                    length += readCount;
                }
            }

        }

    }
}
