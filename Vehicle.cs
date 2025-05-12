using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ONTAP3
{
    public abstract class Vehicle
    {
        public string Name { get; set; }
        public double TocDo { get; set; }         
        public double NhienLieu { get; set; }     
        public string ViTri { get; set; }         



        protected Vehicle(string name)
        {
            Name = name;
            TocDo = 0;
            NhienLieu = 100;     
            ViTri = "bai do";
        }

        protected Vehicle(string name, double tocDo, double nhienLieu, string viTri)
        {
            Name = name;
            TocDo = tocDo;
            NhienLieu = nhienLieu;
            ViTri = viTri;
        }

        public abstract void DisplayInfo();

        public virtual void DiChuyen(string viTriMoi)
        {
            if (NhienLieu <= 0)
            {
                Console.WriteLine($"{Name} không thể di chuyển vì hết nhiên liệu.");
                return;
            }

            ViTri = viTriMoi;
            NhienLieu -= 10; // tiêu hao nhiên liệu
            Console.WriteLine($"{Name} đã di chuyển đến {ViTri}. Nhiên liệu còn lại: {NhienLieu}L");
        }

        public void NapNhienLieu(double luong)
        {
            NhienLieu += luong;
            Console.WriteLine($"{Name} da duoc nap {luong}L nhien loei. Tong: {NhienLieu}L");
        }

        public void TangTocDo(double vanToc)
        {
            TocDo += vanToc;
            Console.WriteLine($"{Name} da tang {vanToc}km/h. Toc do hien tai {TocDo}km/h");
        }

        public void GiamTocDo(double vanToc)
        {
            TocDo -= vanToc;
            Console.WriteLine($"{Name} da giam {vanToc}km/h. Toc do hien tai {TocDo}km/h");
        }
    }
}

