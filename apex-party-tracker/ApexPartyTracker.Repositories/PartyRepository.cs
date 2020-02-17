using ApexPartyTracker.Common.Entities;
using ApexPartyTracker.Common.Repositories;
using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<PartyEntity>> GetPartiesAsync(string user)
        {
            TableQuery<PartyEntity> query = new TableQuery<PartyEntity>()
                .Where(TableQuery.GenerateFilterCondition(
                    nameof(PartyEntity.PartitionKey),
                    QueryComparisons.Equal,
                    user
                    ));
            var cloudTable = await getCloudTable();
            TableContinuationToken token = null;
            List<PartyEntity> parties = new List<PartyEntity>();

            do
            {
                TableQuerySegment<PartyEntity> resultSegment = await cloudTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;
                parties.AddRange(resultSegment.Results);
            } while (token != null);

            return parties;
        }

        public async void AddPartiesAsync(IEnumerable<PartyEntity> parties)
        {
            var cloudTable = await getCloudTable();
            var batchOperation = new TableBatchOperation();
            parties.ToList().ForEach(p =>
            {
                batchOperation.Insert(p);
            });

            cloudTable.ExecuteBatchAsync(batchOperation);
        }
    }
}
