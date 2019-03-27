using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Ermeydani
    {
        /* 
         * Sol üst köşe 0 X 0 Sağ alk köşe boyut-1 X boyut-1 
         */
        Bolge[,] harita;

        int boyut;
        Random rand;
        public Ermeydani(int boyut)
        {
            rand = new Random();
            harita = new Bolge[boyut, boyut];
            this.boyut = boyut;
            for (int i = 0; i < boyut; i++)
                for (int j = 0; j < boyut; j++)
                {
                    harita[i, j] = new Bolge(i, j);
                }

        }

        public Bolge this[int x, int y]
        {
            get
            {
                if (x >= 0 & y>=0 & x < boyut && y < boyut)
                    return harita[x, y];
                else
                    return null;

            }
        }

        public int Boyut { get { return boyut; } }

        public Bolge BaslangıcNoktasıVer(Bolge solUst, int a_boyut)
        {
            if (a_boyut > 2 && solUst.X + a_boyut <= boyut && solUst.Y + a_boyut <= boyut)
            {
                int x_p = rand.Next(solUst.X, solUst.X + a_boyut);
                int y_p = rand.Next(solUst.Y, solUst.Y + a_boyut);
                if (!harita[x_p, y_p].Dolumu)
                {
                    return harita[x_p, y_p];
                }
                else
                {
                    return BaslangıcNoktasıVer(solUst, a_boyut);
                }
            }
            else return null;
        }

        public ArrayList KomsuBolgeleriVer(int komsuluk, Bolge bolge)
        {
            ArrayList komsular = new ArrayList();
            for (int i = bolge.X + 1; i < bolge.X + komsuluk + 1; i++)
                for (int j = bolge.Y + 1; j < bolge.Y + komsuluk + 1; j++)
                {
                    if (j < boyut && i < boyut && harita[i, j] != null) komsular.Add(harita[i, j]);
                }

            return komsular;
        }
        
         
    }
}
