using System;

namespace lab_2_cwiczenia
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cwiczenie2
            Flyable[] tab =
             {
                new Duck(){},
                new Wasp(){},
                new Wasp(){},
                new Hydroplane(){},
                new Duck(){},
                new Hydroplane(){},
            };
            int ilosc = 0;
            foreach (var flyable in tab)
            {
                
                if (flyable is Swimmingable&& flyable is Flyable)
                {
                    ilosc++;
                }
                
            }
            Console.WriteLine(ilosc);
        }

    }

    //Cwiczenie 1
    public class ElectricScooter : Scooter
    {
        private int batteriesLevel;
        public int BatteriesLevel { get=>batteriesLevel; init 
            {
                batteriesLevel = value;
            }
        }
        public int MaxRange { get; init; }

        public ElectricScooter(int batteriesLevel, int maxRange)
        {
            this.batteriesLevel = batteriesLevel;
            MaxRange = maxRange;
        }

        public void ChargeBatteres()
        {
            batteriesLevel = 100; 
        }
        public override decimal Drive(int distance)
        {
            decimal Proporcje = 100 / MaxRange;
            if (batteriesLevel / distance >= Proporcje && batteriesLevel >= distance * Proporcje)
            {

                batteriesLevel -= (int)(distance * Proporcje);
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            else
            {
                return -1;
            }
        }

    }
    public class KickScooter : Scooter
    {
        public override decimal Drive(int distance)
        {
            throw new NotImplementedException();
        }
    }
    public abstract class Scooter : Vehicle
    {

    }
    public abstract class Vehicle
    {
        public double Weight { get; init; }
        public int MaxSpeed { get; init; }
        protected int _mileage;
        public int Mealeage
        {
            get { return _mileage; }
        }
        public abstract decimal Drive(int distance);
        public override string ToString()
        {
            return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
        }
    }
    //Cwiczenie 2
    public class Wasp : Flyable
    {
        public int Fly(int disntance)
        {
            throw new NotImplementedException();
        }

        public void Land()
        {
            throw new NotImplementedException();
        }

        public void TakeOff()
        {
            throw new NotImplementedException();
        }
    }
    public class Duck : Swimmingable, Flyable
    {
        public int Fly(int disntance)
        {
            throw new NotImplementedException();
        }

        public void Land()
        {
            throw new NotImplementedException();
        }

        public int Swim(int distance)
        {
            throw new NotImplementedException();
        }

        public void TakeOff()
        {
            throw new NotImplementedException();
        }
    }
    public class Hydroplane : Vehicle, Flyable, Swimmingable
    {
        public override decimal Drive(int distance)
        {
            Console.WriteLine("DRIVE");
            return 0;
        }
        public decimal Swim(int distance)
        {
            Console.WriteLine("SWIM");
            return 0;
        }
        public bool TakeOff()
        {
            Console.WriteLine("TAKE OFF");
            return true;
        }
        public decimal Fly(int distance)
        {
            Console.WriteLine("FLY");
            return 0;
        }
        public bool Land()
        {
            Console.WriteLine("LAND");
            return true;
        }

        void Flyable.TakeOff()
        {
            throw new NotImplementedException();
        }

        int Flyable.Fly(int disntance)
        {
            throw new NotImplementedException();
        }

        void Flyable.Land()
        {
            throw new NotImplementedException();
        }

        int Swimmingable.Swim(int distance)
        {
            throw new NotImplementedException();
        }
    }
    interface Driveable
    {
        int Drive(int distance);
    }
    interface Swimmingable
    {
        int Swim(int distance);
    }
    interface Flyable
    {
        void TakeOff();
        int Fly(int disntance);
        void Land();
    }

}
