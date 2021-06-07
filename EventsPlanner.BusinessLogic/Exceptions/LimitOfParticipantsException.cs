using System;
using System.Net;

namespace EventsPlanner.BusinessLogic.Exceptions
{
    class LimitOfParticipantsException : CustomException
    {
        public LimitOfParticipantsException()
         : base("Limit of participants is 25. No seats available.", (int)HttpStatusCode.Gone)
        {

        }
        public LimitOfParticipantsException(string message)
            : base(message, (int)HttpStatusCode.Gone)
        {
        }
        public LimitOfParticipantsException(string message, Exception innerException)
            : base(message, innerException, (int)HttpStatusCode.Gone)
        {

        }

    }
}
