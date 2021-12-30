using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace ConsoleApplication1
{
    internal class Program
    {
        
        

        //Копирование и удаление каталогов или файлов
        
        

        public static void Main(string[] args)
        {
            string read = File.ReadAllText(@"info.json");
            Console.WriteLine($"В прошлый раз Вы были в деректории - {read}");
            
            do
            {
                
              Console.WriteLine("Введите директорию или команду || Введите help для вывода списка команд" );                
              string input = Console.ReadLine();
              Process.Dir(input);
              Process.Do(input);
              Console.WriteLine("Нажмите любую клавишу для продолжения || Escape, чтобы выйти ");
              File.WriteAllText(@"info.json", input);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.ResetColor();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);


           
        }
    }
}