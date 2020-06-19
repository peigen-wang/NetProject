using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Dapper.Entities
{
    public class ClientCorsOrigin
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
    }
}
