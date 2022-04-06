using System;
using System.Collections;
using System.Collections.Generic;
namespace lab_5
{
    record Ingredient
    {
        public double Colories { get; init; }
        public string Name { get; init; }

    }
    class Sandwitch : IEnumerable<Ingredient>
    {
        public Ingredient Bread { get; init; }
        public Ingredient Butter { get; init; }
        public Ingredient Salad { get; init; }
        public Ingredient Ham { get; init; }

        public IEnumerator<Ingredient> GetEnumerator()
        {
            //return new SandwitchEnumerator(this);
            yield return Bread;//Zwrócone w current po pierwszym wywołaniu MoveNext
            yield return Butter;//ZZwrocone w current po drugim wywołaniu MoveNext
            yield return Ham;
            yield return Salad;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Parking : IEnumerable<string>
    {
        private String[] _arr = { "GL789", null, "TKL9890", null, "KR23131", null, null, "WRX0231", null };
        public string this[char slot]
        {

            get
            {
                //czy slot jest miedy 'A' a 'Z'
                return _arr[slot - 'A'];
            }
            set
            {
                _arr[slot - 'A'] = value;
            }

        }
        public string this[int index]
        {
            get
            {
                return _arr[index];
            }
            set
            {
                _arr[index] = value;
            }

        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string car in _arr)
            {
                if (car != null)
                {
                    yield return car;
                }
                
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class SandwitchEnumerator : IEnumerator<Ingredient>
    {
        private Sandwitch _sandwitch;
        int counter = -1;
        public SandwitchEnumerator(Sandwitch sandwitch)
        {
            _sandwitch = sandwitch;
        }

        public Ingredient Current
        {
            get
            {
                return counter switch
                {
                    0 => _sandwitch.Bread,
                    1 => _sandwitch.Butter,
                    2 => _sandwitch.Ham,
                    3 => _sandwitch.Salad,
                    _ => null
                };

            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            return ++counter < 4;

        }

        public void Reset()
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sandwitch sandwitch = new Sandwitch
            {
                Bread = new Ingredient() { Colories = 100, Name = "Bułka wrocławska" },
                Ham = new Ingredient() { Colories = 400, Name = "Z kotła" },
                Salad = new Ingredient() { Colories = 10, Name = "Lodowa" },
                Butter = new Ingredient() { Colories = 120, Name = "Śmietankowe" }
            };
            IEnumerator<Ingredient> enumerator = sandwitch.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            foreach (Ingredient ingradient in sandwitch)
            {
                Console.WriteLine(ingradient);
            }
            Parking parking = new Parking();
            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine(string.Join(',', parking));
            Console.WriteLine(parking['C']);
            parking['A'] = "TT2323";
            parking[2] = "K1AA";
            Console.WriteLine(string.Join(',',parking));
            Exercise1<string> team = new Exercise1<string> { Manager = "Adam", MemberA = "Ola", MemberB = "Ewa" };
            foreach (var member in team)
            {
                    Console.WriteLine(member);
                }
            }
        
        }
}
