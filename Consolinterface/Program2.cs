using PersonClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolinterface
{
    internal class Program2
    {
        static void Main()
        {
            IPerson[] people = new IPerson[]
            {
            new Person { Name = "John", Age = 25 },
            new Student { Name = "Alice", Age = 22, StudentId = 123, Advisor = new Teacher { Name = "Advisor", Age = 35 } },
            new Teacher { Name = "Mr. Smith", Age = 40 },
            new Student { Name = "Advisee", Age = 20, StudentId = 456, Advisor = new Teacher { Name = "Advisor", Age = 35 } },
            new Student { Name = "Another Advisee", Age = 22, StudentId = 789, Advisor = new Teacher { Name = "Advisor", Age = 35 } }
            };

            int personCount = 0, studentCount = 0, teacherCount = 0;

            foreach (var person in people)
            {
                personCount++;

                if (person is Student student)
                {
                    studentCount++;
                    // перевести студентов на следующий курс
                    student.StudentId += 1000;
                }
                else if (person is Teacher)
                {
                    teacherCount++;
                }

                person.Print();
                Console.WriteLine("------------");
            }

            Console.WriteLine($"Total Persons: {personCount}");
            Console.WriteLine($"Total Students: {studentCount}");
            Console.WriteLine($"Total Teachers: {teacherCount}");
        }
    }
}
