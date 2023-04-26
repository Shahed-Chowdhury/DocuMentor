using aspnet_core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using aspnet_core.DTOs.Users;
using AutoMapper;
using System.Xml;

namespace aspnet_core.Services
{
    public class MongoDBService
    {
        protected readonly IMongoCollection<User>? _userCollection;
        protected readonly IMongoCollection<Role>? _roleCollection;
        protected readonly IMongoCollection<InvitedUser>? _invitedUserCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _userCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
            _roleCollection = database.GetCollection<Role>(mongoDBSettings.Value.CollectionName2);
            _invitedUserCollection = database.GetCollection<InvitedUser>(mongoDBSettings.Value.CollectionName3);
        }
    }
}
