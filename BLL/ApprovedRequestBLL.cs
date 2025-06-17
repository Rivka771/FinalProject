using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ApprovedRequestBLL
    {
        RequestBLL requestBLL=new RequestBLL();
        //ex4
        public List<ApprovedRequestInfoDTO> ApprovedRequestInfos()
        {
            List<ApprovedRequestInfoDTO> approvedRequestInfoDTOs = new List<ApprovedRequestInfoDTO>();
            List<Requests> requests =new RequestDAL().GetRequests();
            var approvedRequests = requests.Where(r => r.Status == "approved");
            foreach (var request in approvedRequests)
            {
                approvedRequestInfoDTOs.Add(new ApprovedRequestInfoDTO
                {
                    VolunteerName=request.AssignedRequests.FirstOrDefault().Volunteers.Name,
                    HelpSeekerName=request.HelpSeekers.Name,
                   RequestDate=request.Date,
                   RequestContent=request.RequestContent
                });
            }
            return approvedRequestInfoDTOs;
        }
    }
}
