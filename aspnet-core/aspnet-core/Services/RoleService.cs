using Amazon.Runtime.SharedInterfaces;
using aspnet_core.DTOs.Roles;
using aspnet_core.Models;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace aspnet_core.Services
{
    public class RoleService : MongoDBService
    {
        public RoleService(IOptions<MongoDBSettings> mongoDBSettings) : base(mongoDBSettings)
        {
        }

        public async Task CreateRole(CreateUpdateRoleDTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateUpdateRoleDTO, Role>();
                cfg.CreateMap<Role, CreateUpdateRoleDTO>();
            });

            var mapper = new Mapper(config);

            var check = _roleCollection.AsQueryable().Where(x => x.Name == dto.Name.ToUpper()).FirstOrDefault();

            if (check != null)
            {
                throw new Exception("Role exists");
            }

            dto.Name = dto.Name.ToUpper();
            await _roleCollection!.InsertOneAsync(mapper.Map<Role>(dto));

            return;
        }

        public async Task<List<RoleDTO>> GetAllRole()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Role, RoleDTO>());
            var mapper = new Mapper(config);
            var resp = await _roleCollection.AsQueryable().ToListAsync();
            return mapper.Map<List<RoleDTO>>(resp);
        }

        public async Task<Boolean> DeleteRole(string id)
        {
            var resp = _roleCollection.DeleteOneAsync(a => a.Id == id);
            if (resp.Result.DeletedCount > 0) return true;
            return false;
        }
    }
}
