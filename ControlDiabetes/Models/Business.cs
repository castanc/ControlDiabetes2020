using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Models;
using Utils;
using Newtonsoft.Json;

namespace Models
{
    public class Business
    {
        public string BaseFolder = @"C:\MyWorks\COntrolDIabetis\";


        public string Report(string recordType, List<Record> list, string hourStart, string hourEnd)
        {
            string data = "";
            Minutes start = new Minutes(hourStart);
            Minutes end = new Minutes(hourEnd);
            string prefix = "";


            StringBuilder sb = new StringBuilder();
            if (recordType == "ALL")
            {
                var recs = list.Where(x=>x.Minutes.Mins >= start.Mins && x.Minutes.Mins <= end.Mins).ToList().OrderBy(x => x.DateTaken);
                foreach (var r in recs)
                {
                    sb.AppendLine(r.RawData);
                }

            }
            else
            {
                var recs = list.Where(x => x.RecordType == recordType && x.Minutes.Mins >= start.Mins && x.Minutes.Mins <= end.Mins).ToList().OrderBy(x => x.DateTaken);
                foreach (var r in recs)
                {
                    sb.AppendLine(r.RawData);
                }
            }
            data = sb.ToString();
            prefix = $"{start.Hour}_{start.Min}-{end.Hour}_{end.Min}";
            string fileName = $"{BaseFolder}{recordType}_{prefix}.txt";
            File.WriteAllText(fileName, data);
            fileName = $"{BaseFolder}{recordType}_{prefix}.json";
            //var json = JsonConvert.SerializeObject((List<Record>)recs);
            //File.WriteAllText(json, fileName);

            return fileName;
        }



        public void Load()
        {
            string fileName = $"{BaseFolder}2019-202007.txt";
            var list = Record.LoadFile(fileName);


            string recType = "GLUC";

            //Report(recType, list, "0:0", "11:59");
            Report("ALL", list, "0:0", "23:59");





        }
    }
}
