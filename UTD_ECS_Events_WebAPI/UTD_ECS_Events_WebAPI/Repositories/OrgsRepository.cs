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

namespace UTD_ECS_Events_WebAPI.Repositories
{
    public class OrgsRepository : IOrgsRepository
    {
        private const string PROJECT_ID = "utdecsevents-9bed0";
        private readonly FirestoreDb _db;

        public OrgsRepository()
        {
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Path.Combine(AppContext.BaseDirectory + "/google.json"));
            _db = FirestoreDb.Create(PROJECT_ID);
            Log.Logger.Information("Created Firestore connection");
        }

        public async Task<IEnumerable<OrgModel>> GetOrgs()
        {
            Query query = _db.Collection("organizations");
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            return snapshot.Documents
                .Select(document =>
                {
                    return document.ConvertTo<OrgModel>();
                })
                .ToList();
        }

        public async Task<OrgModel> GetSingleOrgById(string id)
        {
            DocumentReference docRef = _db.Collection("organizations").Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<OrgModel>();
            }
            else
            {
                throw new ArgumentException("Document with this id does not exist: " + id);
            }
        }

        public async Task<OrgModel> GetSingleOrgBySlug(string slug)
        {
            Query query = _db.Collection("organizations")
                .WhereEqualTo("Slug",slug);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            if(snapshot.Documents.Count == 0)
            {
                throw new ArgumentException("Organization with this slug does not exist: " + slug);
            }
            else if (snapshot.Documents.Count == 1)
            {
                return snapshot.Documents
                .Select(document =>
                {
                    return document.ConvertTo<OrgModel>();
                }).ToList().ElementAt(0);

            }
            else
            {
                throw new ArgumentException("Multiple organizations with this slug exist: " + slug);
            }
        }

        public async Task<string> CreateOrg(OrgModel myOrg)
        {
            DocumentReference docRef = _db.Collection("organizations").Document(myOrg.UId);
            await docRef.SetAsync(myOrg);
            return docRef.Id;
        }

        public async void DeleteOrg(string id)
        {
            DocumentReference docRef = _db.Collection("organizations").Document(id);
            await docRef.DeleteAsync();
        }
    }
}

