using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class GetAvailableVolunteersByService_ResultDTO
    {
        public int VolunteerID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
