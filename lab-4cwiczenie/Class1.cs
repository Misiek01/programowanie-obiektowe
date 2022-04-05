using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4cwiczenie
{
    record Student(string LastName, string FirstName, char Group, string StudentId = "");
    class Exercise4
    {
        public static void AssignStudentId(Student[] students)
        {
            string stID = "";
            int A = 1;
            int B = 1;
            int C = 1;
            for (int i = 0; i < students.Length; i++)
            {
                stID += students[i].Group;
                stID += students[i] switch
                {
                    { Group: 'A' } => A++.ToString("D3"),
                    { Group: 'B' } => B++.ToString("D3"),
                    { Group: 'C' } => C++.ToString("D3"),
                    _ => -1
                };
                students[i] = students[i] with { StudentId = stID };
                stID = "";

            }
        }
    }
    enum Direction4
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
    class Exercise1
    {
        public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
        {
            var krotka = point;
            krotka = direction switch
            {
                Direction4.UP => (krotka.Item1, krotka.Item2-=1),
                Direction4.DOWN => (krotka.Item1, krotka.Item2+=1),
                Direction4.LEFT => (krotka.Item1-=1, krotka.Item2),
                Direction4.RIGHT => (krotka.Item1+=1, krotka.Item2),
                _ => (krotka.Item1, krotka.Item2)
            };
            if (krotka.Item1 > screenSize.Item1 || krotka.Item2 > screenSize.Item2 ||
                krotka.Item1 < 0 || krotka.Item2 < 0)
            {
                return point;
            }
            return krotka;
        }
    }
}
