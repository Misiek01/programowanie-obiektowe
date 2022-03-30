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