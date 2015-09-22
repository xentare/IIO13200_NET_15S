using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä3
{
    public class Pelaaja
    {
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public double Siirtohinta { get; set; }
        public string Seura { get; set; }
        public string KokoNimi
        {
<<<<<<< HEAD
            get { return Etunimi +" "+ Sukunimi + ", " + Seura + " " + Siirtohinta; }
=======
            get { return Etunimi +" "+ Sukunimi + ", " + Seura; }
>>>>>>> origin/master
        }

        public Pelaaja(string Etunimi, string Sukunimi, double Siirtohinta, string Seura)
        {
            this.Etunimi = Etunimi;
            this.Seura = Seura;
            this.Sukunimi = Sukunimi;
            this.Siirtohinta = Siirtohinta;
        }

        override
            public string ToString()
        {
            return KokoNimi;
        }
    }
}
