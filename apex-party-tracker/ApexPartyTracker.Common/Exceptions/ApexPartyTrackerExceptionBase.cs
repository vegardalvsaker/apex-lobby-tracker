using System;

namespace ApexPartyTracker.Common.Exceptions
{
    public class ApexPartyTrackerExceptionBase : Exception
    {
        public ApexPartyTrackerExceptionBase()
        {

        }
        public ApexPartyTrackerExceptionBase(string message) : base(message)
        {
        }

        public ApexPartyTrackerExceptionBase(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
