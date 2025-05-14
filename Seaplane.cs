using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ONTAP3
{
    public class Seaplane : Vehicle, IFlyable, IFloatable
    {
        public Seaplane(string name, double tocDo, double nhienLieu, string viTri, double nhienLieuTieuHao, int namSanXuat, string nhaSanXuat)
            : base(name, tocDo, nhienLieu, viTri, nhienLieuTieuHao, namSanXuat, nhaSanXuat) { }

        public void Fly()
        {
            Console.WriteLine($"{Name} dang bay.");
        }

       

        public void Float()
        {
            Console.WriteLine($"{Name} dang noi tren mat nuoc.");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: {Name} - Behavior: Fly, Float");
        }

       
    }
}
