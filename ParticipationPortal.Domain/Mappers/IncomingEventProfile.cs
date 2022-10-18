using AutoMapper;
using ParticipationPortal.Domain.Common;
using ParticipationPortal.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Mappers
{
    public class IncomingEventProfile : Profile
    {
        public IncomingEventProfile()
        {
            #region CreateIfNoDateConflictAsync 
            CreateMap<WeeklyEvent, IncomingEvent>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                        .ForMember(dest => dest.WeeklyEvent, opt => opt.Ignore())
                        .ForMember(dest => dest.IncomingEventUsers, opt => opt.Ignore())
                        .ForMember(dest => dest.WeeklyEventId, opt => opt.MapFrom(src => src.Id))
                        ; 
            #endregion
        }
    }
}
