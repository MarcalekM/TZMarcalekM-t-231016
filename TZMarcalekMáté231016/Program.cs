using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TZMarcalekMáté231016
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Terepjaro> terepjarok = new();
            using StreamReader sr = new(
                path: @"..\..\..\src\terepjarok.txt",
                encoding: Encoding.UTF8);
            while (!sr.EndOfStream) terepjarok.Add(new(sr.ReadLine()));
            Console.WriteLine("7. feladat:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(terepjarok[i].ToString());
            }

            Console.WriteLine("9. feladat:");
            var f9 = terepjarok.Where(t => t.Marka.Contains("Toyota"));
            double atlagTomeg = 0;
            foreach (var f in f9)
            {
                atlagTomeg += f.Tomeg;
            }
            atlagTomeg /= f9.Count();
            Console.WriteLine($"\tA Toyota márkájú autók átlag tömege:  {atlagTomeg}");

            Console.WriteLine("\n 10. feladat:");
            var f10 = terepjarok.Where(t => t.Hajtas == "Összkerékhajtás" && t.Evjarat > 2019);
            Console.WriteLine($"Összesen {f10.Count()} db összkerekes 2019 utáni autó található a listában");

            Console.WriteLine("\n11. feladat:");
            Console.WriteLine($"A legkönnyebb autó:\n{Legkonnyebb(terepjarok).ToString()}");

            Console.WriteLine("\n12. feladat:");
            var dizel = terepjarok.Where(t => t.Uzemanyag == "Dízel");
            var ev = dizel.Max(d => d.Evjarat);
            var f12 = terepjarok.Where(t => t.Evjarat > ev);
            if (f12.Count() > 0) Console.WriteLine(f12.First().ToString());
            else Console.WriteLine("Nem található ilyen autó");

            Console.WriteLine("\n13. feladat:");
            var f13 = terepjarok.Where(t => t.Hajtas == "Összkerékhajtás");
            foreach (var f in f13)
            {
                Console.WriteLine(f.ToString());
            }

            using StreamWriter sw = new(
                path: @"..\..\..\src\terepjarok2.txt",
                append: false,
                encoding: Encoding.UTF8);
            foreach (var t in terepjarok)
            {
                sw.WriteLine($"{t.Marka},{t.Evjarat};{t.Uzemanyag};{Font(t)};{t.Hajtas};{t.Kepessegek}") ;
            }

            Console.WriteLine("\n16. szorgalmi feladat");
            MinMax(terepjarok);
        }


        static Terepjaro Legkonnyebb(List<Terepjaro> lista)
        {
            int tomeg = lista[0].Tomeg;
            int index = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (tomeg > lista[i].Tomeg)
                {
                    index = i;
                }
            }

            return lista[index];
        }

        static double Font(Terepjaro t)
        {
            return t.Tomeg * 2.20462;
        }

        //Szorgalmi 16
        static void MinMax(List<Terepjaro> lista)
        {
            int min = lista[0].Tomeg;
            int max = lista[0].Tomeg;
            int indexMin = 0;
            int indexMax = 0;
            for (int  i = 1;  i < lista.Count;  i++)
            {
                if (lista[i].Tomeg > max)
               {
                    max = lista[i].Tomeg;
                    indexMax = i;
               }
                else if (lista[i].Tomeg < min)
                {
                    min = lista[i].Tomeg;
                    indexMin = i;
                }
            }
            Console.WriteLine($"A legnehezebb terepjáró a {indexMax + 1} szorszámú\nA legkönnyebb pedig a {indexMin + 1} sorszámú");

            Console.ReadLine();
        }
    }
}
