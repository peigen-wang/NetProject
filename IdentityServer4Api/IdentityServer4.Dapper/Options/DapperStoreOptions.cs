namespace IdentityServer4.Dapper.Options
{
    public class DapperStoreOptions
    {
        /// <summary>
        /// 是否自动清理token
        /// </summary>
        public bool EnableTokenCleanup { get; set; } = false;
        /// <summary>
        /// 清理token周期 3600秒
        /// </summary>
        public int TokenCleanUpInterval { get; set; } = 3600;
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public string DbConnectStrings { get; set; }
    }
}
