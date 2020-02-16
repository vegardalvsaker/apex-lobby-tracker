using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApexPartyTracker.Common.Entities
{
    public class PartyEntity : TableEntity
    {
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public DateTime PartyPlayed { get; set; }
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
