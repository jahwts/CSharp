using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class FirstPart
    {
        private readonly double[] array;

        public FirstPart(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var random = new Random();

            array = new double[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.NextDouble() * 20 - 10;
            }
        }

        public IReadOnlyList<double> Vector
        {
            get
            {
                return array;
            }
        }

        public double MaxValue() //метод для поиска максимального значения в массиве
        {
            double max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max; //возвращает максимальное значение в массиве
        }

        public double Sum() //сумма элементов до последнего положительного элемента
        {
            int Lp = IndexOfLastPositive(); //переменная, в которую заносится индекс последнего положительного элемента
            if (Lp > 0) //если индекс отрицательный или равен 0, то по заданию сумма не ищется
            {
                double sum = 0; //переменная для суммирования
                for (int i = 0; i < Lp; i++) //уикл от первого элемента до последнего положительного (не включая)
                {
                    sum += array[i]; //суммирование элементов
                }
                return sum; //метод возвращает искомую сумму
            }
            else
            {
                throw new ArgumentException("В массиве нет положительных элементов или положительный элемент имеет индекс 0"); //если положительных элементов нет, или у него индекс 0, сумма не ищется
            }
        }

        public int IndexOfLastPositive() //индекс последнего положительного элемента
        {
            for (int i = array.Length - 1; i >= 0; i--) //от последнего элемента перебираем
            {
                if (array[i] > 0) return i; //если найден положительный элемент, возвращаем его индекс
            }
            return -1; //если положительные элементы не найдены, возвращаем -1 (отрицательный индекс)
        }


        public void shrinkArray(double a, double b) //Сжатие массива с удалением из него всех элементов, модуль которых находится в интервале [а, b]. Освободившиеся в конце массива элементы заполняются нулями

        {
            int k = 0; // счетчик для нового массива
            for (int i = 0; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) < a || Math.Abs(array[i]) > b)
                {
                    array[k] = array[i];
                    k++;
                }
            }
            for (int i = k; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }
    }
}
