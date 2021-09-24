using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Grpc.Core;
using Serilog;
using UTD_ECS_Events_WebAPI.Models;
using System.Threading.Tasks;
using System.Reflection;

namespace UTD_ECS_Events_WebAPI.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        private const string PROJECT_ID = Global.Project_Id;
        private readonly FirestoreDb _db;

        public TagsRepository()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppContext.BaseDirectory + Global.Database_Key_File));
            _db = FirestoreDb.Create(PROJECT_ID);
            Log.Logger.Information("Created Firestore connection");
        }
        public async Task<IEnumerable<TagModel>> GetTags()
        {
            Query query = _db.Collection("tags");
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            return snapshot.Documents
                .Select(document =>
                {
                    return document.ConvertTo<TagModel>();
                })
                .ToList();
        }


        public async Task<TagModel> GetTagById(string tagId)
        {
            //Query query = _db.Collection("tags");
            //QuerySnapshot snapshot = await query.GetSnapshotAsync();

            DocumentReference documentRef = _db.Document("tags/" + tagId);

            DocumentSnapshot snapshot = await documentRef.GetSnapshotAsync();

            if (snapshot.Exists)
              return snapshot.ConvertTo<TagModel>();
            return null;


        }



        public async Task<string> UpdateTag(TagModel myTag)
        {
            DocumentReference docRef = _db.Collection("tags").Document(myTag.Id);
            Dictionary<string, object> updates = new Dictionary<string, object>();

            PropertyInfo[] properties = typeof(TagModel).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                updates.Add(property.Name, property.GetValue(myTag));
            }

            await docRef.UpdateAsync(updates);
            return docRef.Id;
        }

        public async Task<string> CreateTag(TagModel myTag)
        {
            DocumentReference docRef = _db.Collection("tags").Document();
            await docRef.SetAsync(myTag);
            return docRef.Id;
        }

        public async void DeleteTag(string id)
        {
            DocumentReference docRef = _db.Collection("tags").Document(id);
            await docRef.DeleteAsync();
        }
    }
}
