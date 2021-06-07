using System;

namespace EventsPlanner.BusinessLogic.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public CustomException(string message, int code)
          : base(message)
        {
            StatusCode = code;
        }
        public CustomException(string message, Exception innerException, int code)
            : base(message, innerException)
        {
            StatusCode = code;
        }
        public CustomException(CustomException ex)
        {

        }

    }

}
