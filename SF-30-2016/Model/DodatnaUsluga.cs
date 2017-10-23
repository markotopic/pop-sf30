using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Model
{
    public class DodatnaUsluga
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double CenaUsluge { get; set; }
        public bool Obrisan { get; set; }
    }
}
