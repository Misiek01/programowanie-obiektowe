using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lab_5
{
   
    //Cwiczenie 1 (2 punkty)
    //Zmodyfikuj klasę Exercise1 aby implementowała interfesj IEnumerable<T>
    //Zdefiniuj metodę GetEnumerator, aby zwracał kolejno pola Manager, MemberA, MemberB
    //Przykład
    //Exercise1<string> team = new Exercise1(){ Manager: "Adam", MemberA: "Ola", MemberB: "Ewa"};
    //foreach(var member in team){
    //    Console.WriteLine(member);
    //}
    //otrzymamy na ekranie
    //Adam
    //Ola
    //Ewa
    public class Exercise1<T>: IEnumerable<T>
    {
        public T Manager { get; init; }
        public T MemberA { get; init; }
        public T MemberB { get; init; }

        public IEnumerator<T> GetEnumerator()
        {
            yield return Manager;
            yield return MemberA;
            yield return MemberB;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //Cwiczenie 2 (2 punkty)
    //Zdefiniuj indekser dla klasy CurrencyRates, aby umożliwiał przypisania i pobierania notowania dla danej waluty.
    //Zainicjuj tablice _rates, aby jej rozmiar byl równy liczbie stałych wyliczeniowych w klasie Currency i nie wymagał zmiany
    //gdy zostaną dodane następne stałe.
    //Przykład
    //CurrencyRates rates = new CurrencyRates();
    //rates[Currency.EUR] = 4.6m;
    //Console.WriteLine(rates[Currency.EUR]);

    enum Currency
    {
        PLN,
        USD,
        EUR,
        CHF
    }

    class CurrencyRates
    {
        //utwórz tablicę o rozmiarze równym liczbie stalych wyliczeniowych Currency
        private decimal[] _rates = new decimal[Enum.GetValues<Currency>().Length];
        public decimal this[Currency currencyy]
        {
            get
            {
                return _rates[(int)currencyy];
            }
            set
            {
                _rates[(int)currencyy] = value;

            }
        }
    }
}
