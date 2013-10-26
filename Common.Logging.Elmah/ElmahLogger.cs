using System;
using System.Diagnostics;
using Common.Logging.Factory;
using Elmah;

namespace Common.Logging.Elmah
{
    /// <summary>
    /// ElmahLogger
    /// </summary>
    public class ElmahLogger : AbstractLogger
    {
        private readonly ErrorLog errorLog;
        private readonly LogLevel minLevel;

        /// <summary>
        /// ElmahLogger
        /// </summary>
        public ElmahLogger(LogLevel minLevel, ErrorLog errorLog)
        {
            this.minLevel = minLevel;
            this.errorLog = errorLog;
        }

        #region ILog Members

        /// <summary>
        /// Gets a value indicating whether this instance is trace enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is trace enabled; otherwise, <c>false</c>.
        /// </value>
        public override bool IsTraceEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is debug enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is debug enabled; otherwise, <c>false</c>.
        /// </value>
        public override bool IsDebugEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is info enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is info enabled; otherwise, <c>false</c>.
        /// </value>
        public override bool IsInfoEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is warn enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is warn enabled; otherwise, <c>false</c>.
        /// </value>
        public override bool IsWarnEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is error enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is error enabled; otherwise, <c>false</c>.
        /// </value>
        public override bool IsErrorEnabled
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is fatal enabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is fatal enabled; otherwise, <c>false</c>.
        /// </value>
        public override bool IsFatalEnabled
        {
            get { return true; }
        }

        #endregion ILog Members

        /// <summary>
        /// Actually sends the message to the underlying log system.
        /// </summary>
        /// <param name="logLevel">the level of this log event.</param>
        /// <param name="message">the message to log</param>
        /// <param name="exception">the exception to log (may be null)</param>
        protected override void WriteInternal(LogLevel logLevel, object message, Exception exception)
        {
            if (logLevel >= minLevel)
            {
                Error error;
                if (exception == null)
                {
                    error = new global::Elmah.Error();
                }
                else
                {
                    error = new global::Elmah.Error(exception);
                }

                error.Message = message == null ? null : message.ToString();
                error.Type = logLevel.ToString();
                error.Time = DateTime.Now;
                errorLog.Log(error);
            }
        }
    }
}