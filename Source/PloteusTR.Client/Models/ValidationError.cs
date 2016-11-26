using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PloteusTR.Client.Models
{
    [DataContract(Namespace = "ploteus-tr/validation-error")]
    public class ValidationError
    {
        [DataMember]
        public EnmValidationErrorType Type { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
