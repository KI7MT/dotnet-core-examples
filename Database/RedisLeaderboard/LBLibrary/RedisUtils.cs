using System;
using System.Configuration;
using StackExchange.Redis;

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

        public static string SeverHostName => ConfigurationManager.AppSettings["RedisHost"];
        public static int ServerPortNumber => Convert.ToInt32(ConfigurationManager.AppSettings["RedisPort"]);
        public static string ServerPassword => ConfigurationManager.AppSettings["RedisPassword"];

        #endregion

        #region Connection

        //---------------------------------------------------------------------
        // ConnectionMultiplexer is designed to be shared and re-used: one per
        // process, not one per call. It multiplexes every command down a single
        // connection, so creating one per operation is both slower and a leak.
        private static ConnectionMultiplexer connection;
        private static readonly object connectionLock = new object();

        public ConnectionMultiplexer GetConnection()
        {
            if (connection != null && connection.IsConnected) { return connection; }

            lock (connectionLock)
            {
                if (connection == null || !connection.IsConnected)
                {
                    var options = new ConfigurationOptions
                    {
                        EndPoints = { { host, port } },
                        Password = string.IsNullOrEmpty(pw) ? null : pw,
                        AbortOnConnectFail = false,
                        AllowAdmin = true   // required for FlushDatabase
                    };

                    connection = ConnectionMultiplexer.Connect(options);
                }
            }

            return connection;
        }

        #endregion

        #region IDatabase and IServer

        //---------------------------------------------------------------------
        // IDatabase is where commands are issued. IServer is only needed for
        // server-wide operations such as flushing.
        public IDatabase GetDatabase() => GetConnection().GetDatabase();

        public IServer GetServer() => GetConnection().GetServer(host, port);

        #endregion

    } // end class RedisUtils

} // end namespace LCLibrary
