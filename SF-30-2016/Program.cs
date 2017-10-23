using SF_30_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016
{
    class Program
    {
        public static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>;

        static void Main(string[] args)
        {
            Salon s1 = new Salon()
            {
                Id = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg dositeja Obradovica 6",
                BrojZiroRacuna = "840-214214214-83",
                Email = "kontakt@uns.ac.rs",
                MaticniBroj = 12244245,
                PIB = "3324443",
                Telefon = "021/445-342",
                WebSajt = "http://ftn.uns.ac.rs"
            };

            var sofaTipNamestaja = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Sofa"
            };

            Console.WriteLine($"Dobrodosli u salon namestaja{s1.Naziv}.");
            IspisiGlavniMeni();
            Console.ReadLine();
        }

        private static void IspisiGlavniMeni()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("1.Rad sa namestaja.");
                Console.WriteLine("2.Rad sa tipom namestaja.");
                Console.WriteLine("0. Izlaz");
            } while (izbor < 0 || izbor > 2);

        }

        private static void IzlistajNamestaj()
        {
            int index = 0;
            Console.WriteLine("=== Listing namestaja ===");

            foreach (var namestaj in Namestaj)
            {
                Console.WriteLine($"{++index}. {namestaj.Naziv}, cena: {namestaj.JedinicnaCena}");
            }
        }
    }
}
