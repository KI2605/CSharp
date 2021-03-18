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
			int s=0;
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
                }
                //else if()
            }
            Console.WriteLine($"Name {name} Age {age}");
        }
        static void Main(string[] args)
        {
            Myself();
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

            int x = 4;                 // 00001100
            Console.WriteLine(~x);      // 11110011   или -13


            
        }
    }
}
