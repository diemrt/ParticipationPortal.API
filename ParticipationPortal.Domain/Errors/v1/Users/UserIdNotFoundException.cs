using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Errors.v1.Users
{
    public class UserIdNotFoundException : ApiException
    {
        private const string message = "Impossibile trovare lo user id specificato.";
        private const int statusCode = (int)HttpStatusCode.NotFound;

        public UserIdNotFoundException() : base(message, statusCode)
        {
        }
    }
}
