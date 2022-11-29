namespace LR7InformationSecurity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choise = 10;
            do
            {

                if (choise == 1)
                {
                    Console.WriteLine("НСД");
                    Console.Write("A = ");
                    var a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("B = ");
                    var b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Найбiльший спiльний дiльник чисел {0} i {1} дорiвнює {2}", a, b, GreatestCommonDivisor(a, b));
                }
                else if (choise == 2)
                {
                    Console.WriteLine("НСК");
                    Console.Write("A = ");
                    var a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("B = ");
                    var b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Найменше спiльне кратне чисел {0} i {1} дорiвнює {2}", a, b, NOK(a, b));
                }
                else if (choise == 3)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    Console.Write("a = ");
                    var a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("m = ");
                    var b = Convert.ToInt32(Console.ReadLine());
                    IterationMethod(a, b);
                }
                else if (choise == 4)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    Console.Write("a = ");
                    var a = long.Parse(Console.ReadLine());
                    Console.Write("m = ");
                    var b = long.Parse(Console.ReadLine());
                    ExtensionsEuclidAlgorithm(a, b);
                }
                else if (choise == 5)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    Console.Write("a = ");
                    var a = long.Parse(Console.ReadLine());
                    Console.Write("k = ");
                    var k = long.Parse(Console.ReadLine());
                    Console.Write("n = ");
                    var n = long.Parse(Console.ReadLine());
                    SequentialSquaringAlgorithm(a, k, n);
                }
                Console.WriteLine("Виберiть пункт меню:");
                Console.WriteLine("1)Знайти НСД");
                Console.WriteLine("2)Знайти НСК");
                Console.WriteLine("3)Метод перебору");
                Console.WriteLine("4)Розширений алгоритм Евклiда");
                Console.WriteLine("5)Послiдовне зведення в квадрат");
                Console.WriteLine("6)Вийти iз програми");
            } while (!int.TryParse(Console.ReadLine(), out choise) || choise != 6 || (choise == 1 || choise == 2 || choise == 3 || choise == 4 || choise == 5));

        }
        static public int GreatestCommonDivisor(int a, int b)
        {
            if (a > b)
            {
                (b, a) = (a, b);
            }
            int temp;
            while (b != 0)
            {
                temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }
        static int NOK(int a, int b)
        {
            if (a > b)
            {
                (b, a) = (a, b);
            }
            return a * b / GreatestCommonDivisor(a, b);
        }
        static public void IterationMethod(long a, long m)
        {
            long x1 = 0;
            long x = 1;
            long k2;
            long k;
            long i = 0;
            do
            {
                i++;
                if ((a * i) % m == 1) { x1 = i; break; }

            } while ((a * i) % m != 1);

            Console.WriteLine($"Вiдповiдь: x = {x1}");

            k = a * x1;
            Console.WriteLine($"Розрахунки");
            Console.WriteLine($"k = {k}");


            k2 = (int)(k / m);

            x = a * x1 - m * k2;

            Console.WriteLine($"{a}*{x1}-{m}*{k2} = {x}");
        }
        public static void ExtensionsEuclidAlgorithm(long a, long m)
        {
            List<long> listP = new List<long>();
            List<long> listQ = new List<long>();
            List<long> listR = new List<long>();
            int i = 2;
            listP.Add(1);
            listQ.Add(((long)m / a));
            listP.Add(listQ[0]);
            listR.Add(Math.Abs((((long)m / a) * a - m)));
            listQ.Add(((long)a / listR[0]));
            listR.Add((Math.Abs((listR[0] * (a / listR[0]) - a))));
            do
            {

                if (listR[i - 1] != 0)
                {
                    listR.Add((listR[i - 1] * (listR[i - 2] / listR[i - 1]) - (listR[i - 2])) * (-1));
                    listQ.Add((long)listR[i - 2] / listR[i - 1]);
                }
                else
                {
                    listR.Add(0);
                    listQ.Add(listR[i - 2] / 1);
                }

                listP.Add(listQ[i - 1] * listP[i - 1] + listP[i - 2]);
                i++;
            } while (listP[i - 1] != m);
            DisplayMatrix<long>(listP);
            double result = -1 * Math.Pow(-1, i - 1) * listP[i - 2];

            if (result < 0)
            {
                Console.WriteLine($"Число х є вiдємним, тодi необхiдно знайти його вiдображення: тобто m + x: {m}{result}");
                Console.WriteLine($"Розвязком рiвняння є число {m + result}");
            }
            else
            {
                Console.WriteLine($"Розвязком рiвняння є число {result}");
            }
        }
        public static void SequentialSquaringAlgorithm(long a, long k, long n)
        {
            List<double> listA = new List<double>();
            List<double> listB = new List<double>();
            List<double> listK = new List<double>();
            string str = ReverseString(Convert.ToString(k, 2));
            //Console.WriteLine(str);

            listA.Add(a);
            if (str[0] == '1')
            {
                listB.Add(a);
            } else
            {
                listB.Add(1);
            }
            
            for (int i = 1; i < str.Length; i++)
            {
                listA.Add(Math.Pow(listA[i-1],2) % n);
                if (str[i] == '1')
                {
                    listB.Add((listA[i]* listB[i-1]) % n);
                } else
                {
                    long res = (long)listB[i - 1];
                    listB.Add(res);
                }
                
            }
            DisplayMatrix<double>(listA, "A");
            DisplayMatrix<double>(listB, "B");
            Console.WriteLine("Відповiдь: " + listB.Last());
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public static void DisplayMatrix<T>(IList<T> list, string message = "P")
        {
            int i = 0;
            foreach (T item in list)
            {
                System.Console.Write($"{message}({i++}) = "+item?.ToString() + ";  ");
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
        }
        
    }
}
