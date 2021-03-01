using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace UTD_ECS_Events_WebAPI.Models
{
    [FirestoreData]
    public class OrgModel
    {
        [FirestoreDocumentId]
        public string UId { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string ShortName { get; set; }
        [FirestoreProperty]
        public string Website { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public string Slug { get; set; }
        [FirestoreProperty]
        public string ImageUrl { get; set; }
        [FirestoreProperty]
        public Dictionary<string,string> SocialMedia { get; set; }
    }
}
