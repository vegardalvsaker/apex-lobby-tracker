using ApexPartyTracker.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApexPartyTracker.Common.Repositories
{
    public interface IPartyRepository
    {
        Task<PartyEntity> AddPartyAsync(PartyEntity party);
    }
}
