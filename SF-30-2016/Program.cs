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
        public static List<Korisnik> Korisnik { get; set; } = new List<Korisnik>();

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

            var korisnik1 = new Korisnik()
            {
                Id = 1,
                Ime = "Marko",
                Prezime = "Topic",
                KorisnickoIme = "mare",
                Sifra = "123",
                TipKorisnika = TipKorisnika.Administrator
            };

            Korisnik.Add(korisnik1);
            Namestaj.Add(namestaj1);
            Namestaj.Add(namestaj2);
            TipNamestaja.Add(sofaTipNamestaja);
            TipNamestaja.Add(regalTipNamestaja);

            Console.WriteLine("uname");
            var a = Console.ReadLine();

            Console.WriteLine("pass");
            var b = Console.ReadLine();

            foreach (var item in Korisnik)
            {
                if (a == item.KorisnickoIme && b == item.Sifra)
                {
                    IspisiGlavniMeni();
                }
                else
                {
                    Console.WriteLine("Greska");
                    break;
                }
            }
            
        }

        private static void IspisiGlavniMeni()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Glavni meni ===");
                Console.WriteLine("1. Rad sa namestaja.");
                Console.WriteLine("2. Rad sa tipom namestaja.");
                Console.WriteLine("3. Rad sa prodajom namestaja.");
                Console.WriteLine("4. Rad sa akciskom prodajom.");
                Console.WriteLine("5. Rad sa korisnicima aplikacije.");
                Console.WriteLine("0. Izlaz");
                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 5);

            switch (izbor)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:
                    IspisiMeniTipNamestaja();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
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
                Console.WriteLine("4. Pretraga");
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
                case 4:
                    PretragaNamestaja();
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

            Console.WriteLine("Unesite naziv: ");
            noviNamestaj.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite sifru: ");
            noviNamestaj.Sifra = Console.ReadLine();

            Console.WriteLine("Unesite cenu: ");
            noviNamestaj.JedinicnaCena = double.Parse(Console.ReadLine());
            
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
            Namestaj trazeniNamestaj = null;
            string nazivTrazenogNamestaja = "";

            do
            {
                Console.WriteLine("Unesite naziv namestaja: ");
                nazivTrazenogNamestaja = Console.ReadLine();

                foreach (var namestaj in Namestaj)
                {
                    if (namestaj.Naziv == nazivTrazenogNamestaja)
                    {
                        trazeniNamestaj = namestaj;
                    }
                }

            } while (trazeniNamestaj == null);

            Console.WriteLine("Unesite novi naziv namestaja: ");
            trazeniNamestaj.Naziv = Console.ReadLine();

            Console.WriteLine("Unesite novu cenu namestaja: ");
            trazeniNamestaj.JedinicnaCena = double.Parse(Console.ReadLine());

            IspisiMeniNamestaja();
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

        private static void PretragaNamestaja()
        {
            Namestaj trazeniNamestaj = null;
            string nazivTrazenogNamestaja = "";

            do
            {
                Console.WriteLine("Unesite naziv namestaja: ");
                nazivTrazenogNamestaja = Console.ReadLine();

                foreach (var namestaj in Namestaj)
                {
                    if (namestaj.Naziv == nazivTrazenogNamestaja)
                    {
                        trazeniNamestaj = namestaj;
                    }
                }

            } while (trazeniNamestaj == null);

            Console.WriteLine("=== Trazeni namestaja ===");
            Console.WriteLine($"{trazeniNamestaj.Naziv}, cena: {trazeniNamestaj.JedinicnaCena}");
            IspisiMeniNamestaja();

        }

        private static void IspisiMeniTipNamestaja()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni namestaja ===");
                Console.WriteLine("1. Izlisaj tipove namestaj");
                Console.WriteLine("2. Dodaj novi tip namestaj");
                Console.WriteLine("3. Izmeni postojeci tip namestaj");
                Console.WriteLine("4. Pretraga");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            } while (izbor < 0 || izbor > 4);

            switch (izbor)
            {
                case 0:
                    IspisiGlavniMeni();
                    break;
                case 1:
                    IzlistajTipNamestaja();
                    break;
                case 2:
                    DodavanjeNovogTipa();
                    break;
                case 3:
                    IzmenaTipaNamestaja();
                    break;
                case 4:
                    PretragaTipaNamestaja();
                    break;
                default:
                    break;
            }
        }

        private static void PretragaTipaNamestaja()
        {
            throw new NotImplementedException();
        }

        private static void IzmenaTipaNamestaja()
        {
            throw new NotImplementedException();
        }

        private static void DodavanjeNovogTipa()
        {
            throw new NotImplementedException();
        }

        private static void IzlistajTipNamestaja()
        {
            int index = 0;
            Console.WriteLine("=== Listing tipa namestaja ===");

            foreach (var tip in TipNamestaja)
            {
                Console.WriteLine($"{++index}. {tip.Naziv}, cena: {tip.JedinicnaCena}");
            }
            IspisiMeniNamestaja();
        }



    }
}
