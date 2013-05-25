namespace OrderProcessingLibrary.Utilities
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Reflection;

    using Logger = LogFileListener;

    public static class AppSettings
    {
        private static readonly NameValueCollection appSettings = ConfigurationManager.AppSettings;

        private static readonly Version appVersion = Assembly.GetExecutingAssembly().GetName().Version;


        public static string AppPath { get; set; }

        public static string ConnectionString { get; set; }

        public static string LogFileName { get; set; }

        public static bool LoggingEnabled { get; set; }

        public static int LoggingLevel { get; set; }

        public static int Major { get { return appVersion.Major; } }

        public static int Minor { get { return appVersion.Minor; } }

        public static int PackageID { get; set; }

        public static string UPSPackageFile { get; set; }

        public static string UPSManifestFile { get; set; }

        public static string USMailPackageFile { get; set; }

        public static string USMailManifestFile { get; set; }

        public static string UserID { get { return Environment.UserName; } }


        private static string FileNameOnly(string fullPathFileName)
        {
            var lastSlashPosition = fullPathFileName.LastIndexOf(@"\", StringComparison.Ordinal);
            return fullPathFileName.Substring(lastSlashPosition + 1);
        }

        public static string UPSPackageFileName()
        {
            return FileNameOnly(UPSPackageFile);
        }

        public static string UPSManifestFileName()
        {
            return FileNameOnly(UPSManifestFile);
        }

        public static string USMailPackageFileName()
        {
            return FileNameOnly(USMailPackageFile);
        }

        public static string USMailManifestFileName()
        {
            return FileNameOnly(USMailManifestFile);
        }

        public static void Load()
        {
            AppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);

            if (appSettings["ConnectionString"] != null)
                ConnectionString = appSettings.Get("ConnectionString");
            else
                throw new Exception("No connection string is available for communications with the database!");

            if (appSettings["PackageID"] != null)
                PackageID = int.Parse(appSettings.Get("PackageID"));

            if (appSettings["USMailPackage"] != null)
                USMailPackageFile = appSettings.Get("USMailPackage");

            if (appSettings["USMailManifest"] != null)
                USMailManifestFile = appSettings.Get("USMailManifest");

            if (appSettings["UPSPackage"] != null)
                UPSPackageFile = appSettings.Get("UPSPackage");

            if (appSettings["UPSManifest"] != null)
                UPSManifestFile = appSettings.Get("UPSManifest");

            LoggingEnabled = appSettings.Get("LoggingEnabled") == null || bool.Parse(appSettings.Get("LoggingEnabled"));

            LogFileName = appSettings.Get("LogFileName") ?? "OrderProcessing.log";

            LoggingLevel = appSettings.Get("LoggingLevel") != null ? byte.Parse(appSettings.Get("LoggingLevel")) : 0;

            Logger.Log(String.Format("Application starting (v{0}.{1})...", Major, Minor), LogLevel.Normal);
            Logger.Log("Application settings:", LogLevel.Verbose);
            Logger.Log(String.Format("   USMailManifest - {0}", USMailManifestFile), LogLevel.Verbose);
            Logger.Log(String.Format("   USMailPackage - {0}", USMailPackageFile), LogLevel.Verbose);
            Logger.Log(String.Format("   UPSManifest - {0}", UPSManifestFile), LogLevel.Verbose);
            Logger.Log(String.Format("   UPSPackage - {0}", UPSPackageFile), LogLevel.Verbose);
            Logger.Log(String.Format("   PackageID - {0}", PackageID), LogLevel.Verbose);
            Logger.Log(String.Format("   LogFileName - {0}", LogFileName), LogLevel.Verbose);
            Logger.Log(String.Format("   LoggingLevel - {0}", LoggingLevel), LogLevel.Verbose);
        }

        public static void Save()
        {

            if (appSettings["PackageID"] == null)
                appSettings.Add("PackageID", PackageID.ToString());
            else
                appSettings.Set("PackageID", PackageID.ToString());

            if (appSettings["USMailPackage"] == null)
                appSettings.Add("USMailPackage", USMailPackageFile);
            else
                appSettings.Set("USMailPackage", USMailPackageFile);

            if (appSettings["USMailManifest"] == null)
                appSettings.Add("USMailManifest", USMailManifestFile);
            else
                appSettings.Set("USMailManifest", USMailManifestFile);

            if (appSettings["UPSPackage"] == null)
                appSettings.Add("UPSPackage", UPSPackageFile);
            else
                appSettings.Set("UPSPackage", UPSPackageFile);

            if (appSettings["UPSManifest"] == null)
                appSettings.Add("UPSManifest", UPSManifestFile);
            else
                appSettings.Set("UPSManifest", UPSManifestFile);

            if (appSettings["LoggingEnabled"] == null)
                appSettings.Add("LoggingEnabled", LoggingEnabled.ToString());
            else
                appSettings.Set("LoggingEnabled", LoggingEnabled.ToString());

            if (appSettings["LogFileName"] == null)
                appSettings.Add("LogFileName", LogFileName);
            else
                appSettings.Set("LogFileName", LogFileName);

            if (appSettings["LoggingLevel"] == null)
                appSettings.Add("LoggingLevel", LoggingLevel.ToString());
            else
                appSettings.Set("LoggingLevel", LoggingLevel.ToString());

            //       ' Save the changes.
            //       _cfg.Save()
        }
    }
}
