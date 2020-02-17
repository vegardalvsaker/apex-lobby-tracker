using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace ApexPartyTracker.Common.Entities
{
    public class PartyEntity : TableEntity
    {
        public string Players { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateDeleted { get; set; }

        public PartyEntity(string partitionKey, string rowKey) :base(partitionKey, rowKey)
        {

        }

        public PartyEntity()
        {

        }
    }

}
