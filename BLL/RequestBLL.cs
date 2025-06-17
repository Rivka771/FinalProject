using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace BLL
{
    public class RequestBLL
    {
        RequestDAL RequestDAL = new RequestDAL();
        HelpSeekerBLL HelpSeekerBLL = new HelpSeekerBLL();
        AssignedRequestsDAL AssignedRequestsDAL = new AssignedRequestsDAL();
        HelpSeekersDAL helpSeekersDAL = new HelpSeekersDAL();
        public List<Requests> GetRequests()
        {
            return RequestDAL.GetRequests();
        }
      
        //ex2
        public IDictionary<HelpSeekerDTO, List<RequestDTO>> GetUnAssigned()
        {
            IDictionary<HelpSeekerDTO, List<RequestDTO>> DiR = new Dictionary<HelpSeekerDTO, List<RequestDTO>>();
            List<HelpSeekers> helpSeekers = HelpSeekerBLL.GetHelpSeekers();
            foreach (HelpSeekers hs in helpSeekers)
            {
                DiR.Add(Converters.HelpSeekersConverter.ToHelpSeekerDTO(hs), Converters.RequestConverter.ToRequestDTO(GetRequests().FindAll(x => x.SeekerID == hs.SeekerID && x.Status == "pending").ToList()));
            }
            return DiR;
        }
        //ex3
        public HelpSeekerDTO GetHelpSeekerWithMaxRequests()
        {
            return GetUnAssigned().OrderByDescending(x => x.Value.Count).First().Key;
        }
        //ex5
        public Dictionary<DateTime, List<RequestDTO>> RequestsMadeToTheApplicantMostOften(int idVulenteer)
        {

            var assignedRequests = AssignedRequestsDAL.GetAssignedRequests().Where(ar => ar.VolunteerID == idVulenteer).ToList();
            var allSeekerIds = helpSeekersDAL.GetHelpSeekers().Select(x => x.SeekerID).Distinct();


            var seekerWithMaxRequests = allSeekerIds.Select(seekerId => new
            {
                SeekerId = seekerId,
                Count = assignedRequests.Count(ar => ar.Requests.HelpSeekers.SeekerID == seekerId)
            })
                   .OrderByDescending(x => x.Count).FirstOrDefault();

            int maxSeekerId = seekerWithMaxRequests.SeekerId;

            var requestsForMaxSeeker = assignedRequests.Where(ar => ar.Requests.HelpSeekers.SeekerID == maxSeekerId)
                .Select(ar => new RequestDTO
                {
                    RequestID = ar.Requests.RequestID,
                    Date = ar.Requests.Date,

                })
                .ToList();
            var d = new Dictionary<DateTime, List<RequestDTO>>();

            foreach (var request in requestsForMaxSeeker)
            {
                var dateKey = request.Date.Date;

                if (!d.ContainsKey(dateKey))
                {
                    d[dateKey] = new List<RequestDTO>();
                }

                d[dateKey].Add(request);
            }

            return d;
        }

        //part B ex4
        public bool TheHoursGiven(int serviceId)
        {
           return RequestDAL.TheHoursGiven(serviceId);
        }

    }
}
