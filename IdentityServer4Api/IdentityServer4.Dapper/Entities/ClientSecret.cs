
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IdentityServer4.Dapper.Entities
{
    public class ClientSecret : Secret
    {
        [JsonIgnore]
        public Client Client { get; set; }
    }
}
