using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public static class AssignedRequestsConverter
    {
        public static AssignedRequestsDTO ToAssignedRequestsDTO(AssignedRequests v)
        {
            AssignedRequestsDTO dTO = new AssignedRequestsDTO()
            {
               AssignmentID = v.AssignmentID,
               RequestID = v.RequestID,
               VolunteerID=v.VolunteerID
               
            };
            return dTO;

        }
        public static List<AssignedRequestsDTO> ToAssignedRequestsDTO(List<AssignedRequests> v)
        {
            return v.Select(ToAssignedRequestsDTO).ToList();
        }

    }
}
