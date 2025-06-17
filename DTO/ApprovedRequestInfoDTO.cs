using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ApprovedRequestInfoDTO
    {
        public string VolunteerName { get; set; }
        public string HelpSeekerName { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestContent { get; set; }
    }
}
