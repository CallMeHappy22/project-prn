using System;

namespace Event
{
    class HocSinh
    {
       public event UpdateNameHandle NamChange;
        private string _Name;
        public string Name
        {
            get => _Name; 
            set { _Name = value;
                if (NamChange != null)
                {
                    NamChange(Name);
                }
           } 
        }
    }
    delegate void UpdateNameHandle(string name);

    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
           HocSinh hocSinh = new HocSinh();
            
            hocSinh.NamChange += HocSinh_NamChange;

            hocSinh.Name = "Nice";
            Console.WriteLine("Tên từ class: "+hocSinh.Name);

            hocSinh.Name = "Good";
            Console.WriteLine("Tên từ class: " + hocSinh.Name);

            Console.ReadLine();
        }

        private static void HocSinh_NamChange(string name)
        {
            Console.WriteLine("Tên MỚI: " + name);
        }
    }
}
