using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AssignedRequestsDTO
    {
        public int AssignmentID { get; set; }
        public Nullable<int> RequestID { get; set; }
        public Nullable<int> VolunteerID { get; set; }
    }
}
