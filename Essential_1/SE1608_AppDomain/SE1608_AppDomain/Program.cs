using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Linq;

namespace SE1608_AppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain appDomain = Thread.GetDomain();
            Console.WriteLine($"Name of AppDomain: {appDomain.FriendlyName}");

            Assembly[] assemblies = appDomain.GetAssemblies();
            foreach (var a in assemblies)
                Console.WriteLine($"Assembly: Name = {a.GetName().Name}, " +
                    $"Version = {a.GetName().Version}");

            //var runningProc = Process.GetProcesses()
            //        .OrderBy(p => p.Id);
            //foreach (var p in runningProc)
            //    Console.WriteLine($"PID = {p.Id}, Name = {p.ProcessName}");

            Process proccess = new Process();
            string inputFile, outputFile, answerFile;
            inputFile = @"C:\CSharp\TestCases10\Q1\input1.txt";
            outputFile = @"C:\CSharp\TestCases10\Q1\output1.txt";
            answerFile = @"C:\CSharp\TestCases10\Q1\Q1.exe";
            proccess.StartInfo.FileName = "cmd.exe";
            proccess.StartInfo.Arguments = $"/C {answerFile} < {inputFile} > {outputFile}";
            proccess.Start();

        }
    }
}
