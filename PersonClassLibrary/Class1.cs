using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class Class1
    {
    }
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        void Print();
    }

    public class Person : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual void Print()
        {
            Console.WriteLine($"Person: {Name}, Age: {Age}");
        }
    }

    public class Student : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int StudentId { get; set; }
        public Teacher Advisor { get; set; }

        public void Print()
        {
            Console.WriteLine($"Student: {Name}, Age: {Age}, Student ID: {StudentId}");
            Console.WriteLine("Advisor:");
            Advisor?.Print();
        }
    }

    public class Teacher : IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public void Print()
        {
            Console.WriteLine($"Teacher: {Name}, Age: {Age}");
            Console.WriteLine("Students:");
            foreach (var student in Students)
            {
                student.Print();
            }
        }
    }
}
