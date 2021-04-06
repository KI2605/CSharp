using System;
namespace ch18_1
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(GetResult(6, 100, 2));

            Console.ReadLine();
        }

        public static double GetResult(int percent, double capital, int year)
        {
            for (int i = 0; i < year; i++)
            {
                capital += capital / 100 * percent;
            }
            return capital;
        }
    }
}
