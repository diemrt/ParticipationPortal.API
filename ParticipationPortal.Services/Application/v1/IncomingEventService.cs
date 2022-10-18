using AutoMapper;
using ParticipationPortal.Domain.Common;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.Repositories.v1;
using ParticipationPortal.Domain.Services.v1;
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
    }
}
