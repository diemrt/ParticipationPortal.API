using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Errors.v1.Users
{
    public class UserNotFoundException : ApiException
    {
        private const string message = "Impossibile trovare un'utenza associata a questo user id.";
        private const int statusCode = (int)HttpStatusCode.NotFound;

        public UserNotFoundException() : base(message, statusCode)
        {
        }
    }
}
