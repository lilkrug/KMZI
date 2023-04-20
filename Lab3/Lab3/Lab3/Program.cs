using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            int c = 0;
            while(true)
            {
                Console.WriteLine("Введите номер задания:");
                Console.WriteLine("1- НОД двух чисел");
                Console.WriteLine("2- НОД трёх чисел");
                Console.WriteLine("3- Поиск простых чисел из диапазона");
                Console.WriteLine("4- Проверка на простое");
                Console.WriteLine("5- Повторить п. 1 для интервала [m, n]. Сравнить полученные результаты с «ручными» вычислениями,используя «решето Эратосфена»");
                Console.WriteLine("6- Поиск простых чисел на интервале.Сравнить это число с n/ln(n)");
                Console.WriteLine("7- Записать числа m и n в виде произведения простых множителей");

                if (!int.TryParse(Console.ReadLine(), out c))
                {
                    c = -1;
                }
                switch(c)
                {
                    case 1:
                        {
                            int x = 0, y = 0;
                            Console.Write("Введите первое число: ");
                            if (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.Write("Ошибка!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.Write("Введите второе число: ");
                            if (!int.TryParse(Console.ReadLine(), out y))
                            {
                                Console.Write("Ошибка!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine($"НОД двух чисел ({x},{y}) равен: {NOD.Compute(x,y)} ");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }

                    case 2:
                        {
                            int x = 0, y = 0, z = 0;
                            Console.Write("Введите первое число: ");
                            if (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.Write("Ошибка!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.Write("Введите второе число: ");
                            if (!int.TryParse(Console.ReadLine(), out y))
                            {
                                Console.Write("Ошибка!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.Write("Введите третье число: ");
                            if (!int.TryParse(Console.ReadLine(), out z))
                            {
                                Console.Write("Ошибка!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            Console.WriteLine($"НОД трёх чисел ({x},{y},{z}) равен: {NOD.Compute(z,NOD.Compute(x, y))} ");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }
                    case 3:
                        {
                            int x = 0, y = 0;
                            Console.Write("Введите первое число: ");
                            if (!int.TryParse(Console.ReadLine(), out x))
                            {
                                Console.Write("Ошибка!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            Console.Write("Введите второе число, больше первого: ");
                            if (!int.TryParse(Console.ReadLine(), out y))
                            {
                                Console.Write("Ошибка!");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            NOD.FindSimple(x, y);
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        }
                    case 4:
                        {
                            Console.WriteLine("Первое число: ");
                            int con1 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Второе число: ");
                            int con2 = int.Parse(Console.ReadLine());
                            int newNumber = Convert.ToInt32(string.Format("{0}{1}", con1, con2));
                            Console.WriteLine(newNumber);
                            NOD.proctnumber(newNumber);
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Введите начало интервала: ");
                            uint start1 = uint.Parse(Console.ReadLine());
                            Console.WriteLine("Введите конец интервала: ");
                            uint finish1 = uint.Parse(Console.ReadLine());
                            var primeNumbers = NOD.SieveEratosthenes(start1, finish1 + 1);

                            Console.WriteLine(string.Join(", ", primeNumbers));
                            break;
                        }
                    case 6:
                        {
                            int count = 0;
                            Console.WriteLine("начало интервала 2 ");
                            int start = 2;
                            Console.WriteLine("Введите конец интервала: ");
                            int finish = int.Parse(Console.ReadLine());
                            Console.WriteLine("Простые числа на интервале [{0}, {1}]:", start, finish);
                            for (int i = start; i <= finish; i++)
                            {
                                if (NOD.IsPrimeNumber(i))
                                {
                                    count++;
                                    Console.WriteLine(i);
                                }
                            }
                            Console.WriteLine("Количество простых чисел:{0}", count.ToString());
                            Console.WriteLine("n/ln(n):" + finish / Math.Log(finish));
                            break;
                        }
                    case 7:
                        {
                            NOD.TrialDivision(18);
                            break;
                        }
                    case -1:
                        {
                            Console.Clear();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            break;
                        }
                }
            }
        }
    }
}
