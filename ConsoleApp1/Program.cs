﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

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
                    //TODO: Сделать создание структуры папок
                    //TODO: сделать очистку имени файла от мусорных символов, не равных "." "А-Я" "A-Z"
                    //TODO: сделать транслитерацию названий файла по желанию пользователя
                }
            }
            Console.WriteLine("Книг fb2 найдено: {0}", fb2count);

            Console.ReadLine();
        }
        static void CreateFolders()
        {
            string[] folders = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };

        }

        public string CleanedFileName(string filename)
            
        {
            Regex regex = new Regex("([a-zA-Zа-яА-Я])");
            char[] array = filename.ToCharArray();
            foreach (char ch in array)
            {
               
            }

            filename = filename.Trim();
            return filename;
        }

        public void LoadBookData()
        {
            
        }
        
        static void Main(string[] args)
        {
            Init();   
        }
    }
}