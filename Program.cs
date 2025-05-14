using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ONTAP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DanhSachPhuongTien ds = new DanhSachPhuongTien();
            string input = "C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\OOP_ONTAP3\\OOP_ONTAP3\\bin\\Debug\\input.txt";
            ds.DocTuFile(input);

            ds.XuatDanhSach();

            Console.WriteLine();

            string output = "C:\\Users\\nguyen.cao\\Desktop\\codec++\\oop\\baiTapTrenLMS\\OOP_ONTAP3\\OOP_ONTAP3\\bin\\Debug\\output.txt";
            ds.XuatRaFile(output);

            ds.CacPhuongTienCoTheBayVaCoNhienLieuTrenMotNguong(100).XuatDanhSach();
            //ds.NhomPhuongTienTheoNhaSanXuat().XuatDanhSach();
        }
    }
}
