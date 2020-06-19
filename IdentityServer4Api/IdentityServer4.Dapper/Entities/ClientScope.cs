using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IdentityServer4.Dapper.Entities
{
    public class ClientScope
    {
        public int Id { get; set; }
        public string Scope { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
    }
}
