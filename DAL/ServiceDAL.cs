using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceDAL
    {
        YedidimDBEntities DB = new YedidimDBEntities();
        public List<Services> GetServices()
        {
            return DB.Services.ToList();
        }
    }
}
