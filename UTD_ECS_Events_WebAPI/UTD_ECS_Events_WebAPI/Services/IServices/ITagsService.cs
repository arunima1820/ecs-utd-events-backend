using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;

namespace UTD_ECS_Events_WebAPI.Services
{
    public interface ITagsService
    {
        IEnumerable<TagModel> GetTags();
        string UpdateTag(TagModel tagModel);
        string CreateTag(TagModel tagModel);
        void DeleteTag(string id);
    }
}
