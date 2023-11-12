using InterfacesPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolinterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
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
                    Console.WriteLine("\nПеревод на следующий курс");
                    Console.WriteLine(student.StudentId);
                    studentCount++;
                    // перевести студентов на следующий курс
                    student.StudentId += 1000;
                    Console.WriteLine(student.StudentId);
                }
                else if (person is Teacher)
                {
                    teacherCount++;
                }

                Console.WriteLine(person);
                Console.WriteLine("------------");
            }

            Console.WriteLine($"Total Persons: {personCount}");
            Console.WriteLine($"Total Students: {studentCount}");
            Console.WriteLine($"Total Teachers: {teacherCount}");

            // Определение количества объектов по типам с использованием GetType
            int personTypeCount = people.Count(p => p.GetType() == typeof(Person));
            int studentTypeCount = people.Count(p => p.GetType() == typeof(Student));
            int teacherTypeCount = people.Count(p => p.GetType() == typeof(Teacher));

            Console.WriteLine($"Using GetType:");
            Console.WriteLine($"Total Persons: {personTypeCount}");
            Console.WriteLine($"Total Students: {studentTypeCount}");
            Console.WriteLine($"Total Teachers: {teacherTypeCount}");

            // Определение количества объектов по типам с использованием is/as
            int personIsCount = people.Count(p => p is Person);
            int studentIsCount = people.Count(p => p is Student);
            int teacherIsCount = people.Count(p => p is Teacher);

            Console.WriteLine($"Using is/as:");
            Console.WriteLine($"Total Persons: {personIsCount}");
            Console.WriteLine($"Total Students: {studentIsCount}");
            Console.WriteLine($"Total Teachers: {teacherIsCount}");
        }
    }
}
