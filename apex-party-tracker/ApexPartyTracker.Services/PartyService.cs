using ApexPartyTracker.Common.Entities;
using ApexPartyTracker.Common.Repositories;
using ApexPartyTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http; 
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApexPartyTracker.Services
{
    public class PartyService : IPartyService
    {
        private IValidationService _validationService;
        private IGoogleVisionApiRepository _googleVisionApiRepository;
        private IPartyRepository _partyRepository;
        public PartyService(IValidationService validationService, IGoogleVisionApiRepository googleVisionApiRepository, IPartyRepository partyRepository)
        {
            _validationService = validationService;
            _googleVisionApiRepository = googleVisionApiRepository;
            _partyRepository = partyRepository;
        }

        public async Task<PartyEntity> AddPartyByImageAsync(IFormFile file, string user)
        {
            var players = await _googleVisionApiRepository.GetPartyMembersAsync(file);
            _validationService.ValidateParty(players, user);

            var party = new PartyEntity()
            {
                PartitionKey = user,
                Player1 = players.ToList().ElementAt(0),
                Player2 = players.ToList().ElementAt(1),
                RowKey = Guid.NewGuid().ToString(),
                Deleted = false,
                PartyPlayed = DateTime.Now
            };
            return await _partyRepository.AddPartyAsync(party);
        }
    }
}
