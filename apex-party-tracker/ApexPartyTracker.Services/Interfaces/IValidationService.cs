using System;
using System.Collections.Generic;
using System.Text;

namespace ApexPartyTracker.Services.Interfaces
{
    public interface IValidationService
    {
        void ValidateParty(IEnumerable<string> players, string user);

    }
}
