using System;

namespace CS_STRUCTENUM
{
    internal class Program
    {
         //STRUCT 
        public struct Product
        {
            //du lieu
            public string name;
            public double price;
            //Phuong thuc
            public string getInfo()
            {
                return $"Ten san pham {name}, gia: {price}";           
            }
            public string Info
            {
                get { return $"{name}, {price}"; }
            }
            //Construct
            public Product(string _name, double _price)
            {
                name = _name;
                price = _price;
            }
        }

        public struct CProduct
        {
            //du lieu
            public string name;
            public double price;
            //Phuong thuc
            public string getInfo()
            {
                return $"Ten san pham {name}, gia: {price}";
            }
            public string Info
            {
                get { return $"{name}, {price}"; }
            }
            //Construct
            public CProduct(string _name, double _price)
            {
                name = _name;
                price = _price;
            }
        }
        static void TestStruct()
        {
            Product sanpham1;
            sanpham1.name = "Iphone";
            sanpham1.price = 1000;
            Console.WriteLine(sanpham1.getInfo());

            Product sanpham2 = new Product("Nokia", 900);

            sanpham2 = sanpham1; //Van la hai bien doc lap .
            sanpham2.name = "Iphone x";
            Console.WriteLine(sanpham2.getInfo());

            Console.WriteLine(sanpham2.Info);
        }

        static void TestClass()
        {
            CProduct sanpham1 = new CProduct("",0);
            sanpham1.name = "Iphone";
            sanpham1.price = 1000;
            Console.WriteLine(sanpham1.getInfo());

            CProduct sanpham2 = new CProduct("Nokia", 900);

            sanpham2 = sanpham1; //Ca hai bien cung tham chieu den 1 doi tuong
            sanpham2.name = "Iphone x";
            Console.WriteLine(sanpham2.getInfo());

            Console.WriteLine(sanpham2.Info);
        }

        //Kieu liet ke num
        /*
         0 - Kem
         1 - Trung Binh
         2 - Kha
         3 - Gioi
         */
        enum HOCLUC{
            Kem = 1, //0
            TrungBinh = 5, //1
            Kha = 7, //2
            Gioi  = 10//3
        }
        static void Main(string[] args)
        {
            //enum
            Console.BackgroundColor = ConsoleColor.Green;
            // FileAccess
            //FileAttribute
            //FileMode
            //DateFormat
            //DateTimeKind


            HOCLUC hocluc;
            hocluc = HOCLUC.Gioi;

            int so = (int)hocluc;

            Console.WriteLine(so);

            hocluc = (HOCLUC) 7;

            switch (hocluc)
            {
                case HOCLUC.Kem:
                    Console.WriteLine("Hoc Luc kem");
                    break;
                    case HOCLUC.TrungBinh:
                    Console.WriteLine("Hoc Luc Trung Binh");
                    break;
                case HOCLUC.Kha:
                    Console.WriteLine("Hoc Luc Kha");
                    break;
                case HOCLUC.Gioi:
                    Console.WriteLine("Hoc Luc Gioi");
                    break;
            }

           
        }
    }
}
