using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RequestDAL
    {
        YedidimDBEntities DB = new YedidimDBEntities();
        public List <Requests>GetRequests()
        {
            return DB.Requests.ToList();
        }
     
        //part B ex4
        public bool TheHoursGiven(int serviceId)
        {
            var param = new SqlParameter("@ServiceID", serviceId);
            var result = DB.Database.SqlQuery<bool>("SELECT dbo.TheHoursGiven(@ServiceID)", param).FirstOrDefault();
            return result == true;
        }

    }
}
