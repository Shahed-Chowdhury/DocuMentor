﻿using aspnet_core.DTOs.Users;
using aspnet_core.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace aspnet_core.Services
{
    public class UserService : MongoDBService
    {
        public UserService(IOptions<MongoDBSettings> mongoDBSettings) : base(mongoDBSettings)
        {
            
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

            await _userCollection!.InsertOneAsync(mapper.Map<User>(dto));

            return;
        }

        public async Task<List<UserDTO>> GetAllUser()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
            });

            var mapper = new Mapper(config);

            var value = await _userCollection.Aggregate().Lookup("role", "Role", "_id", "role").ToListAsync(); // BSON object

            var jsonString = value.ToBsonDocument();

            //var message = JsonConvert.DeserializeObject<List<UserDTO>>(jsonString);

            return new List<UserDTO>();
        }
    }
}
