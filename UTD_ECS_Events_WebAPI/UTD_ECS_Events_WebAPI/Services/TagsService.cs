using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UTD_ECS_Events_WebAPI.Models;
using UTD_ECS_Events_WebAPI.Repositories;

namespace UTD_ECS_Events_WebAPI.Services
{
    public class TagsService : ITagsService
    {
        private readonly ITagsRepository _tagsRepository;

        public TagsService(ITagsRepository tagsRepository)
        {
            _tagsRepository = tagsRepository;
        }

        public IEnumerable<TagModel> GetTags()
        {
            return _tagsRepository.GetTags().Result;
        }

        public TagModel GetTagById(string id)
        {
            return _tagsRepository.GetTagById(id).Result;
        }

        public string UpdateTag(TagModel tagModel)
        {
            return _tagsRepository.UpdateTag(tagModel).Result;
        }

        public string CreateTag(TagModel tagModel)
        {
            return _tagsRepository.CreateTag(tagModel).Result;
        }

        public void DeleteTag(string id)
        {
            _tagsRepository.DeleteTag(id);
        }
        


    }
}
