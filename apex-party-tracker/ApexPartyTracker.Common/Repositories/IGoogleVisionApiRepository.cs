using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApexPartyTracker.Common.Repositories
{
    public interface IGoogleVisionApiRepository
    {
        Task<IEnumerable<string>> GetPartyMembersAsync(IFormFile file);
    }
}
