using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class MyModel
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Cena { get; set; }
        public int Kolicina { get; set; }
        public string Proizvodjac { get; set; }
        public DateTime DatumDodavanja { get; set; }
    }
}
