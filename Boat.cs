using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ONTAP3
{
    public class Boat : Vehicle, IFloatable
    {
        public Boat(string name, double tocDo, double nhienLieu, string viTri)
            : base(name, tocDo, nhienLieu, viTri) { }
        public void Float()
        {
            Console.WriteLine($"dang cheo {Name}");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"phuong tien: {Name} - hanh vi: cheo");
        }
    }
}
