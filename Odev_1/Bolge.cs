using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Bolge
    {
        int x;
        int y;
        bool dolu;
        Asker asker;
        public Bolge(int x,int y)
        {
            this.x = x;
            this.y = y;
            this.dolu = false;
        }

        public Asker _Asker
        {
            get
            {
                return asker;
            }
        }
        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }

        public bool Dolumu
        {
            get { return dolu; }
        }

        public void Doldur(Asker asker)
        {
            this.asker = asker;

            this.dolu = true;
        }

        public void Bosalt(Asker asker)
        {
            if(this.asker.Equals(asker))
            {
                this.asker = null;
                this.dolu = false;
            }
        }

        public static bool DusmanMi(Bolge a, Bolge b)
        {
            if (a.asker.Takim.Equals(b.asker.Takim)) return false;
            else return true;
        }

        public override string ToString()
        {
            return $"{X} - {Y}";
        }
    }
}
