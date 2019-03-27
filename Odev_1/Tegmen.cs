using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Tegmen : Asker
    {
        public Tegmen(Bolge bolge, Takim takim, Ermeydani ermeydani) : base(bolge, takim, ermeydani)
        {

        }

        public override void Bekle()
        {
            LogWriter.LogMessage($"{this} => bekliyor!");
        }

        public override void AtesEt()
        {
            ArrayList komsular = ermeydani.KomsuBolgeleriVer(2, koordinat);
            ArrayList Dusman = new ArrayList();
            foreach (object b in komsular)
            {
                if (b is Bolge)
                {
                    if (((Bolge)b).Dolumu)
                        if (Bolge.DusmanMi(this.koordinat, (Bolge)b))
                            Dusman.Add(((Bolge)b)._Asker);
                }
            }
            if (Dusman.Count > 0)
            {
                int sec = random.Next(0, Dusman.Count);
                Asker temp = (Asker)Dusman[sec];
                double prob = random.NextDouble();
                int hasar = (prob < 0.3) ? 10 : ((prob < 0.6) ? 20 : 25);
                Console.WriteLine($"{this.Takim.Isim}:{this.GetType().Name}, {temp.Takim.Isim}:{temp.GetType().Name}'e  ateş etti ve {hasar} hasar verdi.  ");
                LogWriter.LogMessage($"{this.Takim.Isim}:{this.GetType().Name}, {temp.Takim.Isim}:{temp.GetType().Name}'e  ateş etti ve {hasar} hasar verdi. ");
                temp.Hasar(hasar);
                
            }


        }

        public override void HaraketEt()
        {
            double yon = random.NextDouble();
            if(yon < 0.5)
            {
                double a = random.NextDouble();
                int delta_y = (a < 0.5) ? 1 : -1;
                BolgeyiIsgalEt(0, delta_y);
            }
            else
            {
                double a = random.NextDouble();
                int delta_x = (a < 0.5) ? 1 : -1;
                BolgeyiIsgalEt(delta_x, 0);
            }
        }
    }
}
