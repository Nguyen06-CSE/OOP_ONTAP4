﻿using System;
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

        public double NhienLieuTieuHao {get; set;}

        public int NamSanXuat { get; set; }

        public string NhaSanXuat { get; set; }
        protected Vehicle(string name)
        {
            Name = name;
            TocDo = 0;
            NhienLieu = 100;     
            ViTri = "bai do";
            NhienLieuTieuHao = 100;
            NamSanXuat = 2025;
            NhaSanXuat = "";
        }

        protected Vehicle(string name, double tocDo, double nhienLieu, string viTri, double nhienLieuTieuHao, int namSanXuat, string nhaSanXuat)
        {
            Name = name;
            TocDo = tocDo;
            NhienLieu = nhienLieu;
            ViTri = viTri;
            NhienLieuTieuHao = nhienLieuTieuHao;
            NamSanXuat = namSanXuat;
            NhaSanXuat = nhaSanXuat;
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
            NhienLieu -= NhienLieuTieuHao; // tiêu hao nhiên liệu
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

        public double TinhQuangDuong()
        {
            if (TocDo <= 0)
            {
               
                return 0;
            }

            double quangDuong = NhienLieuTieuHao / TocDo;
           
            return quangDuong;
        }

        public override string ToString()
        {
            return $"ten: {Name}, toc do: {TocDo} km/h, nhien lieu: {NhienLieu} L, " +
                   $"vi tri: {ViTri}, tieu hao: {NhienLieuTieuHao} L, " +
                   $"nam san xuat: {NamSanXuat}, nha san xuat: {NhaSanXuat}";
        }


    }
}

