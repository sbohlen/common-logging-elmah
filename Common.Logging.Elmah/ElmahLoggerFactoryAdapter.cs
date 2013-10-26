using System;
using System.Collections.Specialized;
using System.IO;
using Common.Logging.Factory;

namespace Common.Logging.Elmah
{
    /// <summary>
    /// ElmahLoggerFactoryAdapter
    /// </summary>
    public class ElmahLoggerFactoryAdapter : AbstractCachingLoggerFactoryAdapter
    {
        private LogLevel minLevel = LogLevel.All;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="properties"></param>
        public ElmahLoggerFactoryAdapter(NameValueCollection properties)
            : base(true)
        {
            if (properties != null)
            {
                var value = properties["MinLevel"];
                if (!string.IsNullOrEmpty(value))
                {
                    minLevel = (LogLevel)Enum.Parse(typeof(LogLevel), value, true);
                }
            }
        }

        /// <summary>
        /// Get a ILog instance by type name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected override ILog CreateLogger(string name)
        {
            return new ElmahLogger(minLevel, global::Elmah.ErrorLog.GetDefault(null));
        }
    }
}