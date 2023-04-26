using aspnet_core.DTOs.Roles;
using aspnet_core.DTOs.Users;
using aspnet_core.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
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

            //var salt = BCrypt.Net.BCrypt.GenerateSalt();

            dto.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(dto.Password, workFactor: 13);

            await _userCollection!.InsertOneAsync(mapper.Map<User>(dto));

            return;
        }

        public async Task<List<UserDTO>> GetAllUser()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Role, RoleDTO>();
            });

            var mapper = new Mapper(config);

            var value = await _userCollection.Aggregate().Lookup("role", "Role", "_id", "role").ToListAsync(); // BSON object

            List<User> result = new List<User>();

            foreach (var doc in value)
            {
                var obj = BsonSerializer.Deserialize<User>(doc);

                result.Add(obj);
            }

            List<UserDTO> resultDTO = new List<UserDTO>();

            foreach (var item in result)
            {
                var dto = new UserDTO();
                dto.Id = item.Id;
                dto.Email = item.Email;
                dto.FirstName = item.FirstName;
                dto.LastName = item.LastName;
                dto.Address = item.Address;
                dto.UserName = item.UserName;
                dto.PhoneNumber = item.PhoneNumber;
                //dto.Password = item.Password;
                dto.Roles = mapper.Map<RoleDTO>(item.Roles[0]);
                resultDTO.Add(dto);
            }
            return resultDTO;
        }
    }
}
