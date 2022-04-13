using System;
using System.Collections.Generic;

namespace lab_6
{
    class Student
    {
        public string Name { get; set; }

        public int Ects { get; set; }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Student Equals");
            return obj is Student student &&
                Name == student.Name &&
                Ects == student.Ects;
        }

        public override int GetHashCode()
        {
            Console.WriteLine("Studnet GetHasCode");
            return HashCode.Combine(Name, Ects);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ICollection<string> names = new List<string>();
            names.Add("ewa");
            names.Add("karol");
            names.Add("adam");
            names.Add("adam");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine(names.Contains("ewa"));
            Console.WriteLine(names.Remove("adam"));

            //operacje na kolekcji studentów

            ICollection<Student> students = new List<Student>(); //rzutowanie niejawne ze szczegółu na ogół
            students.Add(new Student { Name = "Filip", Ects = 3 });
            students.Add(new Student { Name = "Magda", Ects = 5 });
            students.Add(new Student { Name = "Jan", Ects = 7 });
            students.Add(new Student { Name = "Monika", Ects = 9 });
            foreach (var student in students)
            {
                Console.WriteLine(student.Name + " " + student.Ects);
            }
            Console.WriteLine(students.Contains(new Student() { Name = "Jan", Ects = 7 }));
            Console.WriteLine(students.Remove(new Student() { Name = "Monika", Ects = 9 }));
            List<Student> list = (List<Student>)students; //rzutowanie jawne z ogół na szczegół
            Console.WriteLine(list[0]);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Name);
            }
            list.RemoveAt(2);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Name);
            }
            ISet<string> set = new HashSet<string>();
            Console.WriteLine("--------------------------");
            set.Add("ewa");
            set.Add("karol");
            set.Add("ania");
            Console.WriteLine(set.Contains("ewa"));
            Console.WriteLine(set.Remove("ewa"));
            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("--------------------------");
            ISet<Student> group = new HashSet<Student>(list);
            group.Add(new Student() { Name = "Filip", Ects = 3 });
            foreach (var item in group)
            {
                Console.WriteLine(item.Name+" "+item.Ects);
            }
            Console.WriteLine("--------------------------");
            Console.WriteLine(group.Contains(new Student() { Name="Magda",Ects=5}));
            ISet<int> s1 = new HashSet<int>(new int[] { 1, 2, 5, 6, 7 });
            ISet<int> s2 = new HashSet<int>(new int[] { 4, 7, 9, 8, 3 });
            s1.IntersectWith(s2);
            Console.WriteLine(string.Join(", ",s1));
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            phoneBook.Add("adam", "234512345");
            phoneBook["ewa"] = "345432132";
            phoneBook["karol"] = "999876789";
            Console.WriteLine(phoneBook["ewa"]);
            foreach (var item in phoneBook)
            {
                Console.WriteLine(item.Key+" "+item.Value);
            }
            Dictionary<string, object> semiObj = new Dictionary<string, object>();
            semiObj["name"] = "adam";
            semiObj["points"] = 45;
            semiObj["student"] = list[0];
            string[] arr = {"ewa","adam","karol", "ania","ewa","adam" };
            //podaj ile razy wystepuje kazde imie w tabeli
            Dictionary<string, int> imiona = new Dictionary<string, int>();
            foreach (var item in arr)
            {
                if (imiona.ContainsKey(item))
                {
                    imiona[item]++;

                }
                else
                {
                    imiona.Add(item, 1);
                }

            }
            foreach (var item in imiona)
            {
                Console.WriteLine(item);
            }
        }
    }
}
