using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;

namespace Chapter21
{
    class Program
    {

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo d in drives)
            {
                Console.WriteLine($"Name: {d.Name}");
                Console.WriteLine($"Type: {d.DriveType}");
                if (d.IsReady)
                {
                    Console.WriteLine($"Size: {d.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {d.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {d.VolumeLabel}");
                }
                Console.WriteLine();
            }
            string dirName = "D:\\";
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach(string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
               
            }
            string path = "D:\\info";
            string subpath = @"program\avalon";

            DirectoryInfo info = new DirectoryInfo(path);
            if (!info.Exists)
            {
                info.Create();
            }
            info.CreateSubdirectory(subpath);

            DirectoryInfo directory = new DirectoryInfo(path);

            Console.WriteLine($"Название каталога: {directory.Name}");
            Console.WriteLine($"Полное название каталога: {directory.FullName}");
            Console.WriteLine($"Время создания каталога: {directory.CreationTime}");
            Console.WriteLine($"Корневой каталог: {directory.Root}");

            string newpath = "D:\\info\\program";
            try
            {
                DirectoryInfo directory1 = new DirectoryInfo(newpath);
                directory1.Delete(true);
                Console.WriteLine("Каталог удален");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            DirectoryInfo info2 = new DirectoryInfo(path);
            if (!info2.Exists)
            {
                info2.Create();
            }
            info2.CreateSubdirectory(subpath);


            string oldpath = "D:\\info\\program";
            string newpath2 = "D:\\New";
            DirectoryInfo info3 = new DirectoryInfo(oldpath);
            if (info3.Exists && Directory.Exists(newpath2) == false)
            {
                info3.MoveTo(newpath2);
            }

            string filepath = "D:\\New\\hello.py";
            FileInfo file = new FileInfo(filepath);
            if (file.Exists == false)
            {
                file.Create();
            }
            else
            {
                Console.WriteLine("Файл существует");
                Console.WriteLine($"Имя файла: {file.FullName}");
                Console.WriteLine($"Расширение файла: {file.Extension}");
                Console.WriteLine($"Файл находится в каталоге: {file.Directory}");
                Console.WriteLine($"Путь к каталогу: {file.DirectoryName}");
            }
           // Console.WriteLine(file.Name);
            string filepath2 = "D:\\New\\hello.py";
            FileInfo file1 = new FileInfo(filepath2);
            string newfilepath = "D:\\New Folder\\"+file1.Name;
            if (File.Exists(newfilepath))
            {
                File.Delete(newfilepath);
                Console.WriteLine("Файл удален");
            }
            else
            {
                file1.MoveTo(newfilepath);
                Console.WriteLine("Файл перемещен");
            }


            string path3 = "D:\\New";
            DirectoryInfo directory2 = new DirectoryInfo(path3);
            if (!directory2.Exists)
            {
                directory2.Create();
            }
            Console.WriteLine("Введите строку для записи в файл");
            string text = Console.ReadLine();

            string filepath3 = $"{path3}\\hello.txt";

            //запись в файл
            using (FileStream stream = new FileStream(filepath3, FileMode.OpenOrCreate))
            {
                Console.WriteLine(filepath3.Length);
                //преобразовуем строку в байты
                byte[] arr = System.Text.Encoding.Default.GetBytes(text);
                // задаем позицию
                stream.Seek(1, SeekOrigin.End);
                // запись массива байтов в файл с заданной позиции
                await stream.WriteAsync(arr, 0, arr.Length);
                Console.WriteLine("Текст записан в файл");
               
               
               

            }
            // чтение из файла
            using (FileStream stream = File.OpenRead($"{path3}\\hello.txt"))
            {
                // преобразуем строку в байты
                byte[] arr = new byte[stream.Length];
                // считываем данные
                await stream.ReadAsync(arr, 0, arr.Length);
                //декодируем байты в строку
                string textFile = System.Text.Encoding.Default.GetString(arr);
                Console.WriteLine($"Текст из файла: {textFile}");
            }

            string writepath = "D:\\New\\bones.txt";
            Console.WriteLine("введите строку");
            string text1 = Console.ReadLine();
            try
            {
                using (StreamWriter sw = new StreamWriter(writepath, true, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(text1);
                }
                Console.WriteLine("Запись выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                using (StreamReader sr = new StreamReader(writepath))
                {
                    Console.WriteLine(await sr.ReadToEndAsync());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            // асинхронное чтение построчно
           
                using (StreamReader sr = new StreamReader(writepath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            Person[] people = new Person[2];
            people[0] = new Person { Name = "Ivan", Age = 21 };
            people[1] = new Person { Name = "Kate", Age = 22 };
            string bpath = "D:\\New\\people.dat";
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(bpath, FileMode.OpenOrCreate)))
                {
                    foreach(Person p in people)
                    {
                        writer.Write(p.Name);
                        writer.Write(p.Age);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(bpath, FileMode.Open)))
                {
                    // пока не достигнут конец файла
                    // считываем каждое значение из файла
                    
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();
                        int age = reader.ReadInt32();
                        
                        Console.WriteLine($"name={name},age={age}");
                       
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string bookpath = "D:\\New\\library.dat";
            Book[] books = new Book[3];
            books[0] = new Book("Tom Souyer", "Mark Twen", 300);
            books[1] = new Book("Harry Potter", "J.K.Rollling", 500);
            books[2] = new Book("The Great Gatsby", "F.Scott Fitzerald", 170);

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(bookpath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, books);
                Console.WriteLine("Object was succesfully serialized");
            }
            try
            {
                using (FileStream fs = new FileStream(bookpath, FileMode.Open))
                {
                    Book[] deserializedbooks = (Book[])formatter.Deserialize(fs);
                    foreach(var b in deserializedbooks)
                    {
                        Console.WriteLine($"BookName: {b.Name}, Author: {b.Author}");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            string sourceFile = "D:\\New\\book.pdf"; // исходный файл
            string compressedFile = "D:\\New\\book.gz"; // сжатый файл
            string targetFile = "D:\\New\\book_new.pdf"; // восстановленный файл

            // создание сжатого файла
            Compress(sourceFile, compressedFile);
            // чтение из сжатого файла
            Decompress(compressedFile, targetFile);

            Console.ReadLine();

            string sourceFolder = "D://New/"; // исходная папка
            string zipFile = "D://New.zip"; // сжатый файл
            string targetFolder = "D://New Folder"; // папка, куда распаковывается файл

            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
            ZipFile.ExtractToDirectory(zipFile, targetFolder);

            Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");
            Console.ReadLine();
        }
        public static void Compress(string sourcefile,string compressedfile)
        {
            //поток для чтения исходного файла
            using (FileStream sourcestream=new FileStream(sourcefile,FileMode.OpenOrCreate))
            {
                //поток для записи сжатого файла
                using(FileStream targetstream = File.Create(compressedfile))
                {
                    //поток для архивации
                    using (GZipStream compressionstream=new GZipStream(targetstream,CompressionMode.Compress))
                    {
                        sourcestream.CopyTo(compressionstream);  // копируем байты из одного потока в другой
                        Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                        sourcefile, sourcestream.Length.ToString(), targetstream.Length.ToString());
                    }
                }
            }
        }
        public static void Decompress(string compressedfile,string targetfile)
        {
            // поток для чтения из сжатого файла
            using(FileStream sourcestream=new FileStream(compressedfile, FileMode.OpenOrCreate))
            {
                // поток записи восстановленного файла
                using (FileStream targetstream=File.Create(targetfile))
                {
                    // поток разархивации
                    using(GZipStream decompressionstream=new GZipStream(sourcestream, CompressionMode.Decompress))
                    {
                        decompressionstream.CopyTo(targetstream);
                        Console.WriteLine("Восстановлен файл: {0}", targetfile);
                    }
                }
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
     //  public List<string> Languages { get; set; }
    }
    [Serializable]
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        [NonSerialized]
        public int pages;

        public Book(string name,string author,int p)
        {
            Name = name;
            Author = author;
            pages = p;
        }
    }
}