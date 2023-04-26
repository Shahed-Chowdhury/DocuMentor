using aspnet_core.DTOs.InvitedUsers;
using aspnet_core.Models;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace aspnet_core.Services
{
    public class InvitedUserServices : MongoDBService
    {
        public InvitedUserServices(IOptions<MongoDBSettings> mongoDBSettings) : base(mongoDBSettings)
        {
        }

        public async Task AddInviteUser(CreateUpdateInvitedUserDTO dto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CreateUpdateInvitedUserDTO, InvitedUser>();
                    cfg.CreateMap<InvitedUser, InvitedUserDTO>();
                });
                var mapper = new Mapper(config);
                await _invitedUserCollection!.InsertOneAsync(mapper.Map<InvitedUser>(dto));
                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
