using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class SecondPart
    {
        private readonly int[,] matrix;

        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + " or " + nameof(cols));
            }

            matrix = new int[rows, cols];

            var random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 11);
                }
            }
        }

        public int[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public int SumColsWithoutNegative() //Cумма элементов в столбцах, которые не содержат отрицательных элементов
        {
            int k = 0;
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int currentSum = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[j, i] < 0) // если столбец содержит отрицательный элемент, пропускаем его
                    {
                        currentSum = 0;
                        k++;
                        break;
                    }
                    currentSum += matrix[j, i];
                }
                sum += currentSum;
            }
            if (k == matrix.GetLength(0))
            {
                throw new Exception("Нет столбцов без отрицательных элементов");
            }
            return sum;
        }

        public int MinSumDiag() //минимум среди сумм модулей элементов диагоналей, параллельных побочной диагонали матрицы
        {
            int minSum = int.MaxValue;
            int matrixLength = matrix.GetLength(0);
            int sum;

            for (int i = 0; i < matrixLength - 2; i++) //перебор сумм диагоналей выше побочной
            {
                sum = 0;
                for (int j = 0; j <= i; j++)
                {
                    sum += Math.Abs(matrix[j, i - j]);
                }
                minSum = Math.Min(minSum, sum);
            }
            for (int i = matrixLength - 1; i >= 1; i--) //перебор сумм диагоналей ниже побочной
            {
                sum = 0;
                for (int j = i; j <= matrixLength - 1; j++)
                {
                    sum += Math.Abs(matrix[j, matrixLength - 1 + i - j]);
                }
                minSum = Math.Min(minSum, sum);
            }
            return minSum;

        }

    }
}
