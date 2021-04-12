using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace Chapter24
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Process process in Process.GetProcesses())
            {
                // выводим id и имя процесса
                Console.WriteLine($"ID: {process.Id}  Name: {process.ProcessName}");
            }
            Process proc = Process.GetProcessesByName("devenv")[0];
            Console.WriteLine($"ID: {proc.Id}");

            ProcessThreadCollection processThreads = proc.Threads;

            foreach (ProcessThread thread in processThreads)
            {
                Console.WriteLine($"ThreadId: {thread.Id}  StartTime: {thread.StartTime}");
            }

            ProcessModuleCollection modules = proc.Modules;

            foreach (ProcessModule module in modules)
            {
                Console.WriteLine($"Name: {module.ModuleName}  MemorySize: {module.ModuleMemorySize}");
            }

            ProcessStartInfo procInfo = new ProcessStartInfo();
            // исполняемый файл программы - браузер хром
            procInfo.FileName = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe";
            // аргументы запуска - адрес интернет-ресурса
            procInfo.Arguments = "http://google.com";
            Process.Start(procInfo);


            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine($"Name: {domain.FriendlyName}");
            Console.WriteLine($"Base Directory: {domain.BaseDirectory}");
            Console.WriteLine();

            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);

            Console.WriteLine("--------------");
            LoadAssembly(6);
            // очистка
            GC.Collect();
            GC.WaitForPendingFinalizers();

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(asm.GetName().Name);

            Console.Read();
        }

        private static void LoadAssembly(int number)
        {
            var context = new CustomAssemblyLoadContext();
            // установка обработчика выгрузки
            context.Unloading += Context_Unloading;
            // получаем путь к сборке MyApp
            var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "MyApp.dll");
            // загружаем сборку
            Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);
            // получаем тип Program из сборки MyApp.dll
            var type = assembly.GetType("MyApp.Program");
            // получаем его метод Factorial
            var greetMethod = type.GetMethod("Factorial");

            // вызываем метод
            var instance = Activator.CreateInstance(type);
            int result = (int)greetMethod.Invoke(instance, new object[] { number });
            // выводим результат метода на консоль
            Console.WriteLine($"Факториал числа {number} равен {result}");

            // смотим, какие сборки у нас загружены
            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(asm.GetName().Name);

            // выгружаем контекст
            context.Unload();
        }
        // обработчик выгрузки контекста
        private static void Context_Unloading(AssemblyLoadContext obj)
        {
            Console.WriteLine("Библиотека MyApp выгружена \n");
        }
    }
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public CustomAssemblyLoadContext() : base(isCollectible: true) { }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }
    }
}