using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.ResponseModels.v1.IncomingEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Services.v1
{
    public interface IIncomingEventService
    {
        Task CreateNextAsync();
        Task AddIncomingEventsOfTheMonth(WeeklyEvent eventOfTheWeek);
        Task CreateIfNoDateConflictAsync(DateTime dateTime, WeeklyEvent eventInfo);
        Task<GetAllIncomingEventsResponseModel> GetAllAsync();
    }
}
