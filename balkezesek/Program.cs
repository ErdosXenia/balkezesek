using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace balkezesek
{
    class Program
    {
        static List<Balkez> balkezek = new List<Balkez>();

        static void feladat2()
        {
            StreamReader sr = new StreamReader("balkezesek.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                balkezek.Add(new Balkez(sr.ReadLine()));
            }
            sr.Close();
        }

        static void feladat3()
        {
            Console.WriteLine("3. Feladat: {0}",balkezek.Count());
        }

        static void feladat4()
        {
            Console.WriteLine("\n4. Feladat:");
            double cm = 0;
            foreach (var b in balkezek)
            {
                if (b.Utolso.Contains("1999-10-"))
                {
                    cm = Math.Round(b.Magassag * 2.54,1);
                    Console.WriteLine($"{b.Nev}, {cm:N1} cm");
                }
            }
        }

        static void feladat56()
        {
            Console.WriteLine("\n5. Feladat: ");
            int evszam = 0;
            bool hibas;
            do
            {
                hibas = false;
                Console.Write("Kérek egy 1990 és 1999 közötti évszámot: ");
                evszam = Convert.ToInt32(Console.ReadLine());
                if (evszam < 1990 || evszam > 1999)
                {
                    hibas = true; 
                    Console.Write("Hibás adat! ");
                }

            } while (hibas);

            Console.Write("\n6. Feladat: ");
            int db = 0;
            double atlag = 0;
            foreach (var b in balkezek)
            {
                if (Convert.ToInt32(b.Elso.Substring(0,4))<=evszam 
                    && 
                    Convert.ToInt32(b.Utolso.Substring(0,4)) >=evszam)
                {
                    db++;
                    atlag += b.Suly;
                }
            }
            Console.WriteLine($"{atlag / db:N2} font");
        }

        static void feladat7()
        {
            var nevek = from b in balkezek
                        orderby b.Nev
                        group b by b.Nev[0] into abc
                        select abc;

            foreach (var abckiir in nevek)
            {
                Console.WriteLine(abckiir.Key);
                foreach (var item  in abckiir)
                {
                    Console.WriteLine($"\t{item.Nev}");
                }
            }
        }

        static void Main(string[] args)
        {
            feladat2();
            feladat3();
            feladat4();
            feladat56();
            feladat7();



            Console.ReadKey();
        }
    }
}
