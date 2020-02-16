using System;
using System.Collections.Generic;
using System.Text;

namespace ApexPartyTracker.Common.Exceptions
{
    public class InvalidPartyException : ApexPartyTrackerExceptionBase
    {
        public IEnumerable<ValidationMessage> ValidationMessages { get; }
        public InvalidPartyException(List<ValidationMessage> validationMessages)
        {
            ValidationMessages = validationMessages;
        }

        public InvalidPartyException(string message)
            : base(message)
        {
        }

        public InvalidPartyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
