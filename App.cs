using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    internal class App
    {
        public void Data()
        {
            string fileName = "stats.txt";
            string filePath = Path.Combine(AppContext.BaseDirectory, fileName);
            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string[] data = line.Split(';');
                    foreach (string item in data)
                    {
                        Console.WriteLine(item.Trim());
                    }
                    Console.WriteLine("----------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Vyskytla se chyba: {ex.Message}");
            }
        }

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
                    string[] data = line.Split(';');
                    if (data.Length > 0 && data[0] == id)
                    {
                        Console.WriteLine($"Nalezený řádek: {line}");
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
