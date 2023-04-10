using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CSVHelperDemo
{
    public class Operation
    {
        public static void ImplementCSVHandling()
        {
            List<Model> records= new List<Model>();
            string importFilePath = @"F:\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\csvFile.csv";
            string exportFilePath = @"F:\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\csvFile1.csv";
            using(var reader=new StreamReader(importFilePath))
            using(var csv=new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                records=csv.GetRecords<Model>().ToList();
                Console.WriteLine("reading csv file");
                foreach(var data in records)
                {
                    Console.WriteLine(data.Name+"\n"+data.Email+ "\n"+data.PhoneNumber + "\n" +data.Country);
                }
            }
            using(var writer=new StreamWriter(exportFilePath))
            using(var csvwriter=new  CsvWriter(writer,CultureInfo.InvariantCulture))
            {
                csvwriter.WriteRecords(records);
            }
        }
        public static void ImplementCSVToJson()
        {
            List<Model> records = new List<Model>();
            string importFilePath = @"F:\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\csvFile.csv";
            string exportFilePath = @"F:\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\csvFile2.json";
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<Model>().ToList();
                Console.WriteLine("reading csv file");
                foreach (var data in records)
                {
                    Console.WriteLine(data.Name + "\n" + data.Email + "\n" + data.PhoneNumber + "\n" + data.Country);
                }
            }
            var json = JsonConvert.SerializeObject(records);
            File.WriteAllText(exportFilePath, json);
        }
        public static void ImplementJsonToCSV()
        {
            Console.WriteLine("reading Json file");
            string importFilePath = @"F:\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\csvFile2.json";
            string exportFilePath = @"F:\CSVHelperDemo\CSVHelperDemo\CSVHelperDemo\csvFile3.csv";
            List<Model> records= JsonConvert.DeserializeObject<List<Model>>(File.ReadAllText(importFilePath));
            using(var writer=new StreamWriter(exportFilePath))
            using(var csvwriter=new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvwriter.WriteRecords(records);
            }
        }
    }
}
