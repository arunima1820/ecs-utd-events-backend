using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;

namespace UTD_ECS_Events_WebAPI.Repositories
{
    public interface ITagsRepository
    {
        Task<IEnumerable<TagModel>> GetTags();
        Task<string> UpdateTag(TagModel myTag);
        Task<string> CreateTag(TagModel myTag);
        void DeleteTag(string id);
    }
}
