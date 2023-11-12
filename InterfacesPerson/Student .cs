using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesPerson
{
    public class Student : Person
    {
        public int StudentId { get; set; }
        public Teacher Advisor { get; set; }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Student ID: {StudentId}");
            Console.WriteLine("Advisor:");
            Advisor?.Print();
        }
    }

    public class StudentWithAdvisor : Student
    {
        public Teacher Advisor { get; set; }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Advisor: {Advisor?.Name}");
        }
    }
}
