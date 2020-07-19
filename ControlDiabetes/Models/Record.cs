using System;
using System.Collections.Generic;
using System.IO;
using Utils;

namespace Models
{
    public class Record
    {
        public string RecordType { set; get; }
        public int Id { set; get; }
        public string Date { set; get; }
        public string Time { set; get; }
        public Minutes Minutes { set; get; }
        public string Data { set; get; }
        public DateTime DateTaken { set; get; }
        public string Dow { set; get; }
        public string RawData { set; get; }
        public string[] DOW = { "SUN", "MON", "TUE", "WED", "THR", "FRI", "SAT" };

            


        public int result = 0;


        public Record(string data)
        {
            var cols = data.Split('\t');
            if ( cols.Length > 3 )
            {
                try
                {
                    Date = cols[2];
                    Time = cols[3];
                    RecordType = cols[1];
                    Data = cols[4];
                    var dt = Date.Split('-');
                    var hr = Time.Split(':');
                    DateTaken = new DateTime(Convert.ToInt32(dt[0]), Convert.ToInt32(dt[1]), Convert.ToInt32(dt[2]),
                        Convert.ToInt32(hr[0]), Convert.ToInt32(hr[1]),0);
                    Minutes = new Minutes(hr);
                    Dow = DOW[(int)DateTaken.DayOfWeek];
                    RawData = $"{RecordType}\t{Date}\t{DateTaken.DayOfWeek}\t{Time}\t{Minutes.Mins}\t{Data}";

                }
                catch (Exception ex)
                {
                    result = -1;          
                }
            }
        }


        public static List<Record> LoadFile(string fileName)
        {
            var list = new List<Record>();
            if (File.Exists(fileName))
            {
                var lines = File.ReadAllLines(fileName);
                foreach(string l in lines)
                {
                    var r = new Record(l);
                    if (r.result == 0 )
                    {
                        r.Id = list.Count;
                        list.Add(r);
                    }
                }
            }
            return list;
            
        }
    }
}
