using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PloteusTR.Client.Models
{
    [DataContract(Namespace = "ploteus-tr/upload-result")]
    public class UploadResult
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string RequestId { get; set; }

        [DataMember]
        public ValidationError Error { get; set; }
    }
}
