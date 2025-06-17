using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converters
{
    public static class HelpSeekersConverter
    {
        public static HelpSeekerDTO ToHelpSeekerDTO(HelpSeekers h)
        {
            HelpSeekerDTO dTO = new HelpSeekerDTO()
            {
               Address = h.Address,
               Name = h.Name,
               Phone = h.Phone,
               SeekerID = h.SeekerID
            };
            return dTO;

        }
        public static List<HelpSeekerDTO> ToHelpSeekerDTO(List<HelpSeekers> h)
        {
            return h.Select(ToHelpSeekerDTO).ToList();
        }
    }
}
