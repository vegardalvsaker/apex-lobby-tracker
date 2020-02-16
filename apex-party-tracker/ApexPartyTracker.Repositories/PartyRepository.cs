using ApexPartyTracker.Common.Entities;
using ApexPartyTracker.Common.Repositories;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace ApexPartyTracker.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private CloudTableClient _cloudTableClient;
        public PartyRepository(CloudTableClient cloudTableClient)
        {
            _cloudTableClient = cloudTableClient;
        }

        private async Task<CloudTable> getCloudTable()
        {
            var cloudTable = _cloudTableClient.GetTableReference("Party");
            await cloudTable.CreateIfNotExistsAsync();
            return cloudTable;
        }
        public async Task<PartyEntity> AddPartyAsync(PartyEntity party)
        {
            var cloudTable = await getCloudTable();
            var insertOperation = TableOperation.Insert(party);
            await cloudTable.ExecuteAsync(insertOperation);
            return party;
        }
    }
}
