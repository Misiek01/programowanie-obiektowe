using System;

namespace lab_2
{
    public abstract class Product
    {
        public virtual decimal Price { get; init; }
        public abstract decimal GetVatPrice();
    }




    class Computer : Product
    {
        public decimal Vat { get; init; }

        public override decimal GetVatPrice()
        {
            return Price * Vat / 100m;
        }
    }

    class Paint : Product
    {
        public decimal Vat { get; init; }

        public decimal Capacity { get; init; }
        public decimal PriceUnit { get; init; }

        public override decimal GetVatPrice()
        {
            return PriceUnit * Capacity * Vat / 100m;
        }

        public override decimal Price
        {
            get
            {
                return PriceUnit * Capacity;
            }
        }
    }
    class Butter : Product
    {
        public override decimal GetVatPrice()
        {
            return 2m;
        }
    }
    abstract class Person
    {
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public DateTime BirthDate
        {
            get => birthDate;
        }
    }
    class Student : Person
    {
        private int studentID;
        public int StudentID
        {
            get => studentID;
        }
    }
    class Lecturer : Person
    {
        private int academicDegree;
        public int AcademicDegree
        {
            get => academicDegree;
            set
            {
                academicDegree = value;
            }
        }
    }
    class StudentLectureGroup
    {
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }
    }
    interface IFly
    {
        void Fly();
    }
    interface ISwim
    {
        void Swim();
    }
    abstract class Animal {
    }

    class Duck : Animal, IFly, ISwim
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
    class Hydroplane : IFly, ISwim
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product[] shop = new Product[4];
            shop[0] = new Computer() { Price = 2000m, Vat = 23m };
            shop[1] = new Paint() { PriceUnit = 12, Capacity = 5, Vat = 8 };
            shop[2] = new Computer() { Price = 2400m, Vat = 23m };
            shop[3] = new Butter();
            decimal sumVat = 0;
            decimal sumPrice = 0;
            foreach (var product in shop)
            {
                sumVat += product.GetVatPrice();
                sumPrice += product.Price;
                //Starsza wersja testowania czy jest instacją
                if (product is Computer)
                {
                    Computer comp = (Computer)product;
                }
                //Nowsza wersja testowania czy jest instacją
                Computer computer = product as Computer;
                Console.WriteLine(computer?.Vat);
            }
            Console.WriteLine(sumVat);
            Console.WriteLine(sumPrice);
            IFly[] flynigObject = new IFly[2];
            Duck duck = new Duck();
            flynigObject[0] = duck;
            flynigObject[1] = new Hydroplane();
            ISwim[] swimingObject = new ISwim[2];
            swimingObject[0] = duck;
            swimingObject[1] = (ISwim)flynigObject[1];
            IAggregate aggregate;
            IIterator iterator = aggregate.CreateIterator();
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.GetNext());
            }
        }
    }
    interface IAggregate
    {
        IIterator CreateIterator();
    }
    interface IIterator
    {
        bool HasNext();
        int GetNext();
    }
}