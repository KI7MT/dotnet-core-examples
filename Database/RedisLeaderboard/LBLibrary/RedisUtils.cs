using System;
using System.Configuration;
using ServiceStack.Redis;

namespace LBLibrary
{
    /// <summary>
    /// Redis DB Access and Methods
    /// </summary>
    public class RedisUtils
    {
        #region Class Variables and Constructor

        private readonly string host;
        private readonly int port;
        private readonly string pw;

        //---------------------------------------------------------------------
        public RedisUtils(string host, int port, string pw)
        {
            this.host = host;
            this.port = port;
            this.pw = pw;
        }

        #endregion

        #region Redis Hostname, Port, Password via AppConfig

        /// <summary>
        /// Redis Server Host Name via app.config
        /// </summary>
        public static string SeverHostName => ConfigurationManager.AppSettings["RedisHost"];

        /// <summary>
        /// Redis Server Port Number via app.config
        /// </summary>
        public static int ServerPortNumber => Convert.ToInt32(ConfigurationManager.AppSettings["RedisPort"]);

        /// <summary>
        /// Redis Server Passowrd via app.config
        /// </summary>
        public static string ServerPassword => ConfigurationManager.AppSettings["RedisPassword"];

        #endregion

        #region IRedisNativeClient

        public IRedisNativeClient GetNativeClient() => new RedisNativeClient(host, port, pw);

        #endregion

        #region IRedisClient

        public IRedisClient GetClient() => new RedisClient(host, port, pw);

        #endregion

    } // end class RedisUtils

} // end namespace LCLibrary