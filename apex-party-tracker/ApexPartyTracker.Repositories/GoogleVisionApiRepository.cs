using ApexPartyTracker.Common.Repositories;
using Google.Cloud.Vision.V1;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApexPartyTracker.Repositories
{
    public class GoogleVisionApiRepository : IGoogleVisionApiRepository
    {
        public async Task<IEnumerable<string>> GetPartyMembersAsync(IFormFile file)
        {
            try {
                Image image;
                List<string> players = new List<string> { };
                var client = ImageAnnotatorClient.Create();

                using (var stream = file.OpenReadStream())
                {
                    image = await Image.FromStreamAsync(stream);
                }

                var entityAnnotationList = client.DetectText(image);
                
                if (entityAnnotationList.Count > 0)
                {
                    for (int i = 1; i < entityAnnotationList.Count; i++)
                    {
                        players.Add(entityAnnotationList[i].Description);
                    }
                }

                return players;
            } 
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
