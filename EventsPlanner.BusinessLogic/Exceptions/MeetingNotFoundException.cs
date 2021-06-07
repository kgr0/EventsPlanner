using System;
using System.Net;

namespace EventsPlanner.BusinessLogic.Exceptions
{
    class MeetingNotFoundException : CustomException
    {
        public MeetingNotFoundException()
         : base("Meeting not found", (int)HttpStatusCode.NotFound)
        {

        }
        public MeetingNotFoundException(int id)
         : base("Meeting with id " + id +" is not found", (int)HttpStatusCode.NotFound)
        {

        }
        public MeetingNotFoundException(string message)
            : base(message, (int)HttpStatusCode.NotFound)
        {
        }
        public MeetingNotFoundException(string message, Exception innerException)
            : base(message, innerException, (int)HttpStatusCode.NotFound)
        {

        }

    }
}
