using System;
using System.Collections;
using System.Linq;
using System.Text;
namespace Delegate
{
    internal class Program
    {
        //delegate không khai báo trong hàm được mà bạn phải khai báo ngoài hàm
        delegate int MyDelegate(string s);
        static void Main(string[] args)
        {
            //delegate tương tự như bạn khai báo một cái hàm
            Console.OutputEncoding = Encoding.UTF8;
           
            MyDelegate showString = new MyDelegate(ShowString);

            NhapVaoShowTen(showString);
          
            //Call-back function

            Console.ReadLine();

        }
        static void NhapVaoShowTen(MyDelegate showTen)
        {
            Console.WriteLine("Mời nhập vào tên bạn: ");
            string ten = Console.ReadLine();
            showTen(ten);
        }
        static int ConverToInt(string stringValue)
        {
            int valueInt = 0;
            Int32.TryParse(stringValue, out valueInt);
            Console.WriteLine("ép kiểu thành công.");
            return valueInt;
        }
        static int ShowString(string stringValue)
        {
            Console.WriteLine(stringValue);
            return 0;
        }

    }
}
