using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_8
{
    record Student(string Name, char Team,int Ects);
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 4, 6, 1, 4, 7, 8, 3, 4, 9 };
            Predicate<int> oddPredicate = n =>
            {
              //  Console.WriteLine("Obliczanie predykatu dla n " + n);
                return n % 2 == 1;
            };
            Console.WriteLine("Przed wykonaniem wiersza 1");
            IEnumerable<int> odds = from n in ints
                                    where oddPredicate.Invoke(n)
                                    select n;
            Console.WriteLine("Przed wykoaniem wiersza 2");
            odds = from n in odds
                   where n > 5
                   select n;
            //rozbudowany predykat
            int limit = 5;
            odds = from n in odds
                   where n % 2 == 1 && n > limit
                   select n;
            Console.WriteLine(string.Join(", ", odds));
            string[] strings = { "aa", "bb", "ccc", "fff", "ee", "gggg" };
            //zapisz wyrazenie linq ktore zwroci liste lanuchów o dlugosci 2 znakow
            odds = from a in strings
                   select a.Length;
            Console.WriteLine(string.Join(", ",odds));

            Console.WriteLine(string.Join(", ",
                from s in strings
                orderby s descending
                select s
                ));
            //zapisz wyrazenie ktore podniesie do kwadratu kazda liczbe z ints i posotuje wyniki malejaco
            Console.WriteLine(string.Join(", ",
                from i in ints
                orderby i descending
                select i*i
                ));
            Student[] students =
            {
                new Student("Ewa",'A',54),
                new Student("Karol",'B',31),
                new Student("Ewa",'B',38),
                new Student("Tomek",'B',44),
                new Student("Kasia",'A',24),
                new Student("Karol",'A',34),
            };
            Console.WriteLine(string.Join(", ",
                from s in students
                group s by s.Team into team
                select (team.Key,team.Count())
                ));
            IEnumerable<IGrouping<char, Student>> Teams = from s in students
            group s by s.Team;
            foreach (var item in Teams)
            {
                Console.WriteLine(item.Key+" "+string.Join("\n",item));
            }
            //wykonaj zastawienie ile razy kazdy z wyrazow wystepuje w sentence
            string sentense = "ala ma kota ala lubi koty tomek lubi psy";
            string[] ss = sentense.Split(" ");
            //Console.WriteLine(string.Join(", ", do konczyc 
            //   from s in ss
            //   group s by ss into team
            //   select (team.Key, team.Count())
            //   ));
            IEnumerable<int> enumerable = ints
                .Where(n => n % 2 == 1)
                .OrderBy(x=>x)
                .Select(y=>y*y);
            Console.WriteLine(string.Join(", ",enumerable));
            students.GroupBy(student => student.Team).Select(gr => (gr.Key, gr.Count()));
            IOrderedEnumerable<Student> sorted = students.OrderBy(studen => studen.Name).ThenByDescending(student => student.Ects);
            Console.WriteLine(string.Join("\n", sorted));
            //posortuj Łancuchy w string wg dlugosci a lanucuhcy o tej samej dlugosci rosnoca 
            Console.WriteLine(string.Join("\n",
                strings.OrderBy(stringg => stringg.Length).ThenBy(stringg => stringg)
                ));
           int suma= Enumerable.
                Range(0, 10).
                Where(n => n % 2 == 0).
                Sum();
            int sumaKwadratow= Enumerable.
                Range(0, 10)
                .Where(n => n % 2 == 0)
                .Select(n=>n*n)
                .Sum();
            Console.WriteLine(sumaKwadratow);
            Student studentA = students.FirstOrDefault(s => s.Name.StartsWith("A"));
            Console.WriteLine(studentA);
            Random random = new Random();
            random.Next(5);
            //wygenerowac tablice 100 liczb losowych o wartosci od 0 do 9
        }
    }
}
