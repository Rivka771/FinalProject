using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ValunteerBLL
    {
        ValunteerDAL valunteerDAL = new ValunteerDAL();
        AssignedRequestsDAL AssignedRequestsDAL = new AssignedRequestsDAL();
        RequestDAL RequestDAL = new RequestDAL();
        HelpSeekersDAL helpSeekersDAL = new HelpSeekersDAL();
        //בדיקת תקינות של האם מתנדב קיים במערכת.
        public bool IsVolunteerExists(int id)
        {
            var allVolunteers = valunteerDAL.GetVolunteers();
            return allVolunteers.Any(v => v.VolunteerID == id);
        }
        //ex1
        public List<AssignedRequestsDTO> GetAssignedRequestsByIdVullenter(int Id)
        {
            return Converters.AssignedRequestsConverter.ToAssignedRequestsDTO(valunteerDAL.GetAssignedRequestsByIdVullenter(Id));
        }
        //ex6
        public IDictionary<string, List<RequestDTO>> getLastReqest()
        {
            IDictionary<string, List<RequestDTO>> d = new SortedDictionary<string, List<RequestDTO>>();
            List<Volunteers> vl = valunteerDAL.GetVolunteers().OrderBy(x => x.Name).ToList();
            //בדיקת בקשות שקרובות לו 
            List<Requests> rl = RequestDAL.GetRequests().FindAll(x => x.Status == "approved" && x.Date < DateTime.Now);
            List<AssignedRequests> al = AssignedRequestsDAL.GetAssignedRequests();

            foreach (Volunteers v in vl)
            {

                List<Requests> requests = al.Where(a => a.VolunteerID == v.VolunteerID).Select(a => a.Requests).Where(r => rl.Select(x => x.RequestID).Contains(r.RequestID)).OrderBy(r => r.Date).ToList();
                List<RequestDTO> l = Converters.RequestConverter.ToRequestDTO(requests);
                d[v.Name] = l;
            }
            return d;
        }

        //ex7
        public IDictionary<string, List<valunteerDTO>> GetAllValunteerByAdress()
        {
            IDictionary<string, List<valunteerDTO>> d = new Dictionary<string, List<valunteerDTO>>();
            List<string> hl = helpSeekersDAL.GetHelpSeekers().Select(x => x.Address).Distinct().ToList();
            List<Volunteers> vl = valunteerDAL.GetVolunteers().FindAll(x => x.AssignedRequests.Any(y => y.Requests.Date.Month == DateTime.Now.Month)).ToList();
            foreach (string h in hl)
            {
                List<valunteerDTO> volunteers = new List<valunteerDTO>();
                foreach (var v in vl)
                {
                    if (v.AssignedRequests.Any(r => r.Requests.HelpSeekers.Address.Trim() == h))
                    {
                        volunteers.Add(new valunteerDTO { Name = v.Name, Phone = v.Phone, VolunteerID = v.VolunteerID });
                    }
                }

                d.Add(h, volunteers);


            }
            return d;
        }




        //part B ex1
        public int GetAllHoursHasLeft(int id)
        {
            return valunteerDAL.GetAllHoursHasLeft(id);
        }
        //part B ex2
        public List<GetAvailableVolunteersByService_ResultDTO> GetAvailableVolunteersByService(int idS)
        {
            return Converters.valunteerConverter.ToGetAvailableVolunteersByService_ResultDTO(valunteerDAL.GetAvailableVolunteersByService(idS));
        }
        //part B ex3
        public (int VolunteerCount, int ApprovedRequestCount) GetVolunteerAndRequestStatsForService(int idS)
        {
            return valunteerDAL.GetVolunteerAndRequestStatsForService(idS);
        }

        //part B ex5
        public int CountExclusiveServices(int idV)
        {
            return valunteerDAL.CountExclusiveServices(idV);
        }

        //part B ex6
        public List<GetAllDetails_ResultDTO> GetAllDetails(int idV)
        {
            return Converters.valunteerConverter.ToGetAllDetails_ResultDTO(valunteerDAL.GetAllDetails(idV));
        }
        //part B ex7
        public (int TotalHoursThisMonth, float AvgHoursLastMonth) GetVolunteerHours(int idV)
        {
            return valunteerDAL.GetVolunteerHours(idV);
        }


        }






}
