using Dapper;
using IdentityServer4.Dapper.Mappers;
using IdentityServer4.Dapper.Options;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Dapper.Stores.SqlServer
{
    public class SqlServerClientStore : IClientStore
    {
        private readonly ILogger<SqlServerClientStore> logger;
        private readonly DapperStoreOptions dapperStoreOptions;

        public SqlServerClientStore(ILogger<SqlServerClientStore> logger, DapperStoreOptions dapperStoreOptions)
        {
            this.logger = logger;
            this.dapperStoreOptions = dapperStoreOptions;
        }

        /// <summary>
        /// 根据客户端ID 获取客户端信息内容
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var cModel = new Client();
            var _client = new Entities.Client();
            using (var connection = new SqlConnection(dapperStoreOptions.DbConnectStrings))
            {
                string sql = @"select * from Clients where ClientId=@client and Enabled=1;
               select t2.* from Clients t1 inner join ClientGrantTypes t2 on t1.Id=t2.ClientId where t1.ClientId=@client and Enabled=1;
               select t2.* from Clients t1 inner join ClientRedirectUris t2 on t1.Id=t2.ClientId where t1.ClientId=@client and Enabled=1;
               select t2.* from Clients t1 inner join ClientScopes t2 on t1.Id=t2.ClientId where t1.ClientId=@client and Enabled=1;
               select t2.* from Clients t1 inner join ClientSecrets t2 on t1.Id=t2.ClientId where t1.ClientId=@client and Enabled=1;
                      ";
                var multi = await connection.QueryMultipleAsync(sql, new { client = clientId });
                var client = multi.Read<Entities.Client>();
                var clientGrantTypes = multi.Read<Entities.ClientGrantType>();
                var clientRedirectUris = multi.Read<Entities.ClientRedirectUri>();
                var clientScopes = multi.Read<Entities.ClientScope>();
                var clientSecrets = multi.Read<Entities.ClientSecret>();

                if (client != null && client.AsList().Count > 0)
                {
                    //提取信息
                    _client = client.AsList()[0];
                    _client.AllowedGrantTypes = clientGrantTypes.AsList();
                    _client.RedirectUris = clientRedirectUris.AsList();
                    _client.AllowedScopes = clientScopes.AsList();
                    _client.ClientSecrets = clientSecrets.AsList();
                    cModel = _client.ToModel();
                }

            }
            logger.LogDebug("{clientId} found in database: {clientIdFound}", clientId, _client != null);

            return cModel;
        }
    }
}
