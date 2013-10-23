using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Common.Logging.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Logging.Elmah.Test
{
    [TestClass]
    public class ElmahLoggerFactoryAdapterTest
    {
        [TestMethod]
        public void U__ElmahLogger__Info()
        {
            NameValueCollection collections = new NameValueCollection();
            collections["MinLevel"] = "Info";
            ElmahLoggerFactoryAdapter lfa = new ElmahLoggerFactoryAdapter(collections);

            var logger = lfa.GetLogger("");
            logger.Error("Test");
        }

        [TestMethod]
        public void U__ElmahLogger__Error()
        {
            NameValueCollection collections = new NameValueCollection();
            collections["MinLevel"] = "6";
            ElmahLoggerFactoryAdapter lfa = new ElmahLoggerFactoryAdapter(collections);

            var logger = lfa.GetLogger("");
            logger.Error("Test");
        }

        [TestMethod]
        public void U__ElmahLogger__Config()
        {
            Common.Logging.ILog logger = Common.Logging.LogManager.GetCurrentClassLogger();

            logger.Error("Test");
        }
    }
}