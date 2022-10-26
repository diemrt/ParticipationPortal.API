using Microsoft.EntityFrameworkCore;
using ParticipationPortal.Domain.Entities.v1;
using ParticipationPortal.Domain.Repositories.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Infrastructure.Repositories.v1
{
    public class IncomingEventRepository : IIncomingEventRepository
    {
        private ParticipationPortalContext context;

        public IncomingEventRepository(ParticipationPortalContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<IncomingEvent>> GetAllAsync(DateTime startingDate, DateTime endingDate)
        {
            var result = await context.IncomingEvents
                .Include(x => x.IncomingEventUsers.OrderBy(x => x.UserId)).ThenInclude(x => x.User)
                .Include(x => x.WeeklyEvent).ThenInclude(x => x.WeeklyEventRoles.OrderBy(x => x.RoleId)).ThenInclude(x => x.Role)
                .Where(x => x.ActualDate >= startingDate && x.ActualDate <= endingDate)
                .OrderBy(x => x.ActualDate)
                .AsNoTracking()
                .ToListAsync();

            return result;
        }

        public IncomingEvent Insert(IncomingEvent entity)
        {
            var result = context.IncomingEvents.Add(entity);
            return result.Entity;
        }

        public async Task<bool> AnyAsync(DateTime date)
        {
            var result = await context.IncomingEvents
                .Where(x => x.ActualDate == date)
                .AsNoTracking()
                .AnyAsync();

            return result;
        }


        #region Save
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        } 
        #endregion

        #region Dispose
        private bool disposed = false;
        protected async Task DisposeAsync(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    await context.DisposeAsync();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            DisposeAsync(true).Wait();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
