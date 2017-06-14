using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

//TODO: сделать очистку имени файла от мусорных символов, не равных "." "А-Я" "A-Z"
//TODO: сделать транслитерацию названий файла по желанию пользователя

namespace fb2renamer
{
    class Program
    {

        static void Init()
        {
            int fb2count = 0;
            string currDir = Directory.GetCurrentDirectory();
            string[] fileEntries = Directory.GetFiles(currDir);
            Console.WriteLine("FB2Renamer v. 0.1 готов к работе");
            Console.WriteLine("Рабочая папка: {0}", currDir);
            Console.WriteLine("Файлов в папке: {0}", fileEntries.Length);
            foreach (string fName in fileEntries)
            {
                if (Path.GetExtension(fName) == ".fb2")
                {
                    fb2count += 1;
                    Console.WriteLine(Path.GetFileName(fName));
                }
            }
            Console.WriteLine("Книг fb2 найдено: {0}", fb2count);

        }
        static void CreateFolders(int param)
        {
            string[] rus_folders = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string currDir = Directory.GetCurrentDirectory();
            switch (param)
            {
                case 0:
                    DeleteEmptyFolders();
                    break;
                case 1:
                    for (int i = 0; i < rus_folders.Length; i++)
                    {
                        string newDir = String.Concat(currDir, "\\Sorted_Books\\", rus_folders[i]);
                        try
                        {
                            Directory.CreateDirectory(newDir);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Ошибка при создании структуры папок:");
                            Console.WriteLine(e);
                            break;
                        }
                    }
                    break;
            }
        }

        static void DeleteEmptyFolders()
        {
            Console.WriteLine("deleted"); 
        }

        static string CleanedFileName(string filename)
            
        {
            Regex regex = new Regex("([a-zA-Zа-яА-Я])");
            char[] array = filename.ToCharArray();
            foreach (char ch in array)
            {
               
            }
            filename = filename.Trim();
            return filename;
        }

        static string NewBookName(string filename)
        {
            string currDir = Directory.GetCurrentDirectory();
            String xmlString = File.ReadAllText(filename);
            XDocument book = XDocument.Load(new StringReader(xmlString)); // передавать сюда вместе с путем ?
            string book_title = book.Root.Element("book-title").ToString();
            string newname = String.Concat(book_title, "-new");
            return book_title;
        }
        
        public void RenameBook()
        {
            
        }

        static void Main(string[] args)
        {
            Console.Title = "FB2 Renamer";
            string currDir = Directory.GetCurrentDirectory();
            Init();
            CreateFolders(1);
            string newname = String.Concat(currDir, "//test.fb2");
            Console.WriteLine(NewBookName(newname));
            Console.ReadLine();
        }
    }
}