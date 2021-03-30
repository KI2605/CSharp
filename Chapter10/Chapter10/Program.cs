using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Chapter10
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\New folder";

            string[] files = Directory.GetFiles(path);

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".txt"))
                    File.Delete(files[i]);
            }
            string text = "И поэтому все  так произошло";
            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in words)
            {
                Console.WriteLine(str);
            }
            text = text.Trim(new char[] { 'И', 'о' });
            Console.WriteLine(text);
            string t= "Хороший день";
            // обрезаем начиная с третьего символа
            t = t.Substring(2);
            // результат "роший день"
            Console.WriteLine(t);
            // обрезаем сначала до последних двух символов
            t = t.Substring(0, t.Length - 2);
            // результат "роший де"
            Console.WriteLine(t);

            string subString = "Хо";

            t = t.Insert(0, subString);
            Console.WriteLine(t);

            subString = "нь";
            t = t.Insert(10, subString);
            Console.WriteLine(t);

            // индекс последнего символа
            int ind = t.Length - 1;
            // вырезаем последний символ
            t = t.Remove(ind);
            Console.WriteLine(t);

            // вырезаем с третьего єлемента 4 символа
            t = t.Remove(2, 4);
            Console.WriteLine(t);

            t = "Хороший день";
            t = t.Replace("хороший", "плохой");
            Console.WriteLine(t);

            string s1 = "hello";
            string s2 = "world";
            string s3 = s1 + " " + s2; // результат: строка "hello world"
            string s4 = String.Concat(s3, "!!!"); // результат: строка "hello world!!!"

            Console.WriteLine(s4);

            double number = 23.7;
            string result = String.Format("{0:C}", number);
            Console.WriteLine(result); // $ 23.7
            string result2 = String.Format("{0:C2}", number);
            Console.WriteLine(result2); // $ 23.70

            int numb = 23;
            string res = String.Format("{0:d}", numb);
            Console.WriteLine(res); // 23
            string res2 = String.Format("{0:d4}", numb);
            Console.WriteLine(res2); // 0023
            decimal num = 0.1534m;
            Console.WriteLine("{0:P1}", num);// 15.3%
            long ph = 997919444;
            Console.WriteLine(ph.ToString("+38 (0##) ## ## ###"));
            StringBuilder sb = new StringBuilder("Привет мир");
            sb.Append("!");
            sb.Insert(7, "компьютерный ");
            Console.WriteLine(sb);

            // заменяем слово
            sb.Replace("мир", "world");
            Console.WriteLine(sb);

            // удаляем 13 символов, начиная с 7-го
            sb.Remove(7, 13);
            Console.WriteLine(sb);

            // получаем строку из объекта StringBuilder
            string s = sb.ToString();
            Console.WriteLine(s);

            string st = "Бык Тупогуб, тупогубенький бычок, у быка губа бела была тупа";
            Regex regex = new Regex(@"туп(\w*)", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(st);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
            //checking email
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            while (true)
            {
                Console.WriteLine("Введите адрес электронной почты");
                string email = Console.ReadLine();

                if (Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Email подтвержден");
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный email");
                }
            }
        }
    }
}
