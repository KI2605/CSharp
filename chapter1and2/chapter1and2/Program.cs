using System;

namespace chapter1and2
{
    class Program
    {
        static void Myself()
        {
            Console.WriteLine("input your name");
            string name = Console.ReadLine();
            Console.WriteLine("input your age");
            int age = Convert.ToInt32(Console.ReadLine());
            int flag = 0;
            int s = 0;
            while (flag != 1)
            {
                if (age > 0 && age < 256)
                {
                    age = (byte)age;
                    Console.WriteLine("+");
                    flag += 1;
                }
                else if (age < 0)
                {
                    Console.WriteLine("Please write your age without -");
                    age = Convert.ToInt32(Console.ReadLine());
                    s++;
                }
                else if (age > 256)
                {
                    Console.WriteLine("nice joke,please write your real age");
                    age = Convert.ToInt32(Console.ReadLine());
                    s++;
                }
                if (s == 7)
                {
                    Console.WriteLine("I am offened, Have a nice day!");
                    break;
                }
            }
            Console.WriteLine($"Name {name} Age {age}");
        }
        static void SortMas()
        {
            int[] nums = new int[7];
            Console.WriteLine("Введите семь чисел");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("{0}-е число: ", i + 1);
                nums[i] = Int32.Parse(Console.ReadLine());
            }

            // сортировка
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }

            // вывод
            Console.WriteLine("Вывод отсортированного массива");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }


        static void Rect(in int x,in int y,out int Perim,out int Square,ref string f)
        {
            f = "I don't like this figure";
            Perim = (x + y) * 2;
            Square = x * y;
        }


        static void Calc(params int[] ar)
        {
            int res = 0;
            for(int i = 0; i < ar.Length; i++)
            {
                res += ar[i];
            }
            Console.WriteLine(res);
        }


        static void Main(string[] args)
        {
            // SortMas();
            //Myself();
            //int x2 = 5;
            //int z2 = x2--; // z2=5; x2=4
            //Console.WriteLine($"{x2} - {z2}");

            //int x2 = 4; //100
            //int y2 = 5; //101
            //Console.WriteLine(x2 & y2); // выведет 4

            //int x2 = 4; //100
            //int y2 = 5;//101
            //Console.WriteLine(x2 | y2); // выведет 5 - 101

            //int x = 45; // Значение, которое надо зашифровать - в двоичной форме 101101
            //int key = 102; //Пусть это будет ключ - в двоичной форме 1100110
            //int encrypt = x ^ key; //Результатом будет число 1001011 или 75
            //Console.WriteLine("Зашифрованное число: " + encrypt);

            //int decrypt = encrypt ^ key; // Результатом будет исходное число 45
            //Console.WriteLine("Расшифрованное число: " + decrypt);

            //int x = 4;                 // 00001100
            //Console.WriteLine(~x);      // 11110011   или -13

            //Console.WriteLine("-----------\n");


            // int i= -1;
            //do
            //{
            //    Console.WriteLine(i);
            //    i--;
            //}
            //while (i > 0);

            //for(int i = 0; i < 10; i++)
            //{
            //    if (i == 6)
            //        continue;           
            //        Console.WriteLine(i*i);   
            //}

            //arrs
            /*ELEMENTS THAT BIGGER THAN 0 IN ARRAY*/
            //int[] arr=new int[10];
            //int count = 0;
            //for(int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //foreach(int number in arr)
            //{
            //    if (number > 0)
            //    {
            //        count++;
            //    }
            //}
            //Console.WriteLine($"Count of elements,that are bigger than 0 is {count}");


            ///*flip an array*/
            //int i;
            //int[] arr = new int[2];
            //int middle = arr.Length / 2;
            //for (i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //i = 0;
            //do
            //{
            //    int tmp = arr[i];
            //    arr[i] = arr[arr.Length - i - 1];
            //    arr[arr.Length - i - 1] = tmp;
            //    i++;
            //}
            //while (i != middle);


            //foreach (int numb in arr)
            //{
            //    Console.WriteLine(numb);
            //}

            //int[][] numbers = new int[3][];
            //numbers[0] = new int[2];
            //numbers[1] = new int[] { 1, 2, 3 };
            //numbers[2] = new int[] { 1, 2, 3, 4, 5 };
            //for(int i = 0; i < numbers[0].Length; i++)
            //{
            //    numbers[0][i] = Convert.ToInt32(Console.ReadLine());
            //}
            //foreach (int[] row in numbers)
            //{
            //    foreach (int number in row)
            //    {
            //        Console.Write($"{number} \t");
            //    }
            //    Console.WriteLine();
            //}

            //// перебор с помощью цикла for
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    for (int j = 0; j < numbers[i].Length; j++)
            //    {
            //        Console.Write($"{numbers[i][j]} \t");
            //    }
            //    Console.WriteLine();
            //}

            //int x = 10;
            //int y = 5;
            // string f = "I like this figure";
            //Rect(x,y,out int Perim,out int Square, ref f);
            //Console.WriteLine($"Perimetr{Perim}");
            //Console.WriteLine($"stroka={f}");
            Calc(1,2,7,8);


        }
    }
}
