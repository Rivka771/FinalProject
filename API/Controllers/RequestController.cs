
using System;
using System.Collections.Generic;
using System.Web.Http;
using BLL;

namespace API.Controllers
{
    public class RequestController : ApiController
    {
        RequestBLL requestBLL = new RequestBLL();
        ValunteerBLL ValunteerBLL = new ValunteerBLL();
        ApprovedRequestBLL approvedRequestBLL = new ApprovedRequestBLL();
        // GET: api/Request
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Request/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Request
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Request/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Request/5
        public void Delete(int id)
        {
        }
        //ex2
        [Route("api /requestBLL/GetUnAssigned"), HttpGet]
        public IHttpActionResult GetUnAssigned()
        {

            return Ok(requestBLL.GetUnAssigned());


        }

        //ex3
        [Route("api/requestBLL/GetHelpSeekerWithMaxRequests"), HttpGet]
        public IHttpActionResult GetHelpSeekerWithMaxRequests()
        {

            return Ok(requestBLL.GetHelpSeekerWithMaxRequests());


        }

        //ex4
        [Route("api/ApprovedRequestBLL/ApprovedRequestInfos"), HttpGet]
        public IHttpActionResult ApprovedRequestInfos()
        {
            return Ok(approvedRequestBLL.ApprovedRequestInfos());
        }

        //ex5
        [Route("api/requestBLL/RequestsMadeToTheApplicantMostOften/{id}"), HttpGet]
        public IHttpActionResult RequestsMadeToTheApplicantMostOften(string id)
        {

            if (int.Parse(id) < 48 && int.Parse(id) > 57)
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
            return Ok(requestBLL.RequestsMadeToTheApplicantMostOften(id1));
        }
    }

}

