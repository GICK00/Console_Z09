using System;
using System.IO;

namespace Console_Z09_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("| Вывод не четных строк файла.");
                input();
                
                StreamReader fileRead = new StreamReader(new FileStream("line.txt", FileMode.Open, FileAccess.Read));

                string line;
                int i = 0;
                while ((line = fileRead.ReadLine()) != null)
                {
                    i++;
                    if (i % 2 != 0)
                        Console.WriteLine("| {0}", line);
                }

                Console.WriteLine("| Количество строк в файле {0}", i);
                fileRead.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("|-------------------------------------------------");
                Console.WriteLine("| Файл не найден!");
            }
            catch (Exception e)
            {
                Console.WriteLine("|-------------------------------------------------");
                Console.WriteLine($"| {e.Message}");
            }
        }
        static void input()
        {
            Console.WriteLine("| Создайте файл в каталоге\r\n" + @"| \Console_Z09_2\Console_Z09_2\bin\Debug\net5.0" + "\r\n| Если файл создан, ввведите (Создан)");
            Console.Write("| : ");
            string fileTxT = Convert.ToString(Console.ReadLine());
            if (fileTxT != "Создан")
                throw new Exception("Не верный ввод!");
        } 
    }
}