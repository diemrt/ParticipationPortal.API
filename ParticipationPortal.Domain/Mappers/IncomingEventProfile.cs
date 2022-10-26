using AutoMapper;
using ParticipationPortal.Domain.Common;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.ResponseModels.v1.IncomingEvent;
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

            #region AddIncomginEvent and sub logic
            CreateMap<IncomingEvent, AllIncomingEventsResponseModel>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.WeeklyEvent.Name))
                            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.ActualDate))
                            ;

            CreateMap<WeeklyEventRole, NeededRoleResponseModel>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                            .ForMember(dest => dest.IsCovered, opt => opt.Ignore())
                            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => new GenericItem()
                            {
                                Value = src.RoleId,
                                Label = src.Role.Name
                            }))
                            ; 
            #endregion
        }
    }
}
