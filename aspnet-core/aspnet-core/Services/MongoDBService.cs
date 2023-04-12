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
        private readonly IMongoCollection<User>? _userCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _userCollection = database.GetCollection<User>(mongoDBSettings.Value.CollectionName);
        }

        public async Task CreateUser(CreateUpdateUserDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUpdateUserDTO, User>();
                cfg.CreateMap<User, CreateUpdateUserDTO>();
            });

            var mapper = new Mapper(config);

            var check = _userCollection.AsQueryable().Where(x => x.Email == dto.Email).FirstOrDefault();

            if (check != null)
            {
                throw new Exception("Email address exists");
            }

            await _userCollection.InsertOneAsync(mapper.Map<User>(dto));

            return;
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(config);

            var value = await _userCollection.AsQueryable().ToListAsync();

            return mapper.Map<List<UserDTO>>(value);
        }
    }
}
