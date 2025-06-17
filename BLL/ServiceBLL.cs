using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiceBLL
    {
        ServiceDAL ServiceDAL=new ServiceDAL();
        //בדיקת תקינות של האם שירות קיים במערכת.
        public bool IsServiceExists(int id)
        {
            var allServices = ServiceDAL.GetServices();
            return allServices.Any(v => v.ServiceID == id);
        }
    }
}
