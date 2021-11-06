using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HW21
{
    class Program
    {
        /* Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать. 
         * Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом. 
         * Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз. 
         * Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево. 
         * Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно. 
         * Создать многопоточное приложение, моделирующее работу садовников.*/
        static int a;
        static int b;
        static int [,] uch;
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер участка АхВ:\nВведите размер поля по горизонтали:");
            bool result = int.TryParse(Console.ReadLine(), out a);
            if (result)
            {
                Console.WriteLine($"Размер поля по горизонтали {a}");
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Введите число");
            }
            Console.WriteLine("Введите размер поля по вертикали:");
            bool result1 = int.TryParse(Console.ReadLine(), out b);
            if (result)
            {
                Console.WriteLine($"Размер поля по горизонтали {b}");
            }
            else
            {
                Console.WriteLine("Ошибка ввода. Введите число");
            }
            uch = new int[a, b];
            Console.WriteLine("Результаты работы садовников:");
            ThreadStart sad1 = new ThreadStart(sadovnik1);
            Thread threadSad1 = new Thread(sad1);
            threadSad1.Start();
            ThreadStart sad2 = new ThreadStart(sadovnik2);
            Thread threadSad2 = new Thread(sad2);
            threadSad2.Start();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(uch[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        static void sadovnik1()
        {
            for (int i = 0; i < uch.GetLength(0); i++)
            {
                for (int j = 0; j < uch.GetLength(1); j++)
                {
                    if (uch[i, j] == 0)
                        uch[i, j] = 1;
                }
            }
            Thread.Sleep(1);
        }
        static void sadovnik2()
        {
            for (int i = uch.GetLength(0) - 1; i > 0; i--)
            {
                for (int j = uch.GetLength(1)-1; j > 0; j--)
                    if (uch[i, j] == 0)
                        uch[i, j] = -1;
            }
            Thread.Sleep(1);
        }
    }
}