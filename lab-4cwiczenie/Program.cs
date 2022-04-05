using System;

namespace lab_4cwiczenie
{
    class Program
    {
        static void Main(string[] args)
        {

            Car[] _cars = new Car[]
             {
                 new Car(),
                 new Car(Model: "Fiat", true),
                 new Car(),
                 new Car(Power: 125),
                 new Car(Model: "Fiat", true),
                 new Car(Power: 125),
                 new Car()
             };
            Console.WriteLine(Exercise3.CarCounter(_cars));
            Student[] students = {
              new Student("Kowal","Adam", 'A'),
              new Student("Nowak","Ewa", 'A'),
              new Student("Nowak","Ewa", 'B')
            };
            Exercise4.AssignStudentId(students);
            foreach (var item in students)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine( Exercise1.NextPoint(Direction4.UP, (2, 3), (5, 5)));
        }
    }
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
                Direction4.UP => (krotka.Item1, krotka.Item2 -= 1),
                Direction4.DOWN => (krotka.Item1, krotka.Item2 += 1),
                Direction4.LEFT => (krotka.Item1 -= 1, krotka.Item2),
                Direction4.RIGHT => (krotka.Item1 += 1, krotka.Item2),
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
    record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);


    class Exercise3
    {
        public static int CarCounter(Car[] cars)
        {
            int ilosc = 0;
            int obecnie = 0;
            for (int i = 0; i < cars.Length; i++)
            {
                for (int j = 0; j < cars.Length; j++)
                {
                    if (cars[i].GetHashCode() == cars[j].GetHashCode())
                    {
                        obecnie++;
                    }
                }
                if (obecnie > ilosc) ilosc = obecnie;
                obecnie = 0;
            }
            return ilosc;
        }
    }

}