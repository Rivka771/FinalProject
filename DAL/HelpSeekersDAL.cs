using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HelpSeekersDAL
    {
        YedidimDBEntities DB=new YedidimDBEntities();
        public List<HelpSeekers>GetHelpSeekers()
        {
            return DB.HelpSeekers.ToList();
        }
    }
}
