using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ONTAP3
{
    public class Car : Vehicle, IDriveable
    {
        public Car (string name, double tocDo, double nhienLieu, string viTri) 
            : base (name, tocDo, nhienLieu, viTri) { }
        public void Drive()
        {
            Console.WriteLine($"Dang lai: {Name} ");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"phuong tien: {Name} - hanh vi: lai");
        }
    }
}
