using System;
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
            //log4net.Config.XmlConfigurator.Configure();
        }

        public static void LogError(string message, Exception exception = null, [CallerFilePath] string fileName = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            log.Error(FormatMessage(message, methodName, fileName, lineNumber), exception);
        }

        public static void LogWarning(string message, Exception exception = null, [CallerFilePath] string fileName = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            log.Warn(FormatMessage(message, methodName, fileName, lineNumber), exception);
        }

        public static void LogInfo(string message, Exception exception = null, [CallerFilePath] string fileName = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            log.Info(FormatMessage(message, methodName, fileName, lineNumber), exception);
        }

        public static void Debug(string message, [CallerFilePath] string fileName = "", [CallerMemberName] string methodName = "", [CallerLineNumber] int lineNumber = 0)
        {
            log.Debug(FormatMessage(message, methodName, fileName, lineNumber));

        }

        private static string FormatMessage(string message, string methodName, string fileName, int lineNumber)
        {
            return $"{message} [Method: {methodName}(), Line: {lineNumber}, File: {Path.GetFileName(fileName)}]";
        }

    }
}
