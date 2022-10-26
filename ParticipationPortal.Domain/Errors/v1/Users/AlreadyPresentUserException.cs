using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Domain.Errors.v1.Users
{
    public class AlreadyPresentUserException : ApiException
    {
        private const string message = "Impossibile creare l'utenza perché l'utente è già stato registrato.";
        private const int statusCode  = 400;

        public AlreadyPresentUserException() : base(message, statusCode)
        {

        }
    }
}
