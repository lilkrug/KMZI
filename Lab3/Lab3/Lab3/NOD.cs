using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    static class NOD
    {
        public static int Compute(int x, int y)
        {
            while (x != 0 && y != 0)
            {
                if (x > y)
                {
                    x -= y;
                }
                else
                {
                    y -= x;
                }
            }
            return Math.Max(x, y);

        }

        private static bool IsSimple(int x)
        {
            for (int i = 2; Math.Pow(i, 2) <= x; i++)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }

            return true;
        }


        public static void FindSimple(int m, int n)
        {
            int counter = 0;
            if (n < m)
            {
                Console.WriteLine("Неверный промежуток");
            }

            Console.Write($"Простые числа интервала [{m},{n}]: ");

            for (int i = m; i <= n; i++)
            {
                if (IsSimple(i))
                {
                    Console.Write(i.ToString() + " ");
                    counter++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Количество простых чисел: {counter}");

        }

        public static void proctnumber(int num)
        {
            bool prost = true;

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    prost = false;
                    break;
                }
            }
            if (prost)
            {
                Console.WriteLine("Число простое");
            }
            else
            {
                Console.WriteLine("Число не простое");
            }
        }
        public static List<uint> SieveEratosthenes(uint n1, uint n)
        {
            var numbers = new List<uint>();
            //заполнение списка числами от 2 до n-1
            for (var i = 2u; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    //удаляем кратные числа из списка
                    numbers.Remove(numbers[i] * j);
                }
            }
            for (int i = 0; i < numbers.Count(); i++)
            {
                if (numbers[i] < n1)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            return numbers;
        }

        public static bool IsPrimeNumber(int n)
        {
            var result = true;
            if (n > 1)
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                    else
                        result = true;
                }
            }
            else
                result = false;
            return result;
        }

        public static List<uint> TrialDivision(uint n)
        {
            uint numd = n;
            var divides = new List<uint>();
            var div = 2u;
            while (n > 1)
            {
                if (n % div == 0)
                {
                    divides.Add(div);
                    n /= div;
                }
                else
                {
                    div++;
                }
            }
            int cout3 = 0;
            int cout2 = 0;
            int cout5 = 0;
            int cout7 = 0;
            string masseg = "";
            foreach (var numbers in divides)
            {
                if (numbers == 3)
                {
                    cout3++;
                }
                if (numbers == 2)
                {
                    cout2++;
                }
                if (numbers == 5)
                {
                    cout5++;
                }
                if (numbers == 7)
                {
                    cout7++;
                }
            }
            if (cout2 > 1)
            {
                masseg = masseg + "2 ^" + cout2 + " * ";
            }
            if (cout3 > 1)
            {
                masseg = masseg + "3 ^" + cout3 + " * ";
            }
            if (cout5 > 1)
            {
                masseg = masseg + "5 ^" + cout5 + " * ";
            }
            if (cout7 > 1)
            {
                masseg = masseg + "5 ^" + cout7 + " * ";
            }
            if (cout2 == 1)
            {
                masseg = masseg + "2 * ";
            }
            if (cout3 == 1)
            {
                masseg = masseg + "3 * ";
            }
            if (cout5 == 1)
            {
                masseg = masseg + "5 * ";
            }
            if (cout7 == 1)
            {
                masseg = masseg + "7 * ";
            }

            masseg = masseg.TrimEnd(' ');
            masseg = masseg.TrimEnd('*');
            masseg = masseg + " = " + numd;
            Console.WriteLine(masseg);
            return divides;
        }
    }
}
