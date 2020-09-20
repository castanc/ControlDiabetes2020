using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using UtilsSTD;

namespace Business
{
    public class Business
    {
        public string sourcePath = @"c:\glucosecontrol\";
        public string outputPath = @"c:\glucosecontrol\Data\";
        public List<Record> records = new List<Record>();
        public DateTime GlucDate = new DateTime(2020, 1, 9);
        public int initialCount = 0;

        public bool AddRecord(Record r)
        {
            var rec = records.Where(x => x.RecType == r.RecType &&
                x.Date == r.Date).FirstOrDefault();
            if (rec == null)
            {
                r.Id = records.Count;
                records.Add(r);
            }
                
            return rec != null;
        }

        public void MoveToProcessed(string fileName)
        {
            if ( File.Exists(fileName))
            {
                var outputFileName = $"{sourcePath}Processed\\";
                if (!Directory.Exists(outputFileName))
                    Directory.CreateDirectory(outputFileName);

                var newFileName = $"{outputFileName}{Path.GetFileName(fileName)}";
                try
                {
                    if (File.Exists(newFileName))
                    {
                        File.Delete(newFileName);
                    }
                    File.Move(fileName, newFileName);
                }
                catch(Exception ex)
                {

                }


            }
        }

        public List<Record> LoadRecords()
        {
            var fileName = $"{outputPath}ControlDiabetes.json";
            var recs = new List<Record>();
            if ( File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                Utils.JSONDeserializeNewtonSoft<List<Record>>(json, ref recs);
            }
            initialCount = recs.Count;
            return recs;
        }

        public void SaveRecords(List<Record> recs = null, string Name = "")
        {
            if (string.IsNullOrEmpty(Name))
                Name = "ControlDiabetes.json";

            var outFileName = $"{outputPath}{Name}";


            if (recs == null)
                recs = records;

            if (initialCount != recs.Count)
            {
                if (!Directory.Exists(outputPath))
                    Directory.CreateDirectory(outputPath);

                string json = Utils.NewtonSoftJSONSerialize<List<Record>>(
                    recs);
                File.WriteAllText(outFileName, json);
            }
        }
        public void LoadFromResumen(string fileName)
        {
            if (File.Exists(fileName))
            {
                records = LoadRecords();
                var lines = File.ReadAllLines(fileName);
                foreach(var l in lines)
                {
                    var cols = l.Split('\t');
                    /*
                        FOOD	2019-10-30	Wednesday	21:50	1310	34 gr kofler
                      
                     */
                    if ( cols.Length >= 5 )
                    {
                        var r = new Record() { RecType = cols[0] };
                        try
                        {
                            int value = 0;
                            if (r.RecType != "GLUC")
                                r.AdditionalData = cols[5];
                            else
                            {
                                int.TryParse(cols[5], out value);
                                r.Glucose = value;
                            }
                            var dt = cols[1].Split('-');
                            var hr = cols[3].Split(':');
                            DateTime date = new DateTime(
                                Convert.ToInt32(dt[0]),
                                Convert.ToInt32(dt[1]),
                                Convert.ToInt32(dt[2]),
                                Convert.ToInt32(hr[0]),
                                Convert.ToInt32(hr[1]), 0);
                            r.Date = date;
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                            if ( r.Date < GlucDate)
                                AddRecord(r);
                        }
                    }
                }
                SaveRecords();
                MoveToProcessed(fileName);
            }
                
        }

        public void LoadFromCesarRegs(string fileName)
        {
            if (File.Exists(fileName))
            {
                records = LoadRecords();
                var lines = File.ReadAllLines(fileName);
                foreach (var l in lines)
                {
                    var cols = l.Split('\t');
                    /*
                        1	GLUC	2020-07-19	20:44	82	
                        2	FOOD	2020-07-19	21:17	Spaguetiscon tuco, pan, coca light. Papas lays	
                        3	DRUG	2020-07-19	21:17	DIAF	
                        4	DRUG	2020-07-19	21:17	NOVONORM	
                        5	DRUG	2020-07-19	21:17	GLIMEPIRIDA	
                      
                     */
                    if (cols.Length >= 4)
                    {
                        var r = new Record() { RecType = cols[1] };
                        try
                        {
                            int value = 0;
                            if (r.RecType != "GLUC")
                                r.AdditionalData = cols[4];
                            else
                            {
                                int.TryParse(cols[4], out value);
                                r.Glucose = value;
                            }
                            var dt = cols[2].Split('-');
                            var hr = cols[3].Split(':');
                            DateTime date = new DateTime(
                                Convert.ToInt32(dt[0]),
                                Convert.ToInt32(dt[1]),
                                Convert.ToInt32(dt[2]),
                                Convert.ToInt32(hr[0]),
                                Convert.ToInt32(hr[1]), 0);
                            r.Date = date;
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                            if (r.RecType != "GLUC")
                                AddRecord(r);
                            else if (r.RecType == "GLUC" && r.Date < GlucDate)
                                AddRecord(r);

                        }
                    }
                }
                SaveRecords();
                MoveToProcessed(fileName);

            }

        }

        public void LoadFromGlucoseData(string fileName)
        {
            if (File.Exists(fileName))
            {
                records = LoadRecords();
                var lines = File.ReadAllLines(fileName);
                foreach (var l in lines)
                {
                    var cols = l.Split('\t');
                    /*
                        CESAR CASTANO
                        # 59320932
                        LAGY322S00919
                        Time	Record Type	Meal Insulin (units)	Long Acting Insulin (units)	Glucose (mg/dL)	Ketone (mmol/L)	Adjustment Insulin (units)	User Change Insulin (units)
                        09/01/2020 15:48	2			127			
                        10/01/2020 12:34	2			144			
                      
                     */
                    if (cols.Length >= 4)
                    {
                        var r = new Record() { RecType = "GLUC" };
                        try
                        {
                            r.Glucose = Convert.ToInt32(cols[4]);
                            var dtCol = cols[0].Split(' ');
                            var dt = dtCol[0].Split('/');
                            var hr = dtCol[1].Split(':');
                            DateTime date = new DateTime(
                                Convert.ToInt32(dt[2]),
                                Convert.ToInt32(dt[1]),
                                Convert.ToInt32(dt[0]),
                                Convert.ToInt32(hr[0]),
                                Convert.ToInt32(hr[1]), 0);
                            r.Date = date;
                            AddRecord(r);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                SaveRecords();
                MoveToProcessed(fileName);

            }
            
        }

        public void Export(List<Record> recs, string name )
        {
            StringBuilder sb = new StringBuilder();
            foreach(var r in recs)
            {
                sb.AppendLine($"{r.Id}\t{r.RecType}\t{Utils.GetYMDw(r.Date)}\t{Utils.GetHM(r.Date)}\t{r.Glucose}\t{r.AdditionalData}");
            }

            var fileName = $"{outputPath}{name}.txt";
            File.WriteAllText(fileName, sb.ToString());

        }

        public void Split()
        {
            records = LoadRecords();
            List<Record> morning = records.Where(x => x.Date.Hour * 60 + x.Date.Minute < 12 * 60).ToList().OrderBy(x=>x.Date).ToList();
            List<Record> afternoon = records.Where(x => x.Date.Hour * 60 + x.Date.Minute >= 12 * 60).ToList().OrderBy(x=>x.Date).ToList();

            SaveRecords(morning, "ControlDiabetes.Morning.json");
            SaveRecords(afternoon, "ControlDiabetes.Afternoon.json");
            Export(morning, "ControlDiabetes.Morning");
            Export(afternoon, "ControlDiabetes.Afternoon");
        }
    }
}
