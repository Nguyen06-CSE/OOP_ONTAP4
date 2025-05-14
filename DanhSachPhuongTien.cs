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
            Console.WriteLine("nhap muc nhien lieu tieu hao cua phuong tien");
            double nhienLieuTieuHao = double.Parse(Console.ReadLine());
            Console.WriteLine("nhap nam san xuat");
            int namSanXuat = int.Parse(Console.ReadLine());
            Console.WriteLine("nhap nha san xuat: ");
            string nhaSanXuat = Console.ReadLine();
            Console.WriteLine("nhap loai phuong tien: ");
            string loai = Console.ReadLine();
            
            Vehicle pt = null;

            switch (loai)
            {
                case "Car":
                    pt = new Car(name, tocDo, nhienLieu, viTri, nhienLieuTieuHao, namSanXuat, nhaSanXuat);
                    break;
                case "Boat":
                    pt = new Boat(name, tocDo, nhienLieu, viTri, nhienLieuTieuHao, namSanXuat, nhaSanXuat);
                    break;
                case "Seaplane":
                    pt = new Seaplane(name, tocDo, nhienLieu, viTri, nhienLieuTieuHao, namSanXuat, nhaSanXuat);
                    break;
                case "Submarine":
                    pt = new Submarine(name, tocDo, nhienLieu, viTri    , nhienLieuTieuHao, namSanXuat, nhaSanXuat);
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
                double nhienLieuTieuHao = double.Parse(pair[5]);
                int namSanXuat = int.Parse(pair[6]);
                string nhaSanXuat = pair[7];


                Vehicle pt = null;

                switch(loai)
                {
                    case "Car":
                        pt = new Car(ten, tocDo, nhienLieu, viTri, nhienLieuTieuHao, namSanXuat, nhaSanXuat);
                        break;
                    case "Boat":
                        pt = new Boat(ten, tocDo, nhienLieu, viTri, nhienLieuTieuHao, namSanXuat, nhaSanXuat);
                        break;
                    case "Seaplane":
                        pt = new Seaplane(ten, tocDo, nhienLieu, viTri, nhienLieuTieuHao, namSanXuat, nhaSanXuat);
                        break;
                    case "Submarine":
                        pt = new Submarine(ten, tocDo, nhienLieu, viTri, nhienLieuTieuHao, namSanXuat, nhaSanXuat);
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
                Console.WriteLine(pt);
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

        public double FindMaxTocDo(List<Vehicle> list)
        {
            double maxVal = 0;
            foreach(var item in list)
            {
                if(item.TocDo > maxVal)
                {
                    maxVal = item.TocDo;
                }
            }
            return maxVal;
        }

        public double FindMinNhienLieu(List<Vehicle> list)
        {
            double minVal = double.MaxValue;
            foreach (var item in list)
            {
                if (item.NhienLieu < minVal)
                {
                    minVal = item.NhienLieu;
                }
            }

            return minVal;
        }

        public DanhSachPhuongTien TimPhuongTienCoTocDoCaoNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            double maxVal = FindMaxTocDo(collection);
            foreach(var item in collection)
            {
                if(item.TocDo == maxVal)
                {
                    res.Them(item);
                }
            }
            return res;

        }

       

        public DanhSachPhuongTien TimPhuongTienCoNhienLieuThapNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            double minVal = FindMinNhienLieu(collection);
            foreach(var item in collection)
            {
                if(item.NhienLieu == minVal)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public void XoaTatCaPhuongTienCoTheLai()
        {
            foreach(var item in collection)
            {
                if(item is IDriveable)
                {
                    collection.Remove(item);
                }
            }
        }

        public void XoaTatCaPhuongTienCoTheBay()
        {
            foreach (var item in collection)
            {
                if (item is IFlyable)
                {
                    collection.Remove(item);
                }
            }
        }

        public void XoaTatCaPhuongTienCoTheNoi()
        {
            foreach (var item in collection)
            {
                if (item is IFloatable)
                {
                    collection.Remove(item);
                }
            }
        }

        public void XoaTatCaPhuongTienCoTheLan()
        {
            foreach (var item in collection)
            {
                if (item is IDiveable)
                {
                    collection.Remove(item);
                }
            }
        }

        public void XoaTatCaPhuongTien()
        {
            collection.Clear();
        }

        public DanhSachPhuongTien TimPhuongTienCoTheLaiTocDoLonNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheLai().collection;
            double maxVal = FindMaxTocDo(list);
            foreach(var item in list)
            {
                if(item.TocDo == maxVal)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheBayTocDoLonNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheBay().collection;
            double maxVal = FindMaxTocDo(list);
            foreach (var item in list)
            {
                if (item.TocDo == maxVal)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheNoiTocDoLonNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheNoi().collection;
            double maxVal = FindMaxTocDo(list);
            foreach (var item in list)
            {
                if (item.TocDo == maxVal)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheLanTocDoLonNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheLan().collection;
            double maxVal = FindMaxTocDo(list);
            foreach (var item in list)
            {
                if (item.TocDo == maxVal)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public double FindMinNhieuLieuTieuHao()
        {
            double min = double.MaxValue;
            foreach(var item in collection)
            {
                if(item.NhienLieuTieuHao < min)
                {
                    min = item.NhienLieuTieuHao;
                }
            }
            return min;
        }

        public DanhSachPhuongTien TimPhuongTienCoMucTieuHaoNhanLieuItNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var min = FindMinNhieuLieuTieuHao();
            foreach(var item in collection)
            {
                if(item.NhienLieuTieuHao == min)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public double TinhTongSoKmCuaTatCaPhuongTien()
        {
            double res = 0;
            foreach(var item in collection)
            {
                res += item.TinhQuangDuong();
            }
            return res;
        }

        public int DemSoLuongPhuongTienCoTocDoTrenMotNguong(double tocDo)
        {
            int dem = 0;
            foreach(var item in collection)
            {
                if(item.TocDo > tocDo)
                {
                    ++dem;
                }
            }

            return dem;
        }

        public double FindMaxNhienLieu(List<Vehicle> list)
        {
            double max = 0;
            foreach(var item in list)
            {
                if(max < item.NhienLieu)
                {
                    max = item.NhienLieu;
                }
            }
            return max;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheLaiCoNhienLieuNhieuNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheLai().collection;
            var max = FindMaxNhienLieu(list);
            foreach(var item in list)
            {
                if(item.NhienLieu == max)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheBayCoNhienLieuNhieuNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheBay().collection;
            var max = FindMaxNhienLieu(list);
            foreach (var item in list)
            {
                if (item.NhienLieu == max)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheNoiCoNhienLieuNhieuNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheNoi().collection;
            var max = FindMaxNhienLieu(list);
            foreach (var item in list)
            {
                if (item.NhienLieu == max)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheLanCoNhienLieuNhieuNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheLan().collection;
            var max = FindMaxNhienLieu(list);
            foreach (var item in list)
            {
                if (item.NhienLieu == max)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien LocPhuongTienTheoNamSanXuat(int nam)
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            foreach(var item in collection)
            {
                if(item.NamSanXuat == nam)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public void SapXepPhuongTienTheoTen()
        {
            for (int i = 0; i < collection.Count-1; i++)
            {
                for(int j = i+1; j < collection.Count; j++)
                {
                    if (string.Compare(collection[i].Name, collection[j].Name) > 0)
                    {
                        Swap(i, j, collection);
                    }
                }
            }
        }

        public bool KiemTraCoTonTai(string nhaSanXuat)
        {
            foreach(var item in collection)
            {
                if(item.NhaSanXuat == nhaSanXuat) return true;
            }
            return false;
        }

        public DanhSachPhuongTien NhomPhuongTienTheoNhaSanXuat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            foreach(var item in collection)
            {
                if(!res.KiemTraCoTonTai(item.NhaSanXuat))
                {
                    foreach(var item2 in collection)
                    {
                        if(string.Compare(item2.NhaSanXuat, item.NhaSanXuat) == 0)
                        {
                            res.Them(item2);
                        }
                    }
                }
                res.Them(item);
            }
            return res;
        }

        public double TinhTongTatCaTocDoCuaPhuongTien()
        {
            double res = 0; 
            foreach(var item in collection)
            {
                res += item.TocDo;
            }
            return res;
        }

        public double TinhTrungBinhTocDo()
        {
            
            return TinhTongTatCaTocDoCuaPhuongTien() / collection.Count;
        }

        public double FindMaxQuangDuong()
        {
            double max = 0;
            foreach (var item in collection)
            {
                var tmp = item.TinhQuangDuong();
                if (tmp > max)
                {
                    max = tmp;
                }
            }
            return max;
        }

        public DanhSachPhuongTien TimPhuongTienDiDuocQuangDuongDaiNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var max = FindMaxQuangDuong();
            foreach (var item in collection)
            {
                var tmp = item.TinhQuangDuong();
                if(tmp == max)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien CacPhuongTienCoTheBayVaCoNhienLieuTrenMotNguong(double nhienLieu)
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheBay().collection;
            foreach (var item in list)
            {
                if(item.NhienLieu > nhienLieu)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien CacPhuongTienCoTheLaiVaCoNhienLieuTrenMotNguong(double nhienLieu)
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var list = TimPhuongTienCoTheLai().collection;
            foreach (var item in list)
            {
                if (item.NhienLieu > nhienLieu)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien DanhSachPhuongTienCanBaoTri()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            foreach(var item in collection)
            {
                if(item.TinhQuangDuong() > 10000)
                {
                    res.Them(item);
                }
            }


            return res;
        }


        public DanhSachPhuongTien KiemTraPhuongTienSauNam(int nam)
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            foreach(var item in collection)
            {
                if(item.NamSanXuat < nam)
                {
                    res.Them(item);
                }
            }

            return res;
        }

        public DanhSachPhuongTien DanhSachPhuongTienDuocSanXuatBoiNhaSanXuat(string nhaSanXuat)
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            foreach(var item in collection)
            {
                if(string.Compare(item.NhaSanXuat, nhaSanXuat) == 0)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public List<string> LayLoaiPhuongTien()
        {
            List<string> list = new List<string>();
            foreach (var item in collection)
            {
                if (!list.Contains(item.GetType().Name))
                {
                    list.Add(item.GetType().Name);
                }
            }
            return list;
        }

        public void BaoCaoChiTietTheoLoai()
        {
            string[] daXuLy = new string[collection.Count];
            int daXuLyCount = 0;

            for (int i = 0; i < collection.Count; i++)
            {
                string loai = collection[i].GetType().Name;

                bool daTonTai = false;
                for (int j = 0; j < daXuLyCount; j++)
                {
                    if (daXuLy[j] == loai)
                    {
                        daTonTai = true;
                        break;
                    }
                }

                if (!daTonTai)
                {
                    int count = 0;
                    double tongTocDo = 0;
                    double tongNhienLieu = 0;

                    for (int k = 0; k < collection.Count; k++)
                    {
                        if (collection[k].GetType().Name == loai)
                        {
                            count++;
                            tongTocDo += collection[k].TocDo;
                            tongNhienLieu += collection[k].NhienLieu;
                        }
                    }

                    double avgTocDo = count > 0 ? tongTocDo / count : 0;
                    double avgNhienLieu = count > 0 ? tongNhienLieu / count : 0;

                    Console.WriteLine($"Loại: {loai}");
                    Console.WriteLine($"  - Số lượng: {count}");
                    Console.WriteLine($"  - Tốc độ trung bình: {avgTocDo} km/h");
                    Console.WriteLine($"  - Nhiên liệu trung bình: {avgNhienLieu} L\n");

                    // Ghi lại loại đã xử lý
                    daXuLy[daXuLyCount] = loai;
                    daXuLyCount++;
                }
            }
        }

        public double FinMinTocDo(List<Vehicle> list)
        {
            double min = double.MaxValue;
            foreach(var item in list)
            {
                if(item.TocDo < min)
                {
                    min = item.TocDo;
                }
            }
            return min;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheLaiCoTocDoNhoNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var min = FinMinTocDo(TimPhuongTienCoTheLai().collection);
            foreach(var item in collection)
            {
                if(item.TocDo == min)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheLanCoTocDoNhoNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var min = FinMinTocDo(TimPhuongTienCoTheLan().collection);
            foreach (var item in collection)
            {
                if (item.TocDo == min)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public DanhSachPhuongTien TimPhuongTienCoTheNoiCoTocDoNhoNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var min = FinMinTocDo(TimPhuongTienCoTheNoi().collection);
            foreach (var item in collection)
            {
                if (item.TocDo == min)
                {
                    res.Them(item);
                }
            }
            return res;
        }
        public DanhSachPhuongTien TimPhuongTienCoTheBayCoTocDoNhoNhat()
        {
            DanhSachPhuongTien res = new DanhSachPhuongTien();
            var min = FinMinTocDo(TimPhuongTienCoTheBay().collection);
            foreach (var item in collection)
            {
                if (item.TocDo == min)
                {
                    res.Them(item);
                }
            }
            return res;
        }

        public double TongMucNhienLieuCuaPhuongTienCoTheLai()
        {
            double res = 0.0;
            var list = TimPhuongTienCoTheLai().collection;
            foreach(var item in list)
            {
                res += item.NhienLieu;
            }
            return res;
        }

        public double TongMucNhienLieuCuaPhuongTienCoTheLan()
        {
            double res = 0.0;
            var list = TimPhuongTienCoTheLan().collection;
            foreach (var item in list)
            {
                res += item.NhienLieu;
            }
            return res;
        }

        public double TongMucNhienLieuCuaPhuongTienCoTheBay()
        {
            double res = 0.0;
            var list = TimPhuongTienCoTheBay().collection;
            foreach (var item in list)
            {
                res += item.NhienLieu;
            }
            return res;
        }

        public double TongMucNhienLieuCuaPhuongTienCoTheNoi()
        {
            double res = 0.0;
            var list = TimPhuongTienCoTheNoi().collection;
            foreach (var item in list)
            {
                res += item.NhienLieu;
            }
            return res;
        }


    }
}
