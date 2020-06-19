using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IdentityServer4.Dapper.Entities
{
    public class ClientPostLogoutRedirectUri
    {
        public int Id { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
    }
}
