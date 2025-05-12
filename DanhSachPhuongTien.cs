using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ONTAP3
{
    public class DanhSachPhuongTien
    {
        List<Vehicle> collection;
        public DanhSachPhuongTien()
        {
            collection = new List<Vehicle>();
        }

        public void NhapThuCong()
        {
            Console.WriteLine("nhap tien phuong tien: ");
            string name = Console.ReadLine();
            Console.WriteLine("nhap toc do cua phuong tien: ");
            double tocDo = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhap nhien lieu: ");
            double nhienLieu = double.Parse(Console.ReadLine());
            Console.WriteLine("nhap vi tri: ");
            string viTri = Console.ReadLine();
            Console.WriteLine("nhap loai phuong tien: ");
            string loai = Console.ReadLine();
            Vehicle pt = null;

            switch (loai)
            {
                case "Car":
                    pt = new Car(name, tocDo, nhienLieu, viTri);
                    break;
                case "Boat":
                    pt = new Boat(name, tocDo, nhienLieu, viTri);
                    break;
                case "Seaplane":
                    pt = new Seaplane(name, tocDo, nhienLieu, viTri);
                    break;
                case "Submarine":
                    pt = new Submarine(name, tocDo, nhienLieu, viTri);
                    break;
            }
            if (pt != null)
            {
                collection.Add(pt);
                Console.WriteLine("da them 1 phuong tien");
            }
        }

        public void DocTuFile(string filename)
        {
            if(!File.Exists(filename))
            {
                Console.WriteLine("file ko ton tai");
            }
            StreamReader sr = new StreamReader(filename);
            string line = "";

            while((line = sr.ReadLine()) != null)
            {
                var pair = line.Split(',');

                string loai = pair[0];
                string ten = pair[1];
                double tocDo = double.Parse(pair[2]);
                double nhienLieu = double.Parse(pair[3]);
                string viTri = pair[4];


                Vehicle pt = null;

                switch(loai)
                {
                    case "Car":
                        pt = new Car(ten, tocDo, nhienLieu, viTri);
                        break;
                    case "Boat":
                        pt = new Boat(ten, tocDo, nhienLieu, viTri);
                        break;
                    case "Seaplane":
                        pt = new Seaplane(ten, tocDo, nhienLieu, viTri);
                        break;
                    case "Submarine":
                        pt = new Submarine(ten, tocDo, nhienLieu, viTri);
                        break;
                }
                if (pt != null)
                {
                    collection.Add(pt);
                }
            }
            sr.Close();

        }


        public void XuatRaFile(string tenFile)
        {
            if (!File.Exists(tenFile))
            {
                Console.WriteLine("ko ton tai file");
            }

            StreamWriter sw = new StreamWriter(tenFile);

            foreach(var item in collection)
            {
                string line = $"ten phuong tien: {item.Name}, toc do: {item.TocDo}, nhien lieu{item.NhienLieu}, vi tri: {item.ViTri}";
                sw.WriteLine(line);
            }
            Console.WriteLine("da ghi ra file thanh cong");
        }

        public void XuatDanhSach()
        {
            foreach (var pt in collection)
            {
                pt.DisplayInfo();
                Console.WriteLine();
            }
        }

        public void Them(Vehicle pt)
        {
            collection.Add(pt);
            Console.WriteLine($"da them phuong tien: {pt.Name}");
        }

        public void Xoa(string ten)
        {
            var pt = collection.Find(v => v.Name == ten);
            if (pt != null)
            {
                collection.Remove(pt);
                Console.WriteLine($"da xoa phuong tien: {ten}");
            }
            else
            {
                Console.WriteLine($"khong tim thay phuong tien: {ten}");
            }
        }

        public void HienThiHanhVi()
        {
            foreach (var pt in collection)
            {
                Console.WriteLine($"phuong tien: {pt.Name}");

                if (pt is IDriveable)
                    Console.WriteLine(" - co the lai");

                if (pt is IFloatable)
                    Console.WriteLine(" - co the noi");

                if (pt is IFlyable)
                    Console.WriteLine(" - co the bay");

                if (pt is IDiveable)
                    Console.WriteLine(" - co the lan");

                Console.WriteLine();
            }
        }

        public void ThucHienHanhDong()
        {
            foreach (var pt in collection)
            {
                pt.DisplayInfo();  

                if (pt is IDriveable d)
                    d.Drive();  

                if (pt is IFloatable f)
                    f.Float();

                if (pt is IFlyable fly)
                    fly.Fly();

                if (pt is IDiveable dive)
                    dive.Dive();

                Console.WriteLine();
            }
        }

        public DanhSachPhuongTien TimPhuongTienCoTheBay()
        {
            DanhSachPhuongTien result = new DanhSachPhuongTien();
            foreach (var pt in collection)
            {
                if (pt is IFlyable)
                {
                    result.Them(pt);
                }
            }
            return result;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheLai()
        {
            DanhSachPhuongTien result = new DanhSachPhuongTien();
            foreach (var pt in collection)
            {
                if (pt is IDriveable)
                {
                    result.Them(pt);
                }
            }
            return result;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheNoi()
        {
            DanhSachPhuongTien result = new DanhSachPhuongTien();
            foreach (var pt in collection)
            {
                if (pt is IFloatable)
                {
                    result.Them(pt);
                }
            }
            return result;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheLan()
        {
            DanhSachPhuongTien result = new DanhSachPhuongTien();
            foreach (var pt in collection)
            {
                if (pt is IDiveable)
                {
                    result.Them(pt);
                }
            }
            return result;
        }

        public void Swap(int i, int j, List<Vehicle> list)
        {
            var tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }

        public void SapXepDanhSachTangTheoTocDo()
        {
            for(int i = 0; i < collection.Count- 1; i++)
            {
                for(int j = i + 1; j < collection.Count; j++)
                {
                    if(collection[i].TocDo > collection[j].TocDo)
                    {
                        Swap(i, j, collection);
                    }
                }
            }
        }
        public void SapXepDanhSachGiamTheoTocDo()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].TocDo > collection[j].TocDo)
                    {
                        Swap(i, j, collection);
                    }
                }
            }
        }

        public double TinhTongTatCaNhienLieu()
        {
            double sum = 0;
            foreach(var item in collection)
            {
                sum += item.NhienLieu;
            }
            return sum;
        }

        public bool KiemTraPhuongTienCoTonTaiTrongDanhSach(string ten)
        {
            bool kt = false;
            foreach (var item in collection)
            {
                if(string.Compare(item.Name, ten) == 0)
                {
                    kt = true;
                    break;
                }
            }
            return kt;  
        }

        public int DemSoLuongPhuongTienLai()
        {
            int dem = 0;
            foreach (var item in collection)
            {
                if(item is IDriveable)
                {
                    dem++;
                }
            }
            return dem;
        }

        public int DemSoLuongPhuongTienNoi()
        {
            int dem = 0;
            foreach (var item in collection)
            {
                if (item is IFloatable)
                {
                    dem++;
                }
            }
            return dem;
        }

        public int DemSoLuongPhuongTienBay()
        {
            int dem = 0;
            foreach (var item in collection)
            {
                if (item is IFlyable)
                {
                    dem++;
                }
            }
            return dem;
        }

        public int DemSoLuongPhuongTienLan()
        {
            int dem = 0;
            foreach (var item in collection)
            {
                if (item is IDiveable)
                {
                    dem++;
                }
            }
            return dem;
        }

        public DanhSachPhuongTien DanhSachPhuongTienCoTocDoToiThieu(double tocDo)
        {
            DanhSachPhuongTien result = new DanhSachPhuongTien();
            foreach(var item in collection)
            {
                if (item.TocDo >= tocDo)
                {
                    result.Them(item);
                }
            }


            return result;
        }

        public DanhSachPhuongTien DanhSachPhuongTienCoNhienLieuToiThieu(double nhiemLieu)
        {
            DanhSachPhuongTien result = new DanhSachPhuongTien();
            foreach (var item in collection)
            {
                if (item.NhienLieu >= nhiemLieu)
                {
                    result.Them(item);
                }
            }


            return result;
        }

        public Vehicle TimPhuongTienTheoTen(string ten)
        {
            foreach(var item in collection)
            {
                if(string.Compare(item.Name, ten) == 0)
                {
                    return item;
                }
            }
            return null;
        }

        public void CapNhatThuocTinhTocDo(string ten, double tocDo)
        {
            var pt = TimPhuongTienTheoTen(ten);
            if(pt == null)
            {
                Console.WriteLine($"phuong tien {ten} ko co trong danh sach");
                return;
            }
            pt.TocDo = tocDo;
            Console.WriteLine($"phuong tien {ten} da duoc cap nhat lai toc do");
        }

        public void CapNhatThuocTinhNhienLieu(string ten, double nhienLieu)
        {
            var pt = TimPhuongTienTheoTen(ten);
            if (pt == null)
            {
                Console.WriteLine($"phuong tien {ten} ko co trong danh sach");
                return;
            }
            pt.NhienLieu = nhienLieu;
            Console.WriteLine($"phuong tien {ten} da duoc cap nhat lai toc do");
        }

        public int TinhTongSoLuongPhuongTienCoTrongDanhSach()
        {
            return collection.Count();  
        }

        public void SapXepDanhSachTangTheoNhienLieu()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].NhienLieu > collection[j].NhienLieu)
                    {
                        Swap(i, j, collection);
                    }
                }
            }
        }
        public void SapXepDanhSachGiamTheoNhienLieu()
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].NhienLieu > collection[j].NhienLieu)
                    {
                        Swap(i, j, collection);
                    }
                }
            }
        }

        public double TimMaxTocDo()
        {
            double maxVal = 0;
            foreach(var item in collection)
            {
                if(item.TocDo > maxVal)
                {
                    maxVal = item.TocDo;
                }
            }
            return maxVal;
        }

        public DanhSachPhuongTien TimPhuongTienCoTocDoCaoNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            double maxVal = TimMaxTocDo();
            foreach(var item in collection)
            {
                if(item.TocDo == maxVal)
                {
                    res.Them(item);
                }
            }
            return res;

        }

    }
}
