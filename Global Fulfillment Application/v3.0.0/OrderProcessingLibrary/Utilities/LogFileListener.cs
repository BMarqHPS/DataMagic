namespace OrderProcessingLibrary.Utilities
{
    using System;
    using System.Diagnostics;
    using System.IO;

    public static class LogFileListener
    {
        static LogFileListener()
        {

            _loggingEnabled = AppSettings.LoggingEnabled;
            _logLevel = AppSettings.LoggingLevel;

            if (!_loggingEnabled) return;

            var dateStamp = String.Format("_{0:yyyy-MM-dd hhmm}.", DateTime.Now);
            var logFileName = AppSettings.LogFileName.Replace(".", dateStamp);
            var logFile = File.Create(logFileName);
            var loggingOutput = new TextWriterTraceListener(logFile);
            Trace.Listeners.Add(loggingOutput);
        }

        private static readonly bool _loggingEnabled;
        private static readonly int _logLevel;


        private static void WriteLine(string message)
        {
            WriteLine(message, LogLevel.Normal);
        }

        private static void WriteLine(string message, byte logLevel)
        {
            Trace.WriteLine(String.Format("{0:MM-dd-yyyy hh:mm:ss}  {1}{2}", DateTime.Now,
                                          new string(' ', logLevel*4), message));
        }


        public static string CurrentLogLevel
        {
            get { return _logLevel.ToString(); }
        }

        public static void CloseLog()
        {
            if (!_loggingEnabled) return;

            Trace.Flush();
            Trace.Close();
        }

        public static void Log(string message)
        {
            if (!_loggingEnabled) return;

            WriteLine(message);
        }

        public static void Log(string message, byte logLevel)
        {
            if (!_loggingEnabled) return;

            if (logLevel <= _logLevel)
                WriteLine(message, logLevel);
        }

        public static void LogException(string message)
        {
            if (!_loggingEnabled) return;

            WriteLine("");
            WriteLine(message);
            WriteLine("");
        }

        public static void LogException(Exception ex)
        {
            if (!_loggingEnabled) return;

            WriteLine("");
            WriteLine(ex.Message);
            WriteLine("");
            WriteLine(ex.StackTrace);
            WriteLine("");
        }
    }

    public static class LogLevel
    {
        public const byte Normal = 0;
        public const byte Verbose = 1;
        public const byte Debug = 2;
    }
}
