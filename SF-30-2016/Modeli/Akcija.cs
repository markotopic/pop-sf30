using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Modeli
{
    [Serializable]

    class Akcija
    {
        public int id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public decimal Popust { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool Obrisan { get; set; }
    }
}
