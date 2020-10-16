using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class Balkez
    {
        public string Nev { get;private set; }
        public string Elso { get;private set; }
        public string Utolso { get; private set; }
        public int Suly { get;private set; }
        public double Magassag { get;private set; }


        public Balkez(string sor)
        {
            string[] a = sor.Split(';');
            Nev = a[0];
            Elso = a[1];
            Utolso = a[2];
            Suly = Convert.ToInt32(a[3]);
            Magassag = Convert.ToDouble(a[4]);

        }
    }
}
