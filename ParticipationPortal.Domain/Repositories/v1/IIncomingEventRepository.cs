using ParticipationPortal.Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Repositories.v1
{
    public interface IIncomingEventRepository : IDisposable
    {
        Task SaveAsync();
        Task<IEnumerable<IncomingEvent>> GetAllAsync();
        IncomingEvent Insert(IncomingEvent entity);
        Task<bool> AnyAsync(DateTime date);
    }
}
