using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
    }
}
