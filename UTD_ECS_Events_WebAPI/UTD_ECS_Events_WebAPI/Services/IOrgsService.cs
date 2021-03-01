﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;

namespace UTD_ECS_Events_WebAPI.Services
{
    public interface IOrgsService
    {
        IEnumerable<OrgModel> GetOrgs();
        OrgModel GetSingleOrgById(string id);
        OrgModel GetSingleOrgBySlug(string slug);
        string UpdateOrg(OrgModel orgModel);
        string CreateOrg(OrgModel orgModel);
        void DeleteOrg(string id);
    }
}

