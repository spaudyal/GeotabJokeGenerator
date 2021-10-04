﻿using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

using log4net;
using log4net.Config;

namespace Geotab.Core
{
    public static class Logger
    {
        // Ref: https://jakubwajs.wordpress.com/2019/11/28/logging-with-log4net-in-net-core-3-0-console-app/
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Logger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
        public static void LogError(string message, Exception exception = null)
        {
            if (exception == null)
            {
                log.Error(message);
            }
            else
            {
                log.Error(message, exception);
            }
        }

        public static void LogWarning(string message, Exception exception = null)
        {
            if (exception == null)
            {
                log.Warn(message);
            }
            else
            {
                log.Warn(message, exception);
            }
        }

        public static void LogInfo(string message, Exception exception = null)
        {
            if (exception == null)
            {
                log.Info(message);
            }
            else
            {
                log.Info(message, exception);
            }
        }

        public static void Debug(string message, [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            log.Debug(message + " Method: " + methodName + " Line: " + lineNumber.ToString());
        }
    }
}
