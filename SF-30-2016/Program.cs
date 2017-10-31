using SF_30_2016.Model;
using SF_30_2016.Modeli;
using SF_30_2016.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016
{
    class Program
    {
        public static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
        static List<TipNamestaja> TipNamestaja { get; set; } = new List<TipNamestaja>();

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

            var regalTipNamestaja = new TipNamestaja()
            {
                Id = 2,
                Naziv = "Regal"
            };

            var namestaj1 = new Namestaj()
            {
                Id = 1,
                Naziv = "Sofa",
                Sifra = "SF sifra za sofe",
                JedinicnaCena = 28,
                TipNamestaja = sofaTipNamestaja,
                KolicinaUMagacinu = 2
            };

            var namestaj2 = new Namestaj()
            {
                Id = 2,
                Naziv = "Regal",
                Sifra = "SF sifra za regale",
                JedinicnaCena = 18,
                TipNamestaja = regalTipNamestaja,
                KolicinaUMagacinu = 4
            };

            Namestaj.Add(namestaj1);
            Namestaj.Add(namestaj2);
            Console.WriteLine("Serializacija...");
            GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj1);
            GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj2);
            //List<Namestaj> ln2 = GenericSerializer.DeSerialize<Namestaj>("namestaj.xml");
            Console.WriteLine("Zavrsena serializacija");
            Console.ReadLine();

            // Console.WriteLine($"Dobrodosli u salon namestaja{s1.Naziv}.");
            // IspisiGlavniMeni();
            // Console.ReadLine();
            List<Namestaj> namestaj = Projekat.Instace.Namestaj;
            namestaj.Add(new Namestaj() { Id = 12, Naziv = "Novi Namestaj" });
            Projekat.Instace.Namestaj = namestaj;
            foreach


        }

        private static void IspisiGlavniMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Glavni meni ===");
                Console.WriteLine("1. Rad sa namestaja.");
                Console.WriteLine("2. Rad sa tipom namestaja.");
                Console.WriteLine("0. Izlaz");
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 2);

            switch (izbor)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    IspisiMeniNamestaja();
                    break;
                default:
                    break;
            }

        }

        private static void IspisiMeniNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("=== Meni namestaja ===");
                Console.WriteLine("1. Izlisaj namestaj");
                Console.WriteLine("2. Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni postojeci namestaj");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    IspisiGlavniMeni();
                    break;
                case 1:
                    IzlistajNamestaj();
                    break;
                case 2:
                    DodavanjeNovogNamestaja();
                    break;
                case 3:
                    IzmenaNamestaja();
                    break;
                default:
                    break;
            }
        }

        private static void DodavanjeNovogNamestaja()
        {
            Console.WriteLine("=== Dodavanje novog namestaja ===");
            var noviNamestaj = new Namestaj();
            noviNamestaj.Id = Namestaj.Count + 1;
            //noviNamestaj.Id = noviNamestaj.GetHashCode();

            Console.WriteLine("Unesite naziv: ");
            noviNamestaj.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite cenu: ");
            noviNamestaj.JedinicnaCena = double.Parse(Console.ReadLine());

            Console.WriteLine("Unesite sifru: ");
            noviNamestaj.Sifra = Console.ReadLine();

            Console.WriteLine("Unesite kolicinu: ");
            noviNamestaj.KolicinaUMagacinu = int.Parse(Console.ReadLine());

            string nazivTipaNamestaja = "";
            TipNamestaja trazeniTipNamestaja = null;
            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                nazivTipaNamestaja = Console.ReadLine();
                foreach (var tipNamestaja in TipNamestaja)
                {
                    if (tipNamestaja.Naziv == nazivTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);


            noviNamestaj.TipNamestaja = trazeniTipNamestaja;

            Namestaj.Add(noviNamestaj);

            IspisiMeniNamestaja();
        }

        private static void IzmenaNamestaja()
        {
            throw new NotImplementedException();
        }

        private static void IzlistajNamestaj()
        {
            int index = 0;
            Console.WriteLine("=== Listing namestaja ===");

            foreach (var namestaj in Namestaj)
            {
                Console.WriteLine($"{++index}. {namestaj.Naziv}, cena: {namestaj.JedinicnaCena}");
            }
            IspisiMeniNamestaja();
        }

        

    }
}
