using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ONTAP3
{
    public class Submarine : Vehicle, IDiveable, IFloatable
    {
        public Submarine(string name, double tocDo, double nhienLieu, string viTri, double nhienLieuTieuHao)
            : base(name, tocDo, nhienLieu, viTri, nhienLieuTieuHao) { }

        public void Dive()
        {
            Console.WriteLine($"{Name} dang lai duoi nuoc.");
        }

        public void Float()
        {
            Console.WriteLine($"{Name} dang noi tren mat nuoc.");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: {Name} - Behavior: Dive, Float");
        }
    }
}
