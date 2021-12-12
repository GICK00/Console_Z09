using System;
using System.IO;

namespace Console_Z09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("| Нахождение не четных чисел в файле\r\n| больше заданного.");
            bool repit = true;
            while (repit == true)
            {
                try
                {
                    Console.WriteLine("| Введите размер последовательности.");
                    Console.Write("| N : ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n <= 0)
                        throw new Exception("Последовательность не может быть меньше 1!");

                    Console.WriteLine("| Введите число от которого будет отсчет.");
                    Console.Write("| M : ");
                    int m = Convert.ToInt32(Console.ReadLine());
                    if (m >= n)
                        throw new Exception("Число M должно быть меньше N!");

                    FileStream file = new("Number.bin", FileMode.Create, FileAccess.Write);
                    BinaryWriter fileOut = new(file);
                    for (int i = 0; i < n; i++)
                    {
                        fileOut.Write(i + 1);
                    }
                    fileOut.Close();

                    file = new FileStream("Number.bin", FileMode.Open, FileAccess.Read);
                    BinaryReader fileIn = new(file);
                    long l = file.Length;
                    Console.Write("| ");
                    for (long i = 0; i < l; i += 8)
                    {
                        if (fileIn.ReadInt32() > m / 2)
                        {
                            file.Seek(i, SeekOrigin.Begin);
                            Console.Write("{0} ", fileIn.ReadInt32());
                        }
                    }
                    Console.WriteLine();
                    fileIn.Close();
                    file.Close();
                    rep(out repit);
                }
                catch (FormatException)
                {
                    Console.WriteLine("|-------------------------------------------------");
                    Console.WriteLine("| Некорректный ввод данных!");
                    rep(out repit);
                }
                catch (Exception e)
                {
                    Console.WriteLine("|-------------------------------------------------");
                    Console.WriteLine($"| {e.Message}");
                    rep(out repit);
                }
            }
        }
        static void rep(out bool repit)
        {
            Console.WriteLine("| Попробовать снова? Да / Нет");
            Console.Write("| : ");
            string repitTxT = Convert.ToString(Console.ReadLine());

            if (repitTxT == "Да")
            {
                repit = true;
                Console.WriteLine("|-------------------------------------------------");
            }
            else if (repitTxT == "Нет")
                repit = false;
            else
            {
                Console.WriteLine("|-------------------------------------------------");
                Console.WriteLine("| Некорректный ввод данных!");
                repit = false;
            }
        }
    }
}