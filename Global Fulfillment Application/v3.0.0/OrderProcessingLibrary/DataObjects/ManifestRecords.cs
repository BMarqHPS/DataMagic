namespace OrderProcessingLibrary.DataObjects
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using Exceptions;
    using Utilities;
    using Logger = Utilities.LogFileListener;
    using Settings = Utilities.AppSettings;

    public class ManifestRecords : Dictionary<string, ManifestRecord>
    {
        private int upsLinesIn;
        private int usMailLinesIn;


        public int MatchedPackageCount { get; private set; }

        public int UnmatchedPackageCount { get; private set; }


        public void LoadFiles()
        {
            var upsManifest = Settings.UPSManifestFile;
            var usMailManifest = Settings.USMailManifestFile;
            var currentFile = "";

            Logger.Log("Verifying manifest files exist...", LogLevel.Verbose);

            if (!File.Exists(upsManifest))
                throw new MissingFileException(upsManifest);
            Logger.Log(upsManifest + " verified.", LogLevel.Verbose);

            if (!File.Exists(usMailManifest))
                throw new MissingFileException(usMailManifest);
            Logger.Log(usMailManifest + " verified.", LogLevel.Verbose);

            try
            {
                // ReSharper disable PossibleNullReferenceException
                string lineIn;
                var headerSkipped = false;
                ManifestRecord rec;
                ManifestRecord dummy;

                Logger.Log("Loading records from UPS manifest file...", LogLevel.Verbose);
                currentFile = Settings.UPSManifestFileName();
                using (var sr = new StreamReader(upsManifest))
                {
                    while (!sr.EndOfStream)
                    {
                        lineIn = sr.ReadLine().Trim().Replace("\"", "");
                        if (String.IsNullOrEmpty(lineIn)) continue;

                        if (!headerSkipped)
                        {
                            headerSkipped = true;
                            continue;
                        }

                        rec = new ManifestRecord(lineIn, "UPS");
                        if (!TryGetValue(rec.Key, out dummy))
                        {
                            Add(rec.Key, rec);
                            upsLinesIn++;
                            Logger.Log("Added ManifestRecord " + rec.Key, LogLevel.Debug);
                        }
                    }
                }

                Logger.Log(String.Format("Loaded {0} records from UPS manifest file...", upsLinesIn), LogLevel.Verbose);

                Logger.Log("Loading records from USPS manifest file...", LogLevel.Verbose);
                currentFile = Settings.USMailManifestFileName();
                using (var sr = new StreamReader(usMailManifest))
                {
                    while (!sr.EndOfStream)
                    {
                        lineIn = sr.ReadLine().Trim().Replace("\"", "");
                        if (String.IsNullOrEmpty(lineIn)) continue;

                        rec = new ManifestRecord(lineIn, "USPS");
                        if (!TryGetValue(rec.Key, out dummy))
                        {
                            Add(rec.Key, rec);
                            usMailLinesIn++;
                            Logger.Log("Added ManifestRecord " + rec.Key, LogLevel.Debug);
                        }
                    }
                }

                Logger.Log(String.Format("Loaded {0} records from USPS manifest file...", usMailLinesIn),
                           LogLevel.Verbose);
                // ReSharper restore PossibleNullReferenceException
            }
            catch (IndexOutOfRangeException)
            {
                throw new ProcessManifestsException(currentFile + "does not appear to be in the correct format.", null);
            }
            catch (Exception ex)
            {
                throw new ProcessManifestsException("An exception occurred while loading the records from " + currentFile, ex);
            }
        }

        public void SynchronizePackages(OrdersToPackages xref, UpdateRecords updates)
        {
            ManifestRecord manifestRec = null;

            foreach (XmlNode pkgNode in xref.FirstChild.ChildNodes)
            {
                // ReSharper disable PossibleNullReferenceException
                var key = pkgNode.Attributes["Key"].Value;
                if (ContainsKey(key))
                    manifestRec = base[key];
                else
                {
                    foreach (XmlNode orderNode in pkgNode.FirstChild.ChildNodes)
                    {
                        key = orderNode.Attributes["OrderNumber"].Value + "_" +
                              orderNode.Attributes["OrderItemID"].Value;
                        if (ContainsKey(key))
                        {
                            manifestRec = base[key];
                            break;
                        }
                    }
                }

                if (manifestRec == null)
                {
                    UnmatchedPackageCount++;
                    Logger.Log("   **** Unable to sync package '" + pkgNode.Attributes["ID"].Value +
                               "' with shipping info *****");
                    foreach (XmlNode orderNode in pkgNode.SelectSingleNode("Orders").ChildNodes)
                    {
                        Logger.Log(
                            String.Format("/tOrderID: {0}, OrderItemID: {1}", orderNode.Attributes["OrderID"].Value,
                                          orderNode.Attributes["OrderItemID"]), LogLevel.Debug);
                    }
                }
                else
                {
                    MatchedPackageCount++;
                    Logger.Log("Syncing shipping information for '" + manifestRec.Key + " and package '" +
                               pkgNode.Attributes["ID"].Value + "'", LogLevel.Verbose);
                    foreach (XmlNode orderNode in pkgNode.SelectSingleNode("Orders").ChildNodes)
                    {
                        updates.AddUpdateRecord(manifestRec, orderNode);
                    }
                    updates.AddOrderID(manifestRec.OrderId);
                }

                manifestRec = null;
                // ReSharper restore PossibleNullReferenceException
            }
        }
    }
}
