using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public static class RequestConverter
    {
        public static RequestDTO ToRequestDTO(Requests r)
        {
            return new RequestDTO
            {
                RequestID = r.RequestID,
                SeekerID = r.SeekerID,
                RequestContent = r.RequestContent,
                Status = r.Status,
                Date = r.Date,
                ServiceID = r.ServiceID,
                Hours = r.Hours
            };
        }

        public static List<RequestDTO> ToRequestDTO(List<Requests> rList)
        {
            return rList.Select(ToRequestDTO).ToList();
        }
    }

}
