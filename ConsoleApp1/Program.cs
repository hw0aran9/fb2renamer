using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace fb2renamer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FB2Renamer v. 0.1 готов к работе");
            string currDir = Directory.GetCurrentDirectory();
            string[] fileEntries = Directory.GetFiles(currDir);
            Console.WriteLine(currDir);
            Console.ReadKey();
            foreach (string filename in fileEntries)
            {
                Console.WriteLine(filename);
            }

        }
    }
}
