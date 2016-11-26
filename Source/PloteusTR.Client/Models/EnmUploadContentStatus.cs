using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PloteusTR.Client.Models
{
    public enum EnmUploadContentStatus : short
    {
        InQueue = 1,
        InProcess = 2,
        Cancelled = 3,
        Delivered = 4
    }
}
