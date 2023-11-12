using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesPerson
{
    public interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        void Print();
    }


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual void Print()
        {
            Console.WriteLine($"Person: {Name}, Age: {Age}");
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name}, Age: {Age}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Person other = (Person)obj;
            return Name == other.Name && Age == other.Age;
        }

        public override int GetHashCode()
        {
            return (Name + Age).GetHashCode();
        }

        public static bool operator ==(Person person1, Person person2)
        {
            if (ReferenceEquals(person1, person2))
                return true;

            if (person1 is null || person2 is null)
                return false;

            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            return !(person1 == person2);
        }

        public Person this[int index]
        {
            get
            {
                // ваша логика для индексатора (возвращает элемент по индексу)
                return new Person { Name = "Indexed Person", Age = index };
            }
            set
            {
                // ваша логика для индексатора (устанавливает элемент по индексу)
            }
        }

        /// <summary>
        /// 2.	Для классов Person-Student-Teacher реализовать статические методы RandomPerson, RandomStudent,
        /// RandomTeacher, которые возвращают случайного из некоторого статического массива.
        /// </summary>
        private static readonly Random random = new Random();

        public static Person[] PeopleArray = new Person[]
        {
            new Person { Name = "John", Age = 25 },
            new Student { Name = "Alice", Age = 22, Advisor = new Teacher { Name = "Advisor", Age = 35 } },
            new Teacher { Name = "Mr. Smith", Age = 40 },
            new Student { Name = "Advisee", Age = 20, StudentId = 456, Advisor = new Teacher { Name = "Advisor", Age = 35 } },
            new Student { Name = "Another Advisee", Age = 22, StudentId = 789, Advisor = new Teacher { Name = "Advisor", Age = 35 } }
        };

        public static Person RandomPerson()
        {
            int index = random.Next(0, PeopleArray.Length);
            return PeopleArray[index];
        }

        public static Student RandomStudent()
        {
            int index = random.Next(0, PeopleArray.Length);
            // если случайный объект - Student, то вернуть его, иначе повторить выбор
            while (!(PeopleArray[index] is Student))
            {
                index = random.Next(0, PeopleArray.Length);
            }
            return (Student)PeopleArray[index];
        }

        public static Teacher RandomTeacher()
        {
            int index = random.Next(0, PeopleArray.Length);
            // если случайный объект - Teacher, то вернуть его, иначе повторить выбор
            while (!(PeopleArray[index] is Teacher))
            {
                index = random.Next(0, PeopleArray.Length);
            }
            return (Teacher)PeopleArray[index];
        }

    }
    public static class RandomGenerator
    {
        public static Student RandomStudent()
        {
            Random random = new Random();
            return new Student { Name = "Random Student", Age = random.Next(18, 25) };
        }

        public static Teacher RandomTeacher()
        {
            Random random = new Random();
            return new Teacher { Name = "Random Teacher", Age = random.Next(30, 60) };
        }
    }
}
