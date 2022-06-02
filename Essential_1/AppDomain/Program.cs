using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Linq;
namespace appDomain
{
    internal class Program
    {
        static void Main(string[] args)
        {
         AppDomain appDomain = Thread.GetDomain();
            Console.WriteLine($"Name of AppDomain = { appDomain.FriendlyName}");

            Assembly[] assemblies = appDomain.GetAssemblies();
            foreach (var a in assemblies)
            {
                Console.WriteLine($"Assembly: Name = {a.GetName().Name}, vertion = {a.GetName().Version}");
            }
           // var runningProce = Process.GetProcesses().OrderBy(p => p.Id);
           // foreach(var p in runningProce)
           // {
           //     Console.WriteLine($"PID = {p.Id}");

            Process process = new Process();
            string answerFile, inputFile, outputFile;
            answerFile = @"C:\CSharp\TestCases10\Q1\Q1.exe";
            inputFile = @"C:\CSharp\TestCases10\Q1\input1.txt";
            outputFile = @"C:\CSharp\TestCases10\Q1\output1.txt";
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = $"/C {answerFile} <{inputFile}>{outputFile}";
            process.Start();    
        }
        }
    }

