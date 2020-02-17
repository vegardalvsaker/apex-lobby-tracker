using ApexPartyTracker.Common.Entities;
using ApexPartyTracker.Common.Repositories;
using ApexPartyTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
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
                Players = $"[{{\"name\":\"{players.ElementAt(0)}\"}}, {{\"name\":\"{players.ElementAt(1)}\"}}]",
                RowKey = Guid.NewGuid().ToString(),
                Deleted = false,
            };
            return await _partyRepository.AddPartyAsync(party);
        }

        public async Task<IEnumerable<PartyEntity>> GetPartiesAsync(string user)
        {
            return await _partyRepository.GetPartiesAsync(user);    
        }
        /*
         * Helper method to populate storage with test data
         */
        public void AddPartiesAsync()
        {
            var personGenerator = new PersonNameGenerator();
            var maleNames = personGenerator.GenerateMultipleMaleFirstNames(101);
            var femaleNames = personGenerator.GenerateMultipleFemaleFirstNames(101);
            List<PartyEntity> parties = new List<PartyEntity>();
            
            for (int i = 0; i < 101; i++)
            {
                parties.Add(new PartyEntity()
                {
                    PartitionKey = "vikjard",
                    Players = $"[{{\"name\":\"{maleNames.ElementAt(i)}\"}}, {{\"name\":\"{femaleNames.ElementAt(i)}\"}}]",
                    RowKey = Guid.NewGuid().ToString(),
                    Deleted = false,
                });
            }

            _partyRepository.AddPartiesAsync(parties);

        }
    }
}
