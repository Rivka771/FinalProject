using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class valunteerController : ApiController
    {
        // GET: api/valunteer
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/valunteer/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/valunteer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/valunteer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/valunteer/5
        public void Delete(int id)
        {
        }
        ValunteerBLL ValunteerBLL=new ValunteerBLL();
        //ex1
        [Route("api/ValunteerBLL/GetAssignedRequestsByIdVullenter/{id}"), HttpGet]
        public IHttpActionResult GetAssignedRequestsByIdVullenter(string id)
        {
            if (int.Parse(id)<48 && int.Parse(id)>57)
            {
                return BadRequest("הקלט חייב להיות מספר שלם תקין.");
            }
            if (id == null)
            {
                return BadRequest("יש להזין קלט");
            }
            int id1 = Convert.ToInt32(id);
            if (!ValunteerBLL.IsVolunteerExists(id1))
            {
                return BadRequest("משתמש זה אינו קיים במאגר");
            }
            return Ok(ValunteerBLL.GetAssignedRequestsByIdVullenter(id1));
        }
         
        

        //ex6
        [Route("api/ValunteerBLL/getLastReqest"), HttpGet]
        public IHttpActionResult getLastReqest()
        {
            return Ok(ValunteerBLL.getLastReqest());
        }

        //ex7
        [Route("api/ValunteerBLL/GetAllValunteerByAdress"), HttpGet]
        public IHttpActionResult GetAllValunteerByAdress()
        {
            return Ok(ValunteerBLL.GetAllValunteerByAdress());
        }
    }
}
