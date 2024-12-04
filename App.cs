using System;
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
        public string bydliste { get; set; }

        public static DataRecord FromCsv(string csvLine)
        {
            string[] data = csvLine.Split(';');
            return new DataRecord
            {
                Id = data[0],
                jmeno = data[1],
                prijmeni = data[2],
                vek = int.Parse(data[3]),
                bydliste = data[4],
            };
        }
    }
    internal class App
    {
        public void FindId()
        {
            while (true)
            {
                Console.Write("Zadejte ID: ");
                string id = Console.ReadLine()!;

                string fileName = "stats.txt";
                string filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                bool idFound = false;

                try
                {
                    foreach (string line in File.ReadLines(filePath))
                    {
                        DataRecord record = DataRecord.FromCsv(line);
                        if (record.Id == id)
                        {
                            idFound = true;
                            Console.WriteLine($"ID nalezeno: {record.jmeno} {record.prijmeni}");
                            Console.WriteLine("Chceš více informací? y/n");
                            string info = Console.ReadLine()!;
                            if (info == "y" || info == "Y")
                            {
                                Console.WriteLine($"Věk: {record.vek}");
                                Console.WriteLine($"Bydliště: {record.bydliste}");
                            }
                            else
                            {
                                Console.WriteLine("Oka");
                            }
                            break;
                        }
                    }

                    if (!idFound)
                    {
                        Console.WriteLine("ID nebylo nalezeno.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Vyskytla se chyba: {ex.Message}");
                }
            }
        }
    }
}
