using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RequestDTO
    {
        public int RequestID { get; set; }
        public Nullable<int> SeekerID { get; set; }
        public string RequestContent { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public Nullable<int> Hours { get; set; }
    }
}
