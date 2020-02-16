using ApexPartyTracker.Services.Interfaces;
using ApexPartyTracker.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApexPartyTracker.Services
{
    public class ValidationService : IValidationService
    {
        public void ValidateParty(IEnumerable<string> players, string user)
        {
            var errorMessages = new List<ValidationMessage> { };
            players = players.ToList();
            if (players.Count() != 3)
            {
                errorMessages.Add(new ValidationMessage("partySize", "Invalid party size"));
            }

            if (!players.Contains(user))
            {
                errorMessages.Add(new ValidationMessage("userRequirement", "Logged in user not in party"));
            }

            var distinctPlayers = new HashSet<string>(players);
            if (distinctPlayers.Count() != players.Count())
            {
                errorMessages.Add(new ValidationMessage("partyRequirement", "A player appears more than once"));
            }

            if (errorMessages.Any())
            {
                throw new InvalidPartyException(errorMessages);
            }
        }
    }
}
