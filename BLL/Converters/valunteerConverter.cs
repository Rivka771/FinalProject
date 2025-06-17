using DAL;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Converters
{
    public static class valunteerConverter
    {
        public static valunteerDTO TovalunteerDTO(Volunteers v)
        {
            valunteerDTO dTO = new valunteerDTO()
            {
                VolunteerID = v.VolunteerID,
                Name = v.Name,
                Phone = v.Phone
            };
            return dTO;

        }
        public static List<valunteerDTO> TovalunteerDTO(List<Volunteers> v)
        {
            return v.Select(TovalunteerDTO).ToList();
        }

        public static GetAvailableVolunteersByService_ResultDTO ToGetAvailableVolunteersByService_ResultDTO(GetAvailableVolunteersByService_Result v)
        {
            GetAvailableVolunteersByService_ResultDTO dTO = new GetAvailableVolunteersByService_ResultDTO()
            {
                VolunteerID = v.VolunteerID,
                Name = v.Name,
                Phone = v.Phone
            };
            return dTO;

        }
        public static List<GetAvailableVolunteersByService_ResultDTO> ToGetAvailableVolunteersByService_ResultDTO(List<GetAvailableVolunteersByService_Result> v)
        {
            return v.Select(ToGetAvailableVolunteersByService_ResultDTO).ToList();
        }

        public static GetAllDetails_ResultDTO ToGetAllDetails_ResultDTO(GetAllDetails_Result d)
        {
            GetAllDetails_ResultDTO dTO = new GetAllDetails_ResultDTO()
            {
                Name = d.Name,
                Phone = d.Phone,
                Address = d.Address,
                Date = d.Date,
                RequestContent = d.RequestContent,
                ServiceName = d.ServiceName

            };
            return dTO;

        }
        public static List<GetAllDetails_ResultDTO> ToGetAllDetails_ResultDTO(List<GetAllDetails_Result> d)
        {
            return d.Select(ToGetAllDetails_ResultDTO).ToList();
        }
    }
}
