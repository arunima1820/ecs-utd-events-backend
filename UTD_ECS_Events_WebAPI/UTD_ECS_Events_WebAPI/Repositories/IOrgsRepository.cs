﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;

namespace UTD_ECS_Events_WebAPI.Repositories
{
    public interface IOrgsRepository
    {
        Task<IEnumerable<OrgModel>> GetOrgs();
        Task<OrgModel> GetSingleOrgById(string id);
        Task<OrgModel> GetSingleOrgBySlug(string slug);
        Task<string> CreateOrg(OrgModel orgModel);
        void DeleteOrg(string id);
    }
}

