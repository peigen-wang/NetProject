using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IdentityServer4.Dapper.Entities
{
    public class ClientClaim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
    }
}
