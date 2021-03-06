﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PloteusTR.Client.Models
{
    [DataContract(Namespace = "ploteus-tr/job-result")]
    public class JobResult
    {
        [DataMember]
        public EnmUploadContentStatus? Status { get; set; }

        [DataMember]
        public EnmUploadContentObjectTypes? ObjectType { get; set; }

        [DataMember]
        public ValidationError Error { get; set; }

        [DataMember]
        public bool IsSuccess { get; set; }
    }
}
