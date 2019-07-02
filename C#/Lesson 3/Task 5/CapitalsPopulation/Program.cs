using System;
using GreatBritain;
using France;
using Germany;

namespace CapitalsPopulation
{
    class Program
    {
        static void Main(string[] args)
        {
            London l = new London();
            Paris p = new Paris();
            Berlin b = new Berlin();
            Console.Title = "Сравнение населения трёх столиц";
            Console.WriteLine("Столицы трёх стран в порядке убывания количества населения:");
            if (l.GetPopulation() > p.GetPopulation() && l.GetPopulation() > b.GetPopulation())
            {
                Console.WriteLine("1) {0} ({1}) - {2} человек", l.GetName(), l.GetCountryName(), l.GetPopulation());
                if (p.GetPopulation() > b.GetPopulation())
                {
                    Console.WriteLine("2) {0} ({1}) - {2} человек", p.GetName(), p.GetCountryName(), p.GetPopulation());
                    Console.WriteLine("3) {0} ({1}) - {2} человек", b.GetName(), b.GetCountryName(), b.GetPopulation());
                }
                else
                {
                    Console.WriteLine("2) {0} ({1}) - {2} человек", b.GetName(), b.GetCountryName(), b.GetPopulation());
                    Console.WriteLine("3) {0} ({1}) - {2} человек", p.GetName(), p.GetCountryName(), p.GetPopulation());
                }
            }
            if (p.GetPopulation() > l.GetPopulation() && p.GetPopulation() > b.GetPopulation())
            {
                Console.WriteLine("1) {0} ({1}) - {2} человек", p.GetName(), p.GetCountryName(), p.GetPopulation());
                if (l.GetPopulation() > b.GetPopulation())
                {
                    Console.WriteLine("2) {0} ({1}) - {2} человек", l.GetName(), l.GetCountryName(), l.GetPopulation());
                    Console.WriteLine("3) {0} ({1}) - {2} человек", b.GetName(), b.GetCountryName(), b.GetPopulation());
                }
                else
                {
                    Console.WriteLine("2) {0} ({1}) - {2} человек", b.GetName(), b.GetCountryName(), b.GetPopulation());
                    Console.WriteLine("3) {0} ({1}) - {2} человек", l.GetName(), l.GetCountryName(), l.GetPopulation());
                }
            }
            if (b.GetPopulation() > l.GetPopulation() && b.GetPopulation() > p.GetPopulation())
            {
                Console.WriteLine("1) {0} ({1}) - {2} человек", b.GetName(), b.GetCountryName(), b.GetPopulation());
                if (l.GetPopulation() > p.GetPopulation())
                {
                    Console.WriteLine("2) {0} ({1}) - {2} человек", l.GetName(), l.GetCountryName(), l.GetPopulation());
                    Console.WriteLine("3) {0} ({1}) - {2} человек", p.GetName(), p.GetCountryName(), p.GetPopulation());
                }
                else
                {
                    Console.WriteLine("2) {0} ({1}) - {2} человек", p.GetName(), p.GetCountryName(), p.GetPopulation());
                    Console.WriteLine("3) {0} ({1}) - {2} человек", l.GetName(), l.GetCountryName(), l.GetPopulation());
                }
            }
            Console.ReadKey();
        }
    }
}