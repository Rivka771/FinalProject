using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HelpSeekerBLL
    {
        HelpSeekersDAL HelpSeekersDAL = new HelpSeekersDAL();
        ValunteerDAL ValunteerDAL = new ValunteerDAL();

        public List<HelpSeekers> GetHelpSeekers()
        {
            return HelpSeekersDAL.GetHelpSeekers();
        }
       
    }
}
