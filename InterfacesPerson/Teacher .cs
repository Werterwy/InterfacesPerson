using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesPerson
{
    public class Teacher : Person
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Students:");
            foreach (var student in Students)
            {
                student.Print();
            }
        }
    }
}
