
using System;
using System.Text;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            
           Massiv mas1=new Massiv(11);
            for (int i = 0; i < mas1.Length; i++)
            {
                Console.WriteLine($"{mas1.Arra[i]}");
            }
            Console.WriteLine("---------");
            int[] inpmas=new int[3];
            Massiv mas2 = new Massiv(3, inpmas);
            for (int i = 0; i < mas2.Length; i++)
            {
                Console.WriteLine($"{mas2.Arra[i]}");
            }
            Console.WriteLine("---");
            Massiv mas3 = mas2;
            for (int i = 0; i < mas3.Length; i++)
            {
                Console.WriteLine($"{mas3.Arra[i]}");
            }
            Console.WriteLine("--------");
            //Console.WriteLine(mas3.Length);
            //bool result = mas1 < mas2;
            //Console.WriteLine(result);
            //bool result1 = mas1 >= mas2;
            //Console.WriteLine(result1);
            //Console.WriteLine(mas1 + mas2);
    
            //mas1 = mas1 * 5;
            //for (int i = 0; i < mas1.Length; i++)
            //{
            //    Console.WriteLine(mas1.Arra[i]);
            //}
            StringBuilder sb = new StringBuilder(mas1.Length);
            int len = mas1.Length;
            int[] array = new int[len];
            for(int i = 0; i < len; i++)
            {
                array[i] = mas1.Arra[i];
                Console.WriteLine(array[i]);
                Console.WriteLine("---");
            }
            for(int i = 0; i < mas1.Length; i++)
            {
                sb.Append(array[i]);
            }
            string value = sb.ToString();
            Console.WriteLine(value);
            Console.WriteLine("-----");
            int rec = mas1.RecSum(0);
            Console.WriteLine(rec);
            string val = (string)mas1;
            Console.WriteLine(val);
        }
    }
}
