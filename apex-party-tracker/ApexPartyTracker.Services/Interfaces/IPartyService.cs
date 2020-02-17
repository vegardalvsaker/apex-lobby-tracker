using ApexPartyTracker.Common.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApexPartyTracker.Services.Interfaces
{
    public interface IPartyService
    {
        Task<PartyEntity> AddPartyByImageAsync(IFormFile file, string user);
        //Task<PartyEntity> AddPartyByTextAsync(string player1, string player2);
        Task<IEnumerable<PartyEntity>> GetPartiesAsync(string user);
        void AddPartiesAsync();

    }
}
