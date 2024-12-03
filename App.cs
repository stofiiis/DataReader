﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    internal class DataRecord
    {
        public string Id { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public int vek { get; set; }

        public static DataRecord FromCsv(string csvLine)
        {
            string[] data = csvLine.Split(';');
            return new DataRecord
            {
                Id = data[0],
                jmeno = data[1],
                prijmeni = data[2],
                vek = int.Parse(data[3])
            };
        }
    }
    internal class App
    {
        public void FindId()
        {
            Console.Write("Zadejte ID: ");
            string id = Console.ReadLine()!;

            string fileName = "stats.txt";
            string filePath = Path.Combine(AppContext.BaseDirectory, fileName);
            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    DataRecord record = DataRecord.FromCsv(line);
                    if (record.Id == id)
                    {
                        Console.WriteLine($"ID nalezeno: {record.jmeno} {record.prijmeni}");
                        return;
                    }
                }
                Console.WriteLine("ID nebylo nalezeno.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Vyskytla se chyba: {ex.Message}");
            }
        }
    }
}
