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
    public class UserRepository : IUserRepository
    {
        private ParticipationPortalContext context;

        public UserRepository(ParticipationPortalContext context)
        {
            this.context = context;
        }

        public User Insert(User user)
        {
            var result = context.Users.Add(user);
            return result.Entity;
        }

        public async Task<bool> AnyAsync(string userId)
        {
            var result = await context.Users.Where(x => x.FirebaseUserId.Equals(userId)).AsNoTracking().FirstOrDefaultAsync();
            return result != null;
        }

        public async Task<User> GetByUserIdAsync(string userId)
        {
            var result = await context.Users
                .Include(x => x.Role)
                .Where(x => x.FirebaseUserId.Equals(userId))
                .AsNoTracking()
                .FirstOrDefaultAsync();

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
