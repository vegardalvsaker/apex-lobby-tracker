using System.Linq;
using System.Threading.Tasks;
using ApexPartyTracker.Common.Exceptions;
using ApexPartyTracker.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApexLobbyTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        // POST: api/images/
        [HttpPost("images")]
        public async Task<IActionResult> Post([FromServices] IPartyService partyService, [FromServices] IHttpContextAccessor httpContextAccessor, string user)
        {
            try
            {
                var file = httpContextAccessor.HttpContext.Request.Form.Files.First();
                var party = await partyService.AddPartyByImageAsync(file, user);
                return Created("", party);
            }
            catch (InvalidPartyException ex)
            {
                return BadRequest(ex.ValidationMessages);
            }
            }
    }
}
