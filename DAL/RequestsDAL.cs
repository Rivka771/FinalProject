using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RequestsDAL
    {
        YedidimDBEntities DB=new YedidimDBEntities();
        public List<Requests> GetRequests()
        {
            return DB.Requests.ToList();
        }
    }
}
