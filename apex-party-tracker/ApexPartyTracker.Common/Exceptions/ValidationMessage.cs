using System;
using System.Collections.Generic;
using System.Text;

namespace ApexPartyTracker.Common.Exceptions
{
    public class ValidationMessage
    {
        public string FieldName { get; set; }
        public string Message { get; set; }

        public ValidationMessage(string fieldName, string message)
        {
            FieldName = fieldName;
            Message = message;
        }
    }
}
