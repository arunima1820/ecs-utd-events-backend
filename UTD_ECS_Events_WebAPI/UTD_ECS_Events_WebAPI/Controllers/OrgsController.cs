using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UTD_ECS_Events_WebAPI.Models;
using UTD_ECS_Events_WebAPI.Services;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UTD_ECS_Events_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrgsController : ControllerBase
    {
        private readonly IOrgsService _orgsService;
        //const string OnlyAllowHostedWebsiteEdit = "_onlyAllowHostedWebsiteEdit";

        public OrgsController(IOrgsService orgsService)
        {
            _orgsService = orgsService;
        }

        //[EnableCors(OnlyAllowHostedWebsiteEdit)]
        [HttpGet("all")]
        public ActionResult<List<OrgModel>> Get()
        {
            var events = _orgsService.GetOrgs();
            return events.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<OrgModel> GetSingleOrgById(string id)
        {
            try
            {
                return _orgsService.GetSingleOrgById(id);
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

        [HttpGet("slug={slug}")]
        public ActionResult<OrgModel> GetSingleOrgBySlug(string slug)
        {
            try
            {
                return _orgsService.GetSingleOrgBySlug(slug);
            }
            catch (Exception)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No org with slug = {0}", slug)),
                    ReasonPhrase = "Organization Slug Not Found"
                };
                throw new System.Web.Http.HttpResponseException(resp);
            }
        }

        [HttpPut]
        public string Put([FromBody] OrgModel orgModel)
        {
            return _orgsService.UpdateOrg(orgModel);
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
