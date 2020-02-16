using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApexLobbyTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        // GET: api/Resource
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Resource/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Resource
        [HttpPost("images")]
        public IActionResult Post([FromServices] IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                var file = httpContextAccessor.HttpContext.Request.Form.Files.First();

                
                using (var stream = file.OpenReadStream())
                {
                    var image = Image.FromStream(stream);
                    foreach (var annotation in ImageAnnotatorClient.Create().DetectText(image))
                    {
                        if (annotation.Description != null)
                            Console.WriteLine(annotation.Description);
                    }
                }

                return Ok("Wolla");
            }
            catch (Exception ex)
            {
                return BadRequest("Buu");
            }
        }

        // PUT: api/Resource/5
        [HttpPut("{id}")]
        public IActionResult Put([FromServices] IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                var file = httpContextAccessor.HttpContext.Request.Form.Files.First();


                using (var stream = file.OpenReadStream())
                {
                    var image = Image.FromStream(stream);
                    foreach (var annotation in ImageAnnotatorClient.Create().DetectText(image))
                    {
                        if (annotation.Description != null)
                            Console.WriteLine(annotation.Description);
                    }
                }

                return Ok("Wolla");
            }
            catch (Exception ex)
            {
                return BadRequest("Buu");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
