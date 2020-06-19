using IdentityServer4.Configuration;
using IdentityServer4.Dapper.Options;
using IdentityServer4.Stores;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// dapper 拓展
    /// </summary>
    public static class IdentityServerDapperBuilderExtensions
    {
        /// <summary>
        /// 配置Dapper接口和实现(默认使用SqlServer)
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="storeOptionsAction"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder AddDapperStore(this IIdentityServerBuilder builder, Action<DapperStoreOptions> storeOptionsAction = null)
        {
            var options = new DapperStoreOptions();
            builder.Services.AddSingleton(options);
            storeOptionsAction?.Invoke(options);
            builder.Services.AddTransient<IClientStore, SqlServerClientStore>();
            builder.Services.AddTransient<IResourceStore, SqlServerResourceStore>();
            builder.Services.AddTransient<IPersistedGrantStore, SqlServerPersistedGrantStore>();
            return builder;
        }

        /// <summary>
        /// 使用Mysql存储
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IIdentityServerBuilder UseMySql(this IIdentityServerBuilder builder)
        {
            builder.Services.AddTransient<IClientStore, MySqlClientStore>();
            builder.Services.AddTransient<IResourceStore, MySqlResourceStore>();
            builder.Services.AddTransient<IPersistedGrantStore, MySqlPersistedGrantStore>();
            return builder;
        }
    }
}
