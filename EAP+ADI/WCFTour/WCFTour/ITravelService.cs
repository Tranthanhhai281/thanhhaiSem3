using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace WCFTour
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITravelService" in both code and config file together.
    [ServiceContract]
    public interface ITravelService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
             RequestFormat = WebMessageFormat.Json,
             ResponseFormat = WebMessageFormat.Json,
             UriTemplate = "UploadFile")]
        string UploadFile(HttpPostedFileBase file);

    }
}
