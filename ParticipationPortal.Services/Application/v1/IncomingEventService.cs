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

        public IncomingEventService(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public Task CreateNextAsync()
        {
            throw new NotImplementedException();
        }

        public async Task IncomingEventsOfTheMonth(DayOfWeek dayOfWeek)
        {
            var startingDate = DateTime.Today;
            var lastDayOfTheMonth = DateTime.DaysInMonth(startingDate.Year, startingDate.Month);
            var endingDate = new DateTime(startingDate.Year, startingDate.Month, lastDayOfTheMonth);

            while (startingDate < endingDate)
            {
                await CreateIfNewAsync(DateTimeUtils.GetNextDateOfTheWeek(startingDate, dayOfWeek));
                startingDate = startingDate.AddDays(7);
            }
        }

        public async Task CreateIfNewAsync(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
