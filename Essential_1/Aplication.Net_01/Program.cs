using Library_Demo;
using System;

namespace MyNameSpace
{
    //in C# ko gioi han ten file code vs teen class
    //1 file code co nhieu class
    //1 class co the viet trong nhieu file khac nhau : Them tu khoa partial vao trc class

    partial class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Hello World!");
            Employee e = new Employee();
        }
    }
}
