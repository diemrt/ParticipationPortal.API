using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Errors.v1.Users
{
    public class AlreadyPresentUserException : ApiException
    {
        private const string message = "Impossibile creare l'utenza perché l'utente è già stato registrato.";
        private const int statusCode  = (int)HttpStatusCode.BadRequest;

        public AlreadyPresentUserException() : base(message, statusCode)
        {

        }
    }
}
