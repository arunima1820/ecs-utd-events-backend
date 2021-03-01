using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;
using UTD_ECS_Events_WebAPI.Repositories;

namespace UTD_ECS_Events_WebAPI.Services
{
    public class OrgsService : IOrgsService
    {
        private readonly IOrgsRepository _orgsRepository;

        public OrgsService(IOrgsRepository orgsRepository)
        {
            _orgsRepository = orgsRepository;
        }

        public IEnumerable<OrgModel> GetOrgs()
        {
            return _orgsRepository.GetOrgs().Result;
        }
        
        public OrgModel GetSingleOrgById(string id)
        {
            return _orgsRepository.GetSingleOrgById(id).Result;
        }

        public OrgModel GetSingleOrgBySlug(string slug)
        {
            return _orgsRepository.GetSingleOrgBySlug(slug).Result;
        }

        public string UpdateOrg(OrgModel orgModel)
        {
            return _orgsRepository.UpdateOrg(orgModel).Result;
        }

        public string CreateOrg(OrgModel orgModel)
        {
            return _orgsRepository.CreateOrg(orgModel).Result;
        }

        public void DeleteOrg(string id)
        {
            _orgsRepository.DeleteOrg(id);
        }
    }
}

