using System;

namespace lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Degree ocena = Degree.Dostateczny;
            //Console.WriteLine(ocena);
            //Console.WriteLine((int)ocena);
            //string[] vs = Enum.GetNames<Degree>();
            //Console.WriteLine(string.Join(", ", vs));
            //Degree[] degrees = Enum.GetValues<Degree>();
            //Console.WriteLine(string.Join(", ", degrees));
            //foreach (Degree d in degrees)
            //{
            //    Console.WriteLine($"{d} {(int)d}");
            //}
            //Console.WriteLine("Wpisz ocenę:");
            //string input = Console.ReadLine();

            //try
            //{
            //    Degree degree = Enum.Parse<Degree>(input);
            //    Console.WriteLine($"Wpisałeś {degree} o wartości {(int)degree}");
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine("Wpisałeś nieznana wartość");
            //}
            //string usDegree;
            //switch (ocena)
            //{
            //    case Degree.BardzoDobry:
            //        usDegree = "A";
            //        break;
            //    case Degree.Dobry:
            //        usDegree = "B";
            //        break;
            //    default:
            //        break;
            //}
            //usDegree = ocena switch
            //{
            //    Degree.BardzoDobry => "A",
            //    Degree.DobryPlus => "B",
            //    Degree.Dobry => "C",
            //    Degree.DostatecznyPlus => "D",
            //    Degree.Dostateczny => "E",
            //    _ => "F"
            //};
            //Console.WriteLine(usDegree);
            //int points = 67;
            //Degree result;
            //if (points >= 50 && points < 60)
            //{
            //    result = Degree.Dostateczny;
            //}
            //result = points switch
            //{
            //    >= 50 and < 60 => Degree.Dostateczny,
            //    >= 60 and < 70 => Degree.DostatecznyPlus,
            //    >= 70 and < 80 => Degree.Dobry,
            //    >= 80 and < 90 => Degree.DobryPlus,
            //    >= 90 and < 101 => Degree.BardzoDobry,
            //    _ => Degree.Niedostateczny
            //};
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
            Console.WriteLine( Exercise3.CarCounter(_cars));
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
            //Student[] students =
            //{
            //    new Student(Name:"Karol",Point:120,Grup:'E'),
            //new Student(Name: "Ewa", Point: 121, Grup: 'A'),
            //new Student(Name: "Brajan", Point: 78, Grup: 'B'),
            //new Student(Name: "Jessica", Point: 100, Grup: 'E')
            //};
            //Console.WriteLine(students[0] == new Student("Karol", 120, 'E'));
            //foreach (Student st in students)
            //{
            //    Console.WriteLine(st);
            //}
            //(string, bool)[] results = new (string, bool)[students.Length];
            //for (int i = 0; i < students.Length; i++)
            //{
            //    Student st = students[i];
            //    results[i] = (st.Name,
            //        st switch
            //        {
            //            { Point: >= 100, Grup: 'E' } => true,
            //            { Point: >= 50, Grup: 'B' } => true,
            //            { Point: >= 70, Grup: 'A' } => true,
            //            _ => false
            //        }
            //    );
            //}
            //foreach (var s in results)
            //{
            //    Console.WriteLine($"{s.Item1},czy zdał: {s.Item2}");
            //}
        }


    }
    //record Student(string Name, int Point, char Grup);
    enum Degree
    {
        BardzoDobry = 50,
        DobryPlus = 45,
        Dobry = 40,
        DostatecznyPlus = 35,
        Dostateczny = 30,
        Niedostateczny = 20
    }


    enum Direction8
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        UP_LEFT,
        DOWN_LEFT,
        UP_RIGHT,
        DOWN_RIGHT
    }

    enum Direction4
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    //Cwiczenie 1
    //Zdefiniuj metodę NextPoint, która powinna zwracać krotkę ze współrzędnymi piksela przesuniętego jednostkowo w danym kierunku względem piksela point.
    //Krotka screenSize zawiera rozmiary ekranu (width, height)
    //Przyjmij, że początek układu współrzednych (0,0) jest w lewym górnym rogu ekranu, a prawy dolny ma współrzęne (witdh, height) 
    //Pzzykład
    //dla danych wejściowych 
    //(int, int) point1 = (2, 4);
    //Direction4 dir = Direction4.UP;
    //var point2 = NextPoint(dir, point1);
    //w point2 powinny być wartości (2, 3);
    //Jeśli nowe położenie jest poza ekranem to metoda powinna zwrócić krotkę z point
    class Exercise1
    {
        public static (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
        {
            var krotka = point;
            krotka=direction switch
            {
                Direction4.UP=>(krotka.Item1,krotka.Item2--),
                Direction4.DOWN=>(krotka.Item1,krotka.Item2++),
                Direction4.LEFT=>(krotka.Item1--,krotka.Item2),
                Direction4.RIGHT=>(krotka.Item1++,krotka.Item2),
                _=> (krotka.Item1, krotka.Item2)
            };
            if (krotka.Item1>screenSize.Item1||krotka.Item2>screenSize.Item2||
                krotka.Item1<0||krotka.Item2<0)
            {
                return point;
            }
            return krotka;
        }
    }
    //Cwiczenie 2
    //Zdefiniuj metodę DirectionTo, która zwraca kierunek do piksela o wartości value z punktu point. W tablicy screen są wartości
    //pikseli. Początek układu współrzędnych (0,0) to lewy górny róg, więc punkt o współrzęnych (1,1) jest powyżej punktu (1,2) 
    //Przykład
    // Dla danych weejsciowych
    // static int[,] screen =
    // {
    //    {1, 0, 0},
    //    {0, 0, 0},
    //    {0, 0, 0}
    // };
    // (int, int) point = (1, 1);
    // po wywołaniu - Direction8 direction = DirectionTo(screen, point, 1);
    // w direction powinna znaleźć się stała UP_LEFT
    class Exercise2
    {
        static int[,] screen =
        {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

        private static (int, int) point = (1, 1);

        private Direction8 direction = DirectionTo(screen, point, 1);

        public static Direction8 DirectionTo(int[,] screen, (int, int) point, int value)
        {
            throw new NotImplementedException();
        }
    }

    //Cwiczenie 3
    //Zdefiniuj metodę obliczającą liczbę najczęściej występujących aut w tablicy cars
    //Przykład
    //dla danych wejściowych
    // Car[] _cars = new Car[]
    // {
    //     new Car(),
    //     new Car(Model: "Fiat", true),
    //     new Car(),
    //     new Car(Power: 100),
    //     new Car(Model: "Fiat", true),
    //     new Car(Power: 125),
    //     new Car()
    // };
    //wywołanie CarCounter(Car[] cars) powinno zwrócić 3
    record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);

    class Exercise3
    {
        public static int CarCounter(Car[] cars)
        {
            int ilosc = 0;
            int obecnie = 0;
            for (int i = 0; i < cars.Length; i++)
            {
                for (int j = 0; j <cars.Length; j++)
                {
                    if (cars[i].GetHashCode()==cars[j].GetHashCode())
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

    record Student(string LastName, string FirstName, char Group, string StudentId = "");
    //Cwiczenie 4
    //Zdefiniuj metodę AssignStudentId, która każdemu studentowi nadaje pole StudentId wg wzoru znak_grupy-trzycyfrowy-numer.
    //Przykład
    //dla danych wejściowych
    //Student[] students = {
    //  new Student("Kowal","Adam", 'A'),
    //  new Student("Nowak","Ewa", 'A')
    //};
    //po wywołaniu metody AssignStudentId(students);
    //w tablicy students otrzymamy:
    // Kowal Adam 'A' - 'A001'
    // Nowal Ewa 'A'  - 'A002'
    //Należy przyjąc, że są tylko trzy możliwe grupy: A, B i C
    class Exercise4
    {
        public static void AssignStudentId(Student[] students)
        {
            string stID ="";
            int A = 1;
            int B = 1;
            int C = 1;
            for (int i = 0; i < students.Length; i++)
            {
                stID += students[i].Group;
                stID += students[i] switch
                {
                    {Group:'A' }=>A++.ToString("D3"),
                    {Group:'B' }=>B++.ToString("D3"),
                    {Group:'C' }=>C++.ToString("D3"),
                    _=>-1
                };
                students[i] = students[i] with {StudentId= stID};
                stID = "";
                
            }
        }
    }
}
