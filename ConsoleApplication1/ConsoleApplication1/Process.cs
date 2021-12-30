using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    internal class Process
    {

        //Код для копирования дирректории
        public static void CopyDir(string input1, string input2)
        {
            Directory.CreateDirectory(input2);
            foreach (string s1 in Directory.GetFiles(input1))
            {
                string s2 = input2 + "\\" + Path.GetFileName(s1);
                File.Copy(s1, s2);
            }
            foreach (string s in Directory.GetDirectories(input1))
            {
                CopyDir(s, input2 + "\\" + Path.GetFileName(s));
            }
        }

        public static void Do(string input)
        {


            switch (input)
            {
                case "copy":
                    Console.WriteLine("(1)Файл или (2)дирректорию? (Нажмите 1 или 2 для выбора)");
                    int ford = Convert.ToInt32(Console.ReadLine());

                    if (ford == 1)
                    {
                        Console.WriteLine("Введите путь, откуда нужно копировать");
                        var input1 = Console.ReadLine();
                        Console.WriteLine("Введите путь, куда нужно копировать");
                        var input2 = Console.ReadLine();
                        File.Copy(input1, input2, true);
                    }
                    else if (ford == 2)
                    {
                        Console.WriteLine("Введите путь, откуда нужно копировать");
                        var input1 = Console.ReadLine();
                        Console.WriteLine("Введите путь, куда нужно копировать");
                        var input2 = Console.ReadLine();
                        CopyDir(input1, input2);
                    }
                    break;
                case "delete":
                    Console.WriteLine("(1)Файл или (2)дирректорию? (Нажмите 1 или 2 для выбора)");
                    int ford1 = Convert.ToInt32(Console.ReadLine());
                    if (ford1 == 1)
                    {
                        Console.WriteLine("Введите путь к файлу, который хотите удалить");
                        string Name = Console.ReadLine();
                        File.Delete(Name);
                        Console.WriteLine("Данный файл удален");
                    }
                    else if (ford1 == 2)
                    {
                        Console.WriteLine("Укажите путь к дирректории, которую хотите удалить");
                        string way = Console.ReadLine();
                        DirectoryInfo dirInfo = new DirectoryInfo(way);
                        dirInfo.Delete(true);
                        Console.WriteLine("Каталог удален");
                    }
                    break;
                case "help":
                    Console.WriteLine("Список команд: copy - копировать файл\\директорию, delete - удалить файл\\дирректорию");
                    break;

            }

        }
        //Вывод дерева каталогов и файлов
        public static void Dir(string input)
        {

            if (Directory.Exists(input))
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(input);

                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(input);

                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("#####################################");
                Info(input);
                Console.WriteLine("#####################################");
            }
        }

        //Получение информации о дирректориии или файле
        public static void Info(string input)
        {
            DirectoryInfo dir = new DirectoryInfo(input);
            FileInfo f = new FileInfo(input);
            Console.WriteLine($"Название:{dir.Name}");
            Console.WriteLine($"Создан:{dir.CreationTime}");
            Console.WriteLine($"Последние изменения:{dir.LastWriteTime}");
            Console.WriteLine($"Атрибуты:{dir.Attributes}");
        }

    }
}
