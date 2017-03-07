using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;

namespace ReplayAnalyzer.Domain
{
    public class ReplayFileParser
    {
        public static List<ReplayKeyPoint> Parse(string filename)
        {
            if (!File.Exists(filename))
                throw new Exception();
            const string jsonFile = "replay.json";
            string json;

            using (var fs = new FileStream(filename, FileMode.Open))
            using (var archive = new ZipArchive(fs, ZipArchiveMode.Read))
            using (var sr = new StreamReader(archive.GetEntry(jsonFile).Open()))
                json = sr.ReadToEnd();
            //json = json.Replace("EQUIPPED_WEAPON", "WEAPON"); //legacy enum name
            return (List<ReplayKeyPoint>)JsonConvert.DeserializeObject(json, typeof(List<ReplayKeyPoint>));
        }
    }
}
