using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phonestar_calllog
{
    public class CallLogEntry
    {
        public int billed_duration { get; set; }
        public string description { get; set; }
        public string caller { get; set; }
        public string number { get; set; }
        public string cost { get; set; }
        public string connected { get; set; }
        public int cdr_id { get; set; }
        public string callee { get; set; }
        public string disconnected { get; set; }
    }
}
