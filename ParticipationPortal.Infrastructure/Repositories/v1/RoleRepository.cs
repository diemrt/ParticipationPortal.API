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
    public class RoleRepository : IRoleRepository
    {
        private ParticipationPortalContext context;

        public RoleRepository(ParticipationPortalContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var result = await context.Roles
                .AsNoTracking()
                .ToListAsync();

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
