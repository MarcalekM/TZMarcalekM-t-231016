using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZMarcalekMáté231016
{
    class Terepjaro
    {
        public string Marka { get; set; }
        public int Evjarat { get; set; }
        public string Uzemanyag { get; set; }
        public int Tomeg { get; set; }
        public string Hajtas { get;  set; }
        public string Kepessegek { get; set; }

        public Terepjaro(string sor)
        {
            var v = sor.Split(';');
            Marka = v[0];
            Evjarat = int.Parse(v[1]);
            Uzemanyag = v[2];
            Tomeg = int.Parse(v[3]);
            Hajtas = v[4];
            Kepessegek = v[5];
        }

        public override string ToString()
        {
            return $"Márka és típus:  {Marka},\nÉvjárat:  {Evjarat},\nÜzemanyag:  {Uzemanyag},\nTömeg:  {Tomeg},\nHajtás:  {Hajtas},\nTerepjáró képességek:  {Kepessegek}\n";
        }
    }
}
