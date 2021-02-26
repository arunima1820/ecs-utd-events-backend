using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTD_ECS_Events_WebAPI.Models;
using UTD_ECS_Events_WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UTD_ECS_Events_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgsController : ControllerBase
    {
        private readonly IOrgsService _orgsService;
        public OrgsController(IOrgsService orgsService)
        {
            _orgsService = orgsService;
        }

        [HttpGet("all")]
        public ActionResult<List<OrgModel>> Get()
        {
            var events = _orgsService.GetOrgs();
            return events.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<OrgModel> GetSingleEvent(string id)
        {
            try
            {
                return _orgsService.GetSingleOrg(id);
            }
            catch (Exception)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No org with ID = {0}", id)),
                    ReasonPhrase = "Organization Id Not Found"
                };
                throw new System.Web.Http.HttpResponseException(resp);
            }
        }

        [HttpPost]
        public string Post([FromBody] OrgModel orgModel)
        {
            return _orgsService.CreateOrg(orgModel);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _orgsService.DeleteOrg(id);
        }
    }
}
