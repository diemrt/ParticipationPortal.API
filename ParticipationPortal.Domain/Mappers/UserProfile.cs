using AutoMapper;
using ParticipationPortal.Domain.Common;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.RequestModels.v1.User;
using ParticipationPortal.Domain.ResponseModels.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            #region CreateAsync
            CreateMap<AddUserRequestModel, User>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                    .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.Value))
                    .ForMember(dest => dest.Role, opt => opt.Ignore())
                    ;
            #endregion

            #region GetByUserIdAsync 
            CreateMap<User, GetUserByUserIdResponseModel>()
                        .ForMember(dest => dest.Role, opt => opt.MapFrom(src => new GenericItem()
                        {
                            Label = src.Role.Name,
                            Value = src.RoleId
                        }))
                        ; 
            #endregion
        }
    }
}
