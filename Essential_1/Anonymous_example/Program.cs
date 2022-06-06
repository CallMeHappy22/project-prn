using System;

namespace Anonymous
{
    public class Program
    {
        //Anonymous - kieu du lieu vo danh
        //Object - thuoc tinh - chi doc - readonly
        //new {thuoctinh = giatri, thuoctinh2 = gia tri2}
        static void EXAnony()
        {
            var sanpham = new
            {
                Ten = "Iphone 8",
                Gia = 1000,
                NamSx = 2019
            };
            Console.WriteLine($"Name : {sanpham.Ten}, Price: {sanpham.Gia}");
        }
        class SinhVien
        {
            public string Ten { get; set; }
            public int NamSinh { get; set; }
            public string NoiSinh { get; set; }

            static void Main(string[] args)
            {
                List<SinhVien> cacsinhvien = new List<SinhVien>() {
           new SinhVien(){Ten = "Nam",NamSinh = 2000, NoiSinh = "Binh Duong" },
           new SinhVien(){Ten = "Linh",NamSinh = 2001, NoiSinh = "Nam Dinh" },
           new SinhVien(){Ten = "Ha",NamSinh = 2002, NoiSinh = "Vinh Phuc" },
           new SinhVien(){Ten = "Thuan",NamSinh = 2000, NoiSinh = "Ha Tay" }
           };

                var ketqua = from sv in cacsinhvien
                             where sv.Ten.Contains("a")
                             select new
                             {
                                 Ten = sv.Ten,
                                 NS = sv.NoiSinh
                             };
                foreach (var s in ketqua)
                {
                    Console.WriteLine(s.Ten + "-" + s.NS);
                }

            }
        }
    }
}