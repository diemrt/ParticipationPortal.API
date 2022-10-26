using AutoMapper;
using ParticipationPortal.Domain.Common;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.Repositories.v1;
using ParticipationPortal.Domain.ResponseModels.v1.IncomingEvent;
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

        /// <summary>
        /// Create the next events for the current months
        /// </summary>
        /// <returns></returns>
        public async Task CreateNextAsync()
        {
            var weeklyEvents = await _weeklyEventRepository.GetAllActiveAsync();
            foreach (var eventOfTheWeek in weeklyEvents)
            {
                await AddIncomingEventsOfTheMonth(eventOfTheWeek);
            }
        }

        /// <summary>
        /// Add incomgin events itereting on the events for the month
        /// </summary>
        /// <param name="eventOfTheWeek">WeeklyEvent entity</param>
        /// <returns>Only the events remaning to end the month</returns>
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

        /// <summary>
        /// Create an event only if there's no date conflict
        /// </summary>
        /// <param name="dateTime">The evnt date</param>
        /// <param name="eventInfo">WeeklyEvent entity</param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all the created events of the current month
        /// </summary>
        /// <returns></returns>
        public async Task<GetAllIncomingEventsResponseModel> GetAllAsync()
        {
            var startingDate = DateTime.Today;
            var lastDayOfTheMonth = DateTime.DaysInMonth(startingDate.Year, startingDate.Month);
            var endingDate = new DateTime(startingDate.Year, startingDate.Month, lastDayOfTheMonth);

            var result = new GetAllIncomingEventsResponseModel();
            var addedIncomingEvents = new List<AllIncomingEventsResponseModel>();

            var incomingEvnts = await _incomingEventRepository.GetAllAsync(startingDate, endingDate);
            foreach (var incomingEvent in incomingEvnts)
            {
                addedIncomingEvents.Add(AddIncomginEvent(incomingEvent));
            }

            result.Data = addedIncomingEvents;
            return result;
        }

        /// <summary>
        /// Add incoming event to the response model
        /// </summary>
        /// <param name="incomingEvnt">IncomingEvent entity</param>
        /// <returns></returns>
        private AllIncomingEventsResponseModel AddIncomginEvent(IncomingEvent incomingEvnt)
        {
            var result = new AllIncomingEventsResponseModel();
            var addedNeededRole = new List<NeededRoleResponseModel>();
            var addedInvolvedUser = new List<InvolvedUserResponseModel>();

            foreach (var neededRole in incomingEvnt.WeeklyEvent.WeeklyEventRoles)
            {
                addedNeededRole.Add(AddedNeededRole(incomingEvnt, neededRole));
            }

            result.NeededRoles = addedNeededRole;
            result.InvolvedUsers = addedInvolvedUser;
            return result;

        }

        /// <summary>
        /// Add roles needed to the response model
        /// </summary>
        /// <param name="incomingEvnt">IncomingEvent entity</param>
        /// <param name="neededRole">WeeklyEventRole entity</param>
        /// <returns></returns>
        private NeededRoleResponseModel AddedNeededRole(IncomingEvent incomingEvnt, WeeklyEventRole neededRole)
        {
            var result = new NeededRoleResponseModel();
            result = _mapper.Map<NeededRoleResponseModel>(neededRole);

            result.IsCovered = incomingEvnt.IncomingEventUsers.Any(i => i.User.RoleId == neededRole.RoleId);
            return result;
        }
    }
}
