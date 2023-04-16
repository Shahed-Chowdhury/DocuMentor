using aspnet_core.DTOs.Users;
using aspnet_core.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

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

            var value = await _userCollection.AsQueryable().ToListAsync();

            return mapper.Map<List<UserDTO>>(value);
        }
    }
}
