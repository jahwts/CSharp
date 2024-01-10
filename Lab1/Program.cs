/*
 * Вариант 4 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            var firstPart = new FirstPart(size);

            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Максимальный элемент массива: " + firstPart.MaxValue());

            Console.Write("Сумма элементов массива до последнего положительного элемента: ");
            try
            {
                Console.WriteLine(firstPart.Sum());
            }
            catch (ArgumentException)
            {
                Console.WriteLine("В массиве нет положительных элементов или положительный элемент имеет индекс 0 ");
            }


            Console.Write("Введите левую границу для сжатия массива: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите правую границу для сжатия массива: ");
            double b = double.Parse(Console.ReadLine());

            firstPart.shrinkArray(a, b);
            Console.WriteLine("Массив после сжатия:");
            PrintVector(firstPart.Vector);


            Console.WriteLine();
            Console.WriteLine("Часть 2:");

            Console.Write("Введите размер матрицы: ");
            size = int.Parse(Console.ReadLine());


            var secondPart = new SecondPart(size, size);
            PrintMatrix(secondPart.Matrix);

            Console.Write("Сумма элементов в столбцах без отрицательных элементов: ");
            try
            {
                Console.WriteLine(secondPart.SumColsWithoutNegative());
            }
            catch (Exception)
            {
                Console.WriteLine("Нет столбцов без отрицательных элементов");
            }

            Console.WriteLine("Минимальная сумма модулей элементов диагоналей: " + secondPart.MinSumDiag());

            Console.ReadLine();
        }

        static void PrintVector(IEnumerable<double> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4, ' ') + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
