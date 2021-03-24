using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Задачка
Описать класс Array из N целых чисел.
Реализовать в нем операции 
1) конструктор инициализации (один ли несколько) +
2) деструктор
3) конструктор без агрументов +
4) конструктор копирования
5) методы доступа (константные меторы считывания и записи значений) +
6) с помощью перегрузки операторов +
- унарные операторы !, ~, ++, --    
- бинарные операторы +, -, *, /, %  
- операции сравнения ==, !=, <, >, <=, >=
7) индексатор 
8) преобразование типов (например данного класса в строку ) +
9) 2 метода которые считают сумму элементов массива реализованные +
двумя разными способами с помощью рекурсии и без.*/
namespace Task
{
    class Massiv
    {
        //private bool disposed = false;
        private int length;
        private int[] arr;

        public int[] Arra
        {
            get
            {
                return arr;
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
        public Massiv()
        {
            arr = new int[5] { 1, 2, 3, 4, 5 };
        }
        public Massiv(int l, int[] inpval)
        {
            length = l;
            arr = new int[length];
            inpval = new int[Length];
            for(int i = 0; i < Length; i++)
            {
                try
                {
                    inpval[i] = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    inpval[i] = 0;
                    Console.WriteLine($"{inpval[i]}");
                }
            }
            for (int i = 0; i < length; i++)
            {
                arr[i] = inpval[i];
            }
            inpval = null;
        }
        public Massiv(int l)
        {
            length = l;
            arr = new int[length];
            Random r = new Random();
            for (int i = 0; i < length; i++)
            {
                Arra[i] = r.Next(-100, 101);
            }
        }
        public Massiv(Massiv m)
        {
            this.Length = m.Length;
            for (int i = 0; i < m.Length; i++)
            {
                this.Arra[i] = m.Arra[i];
            }
        }
        public static bool operator !(Massiv m)
        {
            return m.Length != 0;
        }
        public static Massiv operator ~(Massiv m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                m.arr[i] = -m.arr[i] - 1;
            }
            return m;
        }
        public static Massiv operator ++(Massiv m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                m.arr[i] = m.arr[i] + 1;
            }
            return m;
        }
        public static Massiv operator --(Massiv m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                m.arr[i] = m.arr[i] - 1;
            }
            return m;
        }
        public static Massiv operator +(Massiv m1, Massiv m2)
        {
            Massiv m3 = new Massiv { Length=m1.Length+m2.Length};
                m1.Arra.CopyTo(m3.arr, 0);
                m2.Arra.CopyTo(m3.arr, m1.Length);
            return m3;
        }
        public static Massiv operator -(Massiv m, int k)
        {
            for (int i = 0; i < m.Length; i++)
            {
                m.Arra[i] -= k;
            }
            return m;
        }
        public static Massiv operator *(Massiv m, int k)
        {
            for (int i = 0; i < m.Length; i++)
            {
                m.Arra[i]*= k;
            }
            return m;
        }
        public static Massiv operator /(Massiv m, int k)
        {
            if (k != 0)
            {
                for (int i = 0; i < m.Length; i++)
                {
                    m.Arra[i] /= k;
                }
            }
            return m;
        }
        public static Massiv operator %(Massiv m, int k)
        {
            if (k != 0)
            {
                for (int i = 0; i < m.Length; i++)
                {
                    m.Arra[i] %= k;
                }
            }
            return m;
        }
        public static bool operator ==(Massiv m1, Massiv m2)
        {
            return m1.Length == m2.Length;
        }
        public static bool operator !=(Massiv m1, Massiv m2)
        {
            return m1.Length != m2.Length;
        }
        public static bool operator >(Massiv m1, Massiv m2)
        {
            return m1.Length > m2.Length;
        }
        public static bool operator <(Massiv m1, Massiv m2)
        {
            return m1.Length < m2.Length;
        }
        public static bool operator >=(Massiv m1, Massiv m2)
        {
            bool flag = true;
            int c = 0;
            if (m1.Length == m2.Length)
            {
                for (int i = 0; i < m1.Length; i++)
            {
                
                    flag = (m1.arr[i] >= m2.arr[i]);
                    if (flag == true)
                    {
                        c += 1;
                    }
                    else
                    {
                        c -= 1;
                    }

                    if (c >= 0)
                    {
                        flag = true;
                    }
                    if (c < 0)
                    {
                        flag = false;
                    }
                }
            }
            else
            {
                flag = false;
                Console.WriteLine("I can't do this, because the size is different");
            }
            return flag;
        }

        public static bool operator <=(Massiv m1, Massiv m2)
        {
            {
                bool flag = true;
                int c = 0;
                if (m1.Length == m2.Length)
                {
                    for (int i = 0; i < m1.Length; i++)
                    {

                        flag = (m1.arr[i] <= m2.arr[i]);
                        if (flag == true)
                        {
                            c += 1;
                        }
                        else
                        {
                            c -= 1;
                        }

                        if (c >= 0)
                        {
                            flag = true;
                        }
                        if (c < 0)
                        {
                            flag = false;
                        }
                    }
                }
                else
                {
                    flag = false;
                    Console.WriteLine("I can't do this, because the size is different");
                }
                return flag;
            }
        }
       public void Sum(Massiv mas)
        {
            int summ = 0;
            for(int i = 0; i < mas.Length; i++)
            {
                summ += mas.Arra[i];
            }
            Console.WriteLine($"Sum of elements is {summ}");
        }
        public int RecSum(int i)
        {
            if (i == this.Length)
            {
                return 0;
            }
            else
            {
                return this.Arra[i] + RecSum(i + 1);
            }
        }
        public static explicit operator string(Massiv mas)
        {
            string val = mas.Length.ToString();
            return val;
        }
        //public void Dispose()
        //{
        //    Dispose(true);
        //    // подавляем финализацию
        //    GC.SuppressFinalize(this);
        //}
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposed)
        //    {
        //        if (disposing)
        //        {
        //            Console.WriteLine("Освобождаем управляемые ресурсы");
        //        }
        //        // освобождаем неуправляемые объекты
        //        disposed = true;
        //    }
        //}

        // Деструктор
        ~Massiv()
        {
            this.arr = null;
            this.length=0;
            Console.WriteLine("Destructor has already done its job");
        }

    }
}
