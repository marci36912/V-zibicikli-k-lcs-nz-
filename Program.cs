using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace kolcsonzes
{
    class Program
    {
        static List<Kolcsonzes> lista = new List<Kolcsonzes>();
        static void Main(string[] args)
        {
            beolv();
            otodik();
            hatodik();
            hetedik();
            nyolcadik();
            kilencedik();
            tizedik();

            Console.ReadLine();
        }

        //megszamoljuk a tipusokat
        static void tizedik()
        {
            /*var tmp = lista.GroupBy(x => x.Azon).ToList();
            tmp = tmp.OrderBy(x => x.Key).ToList();

            int n;
            List<int> szam = new List<int>();

            foreach (var item in tmp)
            {
                n = 0;
                foreach (var itemL in lista)
                {
                    if (item.Key == itemL.Azon)
                    {
                        n++;
                    }
                }
                szam.Add(n);
            }
            //erre nem tudok meg egyszerubb modszert sajnos
            for (int i = 0; i < tmp.Count; i++)
            {
                Console.WriteLine($"{tmp[i].Key} - {szam[i]}");
            }
            */
            
            foreach (var i in k.GroupBy(x=>x.azon).OrderBy(x=>x.Key))
            {
                Console.WriteLine($"    {i.Key} - {i.Count()}");
            }

            //Ez az egész feladat 4 sorban.
            //Koszonom Tominak a segitseget ebben a feladatban!
        }
        //kiirjuk az F-eket egy txt-be
        static void kilencedik()
        {
            var f = lista.Where(x => x.Azon == 'F').ToList();

            try
            {
                StreamWriter wr = new StreamWriter("F.txt");

                foreach (var item in f)
                {
                    wr.WriteLine($"{item.Eo}:{item.Ep}-{item.Vo}:{item.Vp} : {item.Nev}");
                }

                wr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        //megszamoljuk, hogy mennyi volt a napi bevetel
        static void nyolcadik()
        {
            double ossz;
            int c = 0;

            foreach (var item in lista)
            {
                ossz = ((item.Vo - item.Eo) * 60) + (item.Vp - item.Ep);
                c += (int)Math.Ceiling(ossz / 30);
            }

            Console.WriteLine(c * 2400);
        }
        //bekerunk egy idot, perce alakitjuk, majd a perce alakitott kezdeshez es vegzeshez hasonlitjuk
        static void hetedik()
        {
            string ido = Console.ReadLine();
            var tmp = ido.Split(':');
            int E, V, K;

            foreach (var item in lista)
            {
                E = (item.Eo * 60) + item.Ep;
                V = (item.Vo * 60) + item.Vp;
                K = (int.Parse(tmp[0]) * 60) + int.Parse(tmp[1]);

                if (E <= K && V >= K)
                {         
                    Console.WriteLine($"{item.Eo}:{item.Ep}-{item.Vo}:{item.Vp} {item.Nev}");
                }
            }
        }

        //bekerunk egy nevet, es ha a lista tartalmazza, akkor kiirjuk az ertekeket
        static void hatodik()
        {
            string nev = Console.ReadLine();
            bool volte = false;

            foreach (var item in lista)
            {
                if (item.Nev == nev)
                {
                    volte = true;
                    Console.WriteLine($"{item.Eo}:{item.Ep}-{item.Vo}:{item.Vp}");
                }
            }

            if (!volte)
            {
                Console.WriteLine("Nem volt.");
            }
        }
        //kiirjuk az adatok darabszamat
        static void otodik() => Console.WriteLine(lista.Count);

        //beolvassuk a txt tartalmat, majd eltaroljuk azokat egy listaba
        static void beolv()
        {
            try
            {
                StreamReader sr = new StreamReader("kolcsonzesek.txt");

                //elso sor nem adat meg!
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    lista.Add(new Kolcsonzes(sr.ReadLine()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    class Kolcsonzes
    {
        public string Nev;
        public char Azon;
        public int Eo;
        public int Ep;
        public int Vo;
        public int Vp;

        public Kolcsonzes(string sor)
        {
            var tmp = sor.Split(';');

            Nev = tmp[0];
            Azon = Convert.ToChar(tmp[1]);
            Eo = Convert.ToInt32(tmp[2]);
            Ep = Convert.ToInt32(tmp[3]);
            Vo = Convert.ToInt32(tmp[4]);
            Vp = Convert.ToInt32(tmp[5]);
        }
    }
}
