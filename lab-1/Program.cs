using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person osoba = Person.OfName("Adam");
            Console.WriteLine(osoba);
            osoba.Equals(2);
            Money money = Money.Of(12, Currency.PLN) ?? Money.Of(0, Currency.PLN);
            Console.WriteLine(money.Value + " " + money.Currency);
            Money result = money * 0.22m;
            Console.WriteLine(result.Value);
            result = (money + Money.Of(5, money.Currency)) * 0.5m;
            Console.WriteLine(result.Value);
            if (money > result)
            {
                Console.WriteLine("Money większe");
            }
            else
            {
                Console.WriteLine("Result większe");
            }
            if (money.Equals(Money.Of(12, Currency.PLN)))
            {
                Console.WriteLine("Równe");
            }
            else
            {
                Console.WriteLine("Różne");
            }
            int a = 10;
            long b = 10L;
            b = a;  //nie jawne
            a = (int)b;  //jawne 
            decimal price = money;
            double cost = (double)money;
            float c = (float)money;
            Console.WriteLine(money.ToString());
            Console.WriteLine(money.Equals(Money.Of(12,Currency.PLN)));
            IEquatable<Money> ie = money;
            Money[] pricies =
            {
                Money.Of(5,Currency.PLN),
                Money.Of(3,Currency.USD),
                Money.Of(15,Currency.PLN),
                Money.Of(25,Currency.EUR),
                Money.Of(54,Currency.PLN),
                Money.Of(8,Currency.EUR),
            };
            Array.Sort(pricies);
            Console.WriteLine("SORT");
            foreach(var p in pricies) 
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
    public enum Currency
    {
        PLN = 1,
        USD = 2,
        EUR = 3
    }
    public class Money : IEquatable<Money>, IComparable<Money>
    {
        private readonly decimal _value;

        private readonly Currency _currency;

        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }
        public decimal Value { get => _value; }
        public Currency Currency { get => _currency; }
        public static Money Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }
        public static Money OfWithException(decimal value, Currency currency)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return new Money(value, currency);
            }
        }
        public static Money operator *(Money money, decimal factor)
        {
            return Money.Of(money.Value * factor, money.Currency);
        }
        public static Money operator +(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return Money.Of(a.Value + b.Value, a.Currency);
        }

        private static void IsSameCurrencies(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Diffrent currencies!");
            }
        }

        public static bool operator <(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return a.Value < b.Value;
        }

        public static bool operator >(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return a.Value > b.Value;
        }
        public static implicit operator decimal(Money money)//nie jawne
        {
            return money.Value;
        }
        public static explicit operator double(Money money) //jawne
        {
            return (double)money.Value;
        }

        

        public override string ToString()
        {
            return $"Value: {_value}, Currency: {_currency}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public bool Equals(Money other)
        {
            return other != null &&
                   _value == other._value &&
                   _currency == other._currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value, _currency);
        }

        public int CompareTo(Money other)
        {
            int curResults = _currency.CompareTo(other.Currency);
            if (curResults==0)
            {
                return -_value.CompareTo(other._value);
            }
            else
            {
                return curResults;
            }
        }
    }

    public class Person
    {
        private string firstName;
        public Person(string _firstName)
        {
            firstName = _firstName;
        }
        public static Person OfName(string name)
        {
            if (name != null && name.Length >= 2)
            {
                return new Person(name);

            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != null && value.Length >= 2)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Imie zbyt krótkie");
                }
            }

        }
        public override string ToString()
        {
            return $"Imie: {FirstName}";
        }
    }
}
