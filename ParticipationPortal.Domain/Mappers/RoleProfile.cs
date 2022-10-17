using AutoMapper;
using ParticipationPortal.Domain.Common;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.ResponseModels.v1.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Mappers
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            #region GetAllAsync 
            CreateMap<Role, GenericItem>()
                        .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                        .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                        ; 
            #endregion
        }
    }
}
