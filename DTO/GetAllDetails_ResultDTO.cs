using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GetAllDetails_ResultDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string RequestContent { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ServiceName { get; set; }
    }
}
