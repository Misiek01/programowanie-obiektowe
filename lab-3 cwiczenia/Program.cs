using System;

namespace lab_3_cwiczenia
{
    class Program
    {
        static void Main(string[] args)
        {
            Container<Bottle> a = new(3);
            Bottle butelka =new("Naleczowianka");
            Bottle butelka2 =new("Mineralna");
            Bottle butelka3 =new("Zywiec zdroj");
            a.dodanie(butelka);
            a.dodanie(butelka2);
            a.dodanie(butelka3);
            Console.WriteLine(a._array[2].ToString());
            Console.WriteLine(a.iloscWSrodku());
            a.usuniecie(2);
            Console.WriteLine(a.iloscWSrodku());
        }
    }
    public class Container<T> where T : Bottle,new()
    {
        internal T[] _array;
        private int Wielkosc;

        public Container( int wielkosc)
        {
            _array = new T[wielkosc];
            Wielkosc = wielkosc;
        }

        public void dodanie(T value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == null)
                {
                    _array[i] = value;
                    break;
                }
            }

        }
        public int iloscWSrodku()
        {
            int ilosc = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == null)
                {
                    break;
                }
                ilosc++;
            }
            return ilosc;
        }
        public void usuniecie(int index)
        {
            int ilosc = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] != null)
                {
                    ilosc++;
                }
            }
            if (ilosc < 0)
            {
                Console.WriteLine("Brak elementu do usuniecia");
                return;
            }
            _array[index] = null;

        }
    }
    public class Bottle
    {
        public string name;

        public Bottle(string name)
        {
            this.name = name;
        }
        public Bottle()
        {
            
        }
        public override string ToString()
        {
            return name;
        }
    }
}
