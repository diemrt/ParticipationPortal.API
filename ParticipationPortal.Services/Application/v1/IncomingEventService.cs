using AutoMapper;
using ParticipationPortal.Domain.Common;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.Repositories.v1;
using ParticipationPortal.Domain.Services.v1;
using ParticipationPortal.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Services.Application.v1
{
    public class IncomingEventService : IIncomingEventService
    {
        private readonly IMapper _mapper;
        private readonly IWeeklyEventRepository _weeklyEventRepository;
        private readonly IIncomingEventRepository _incomingEventRepository;

        public IncomingEventService(IMapper mapper, IWeeklyEventRepository weeklyEventRepository, IIncomingEventRepository incomingEventRepository)
        {
            this._mapper = mapper;
            this._weeklyEventRepository = weeklyEventRepository;
            this._incomingEventRepository = incomingEventRepository;
        }

        public async Task CreateNextAsync()
        {
            var weeklyEvents = await _weeklyEventRepository.GetAllActiveAsync();
            foreach (var eventOfTheWeek in weeklyEvents)
            {
                await AddIncomingEventsOfTheMonth(eventOfTheWeek);
            }
        }

        public async Task AddIncomingEventsOfTheMonth(WeeklyEvent eventOfTheWeek)
        {
            var startingDate = DateTime.Today;
            var lastDayOfTheMonth = DateTime.DaysInMonth(startingDate.Year, startingDate.Month);
            var endingDate = new DateTime(startingDate.Year, startingDate.Month, lastDayOfTheMonth);

            while (startingDate < endingDate)
            {
                await CreateIfNoDateConflictAsync(DateTimeUtils.GetNextDateOfTheWeek(startingDate, (DayOfWeek)eventOfTheWeek.DayOfWeek), eventOfTheWeek);
                startingDate = startingDate.AddDays(7);
            }
        }

        public async Task CreateIfNoDateConflictAsync(DateTime dateTime, WeeklyEvent eventInfo)
        {
            var incomingEvent = _mapper.Map<IncomingEvent>(eventInfo);
            incomingEvent.ActualDate = dateTime;

            if(!await _incomingEventRepository.AnyAsync(dateTime))
            {
                _incomingEventRepository.Insert(incomingEvent);
                await _incomingEventRepository.SaveAsync();
            }
        }
    }
}
