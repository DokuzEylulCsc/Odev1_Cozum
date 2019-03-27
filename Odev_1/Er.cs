using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Er : Asker 
    {
      
       public Er(Bolge bolge, Takim takim,Ermeydani ermeydani):base(bolge,takim,ermeydani)
        {
            random = new Random();
        }

        public override void Bekle()
        {
            LogWriter.LogMessage($"{this} => bekliyor!");

        }

        public override void AtesEt()
        {
            ArrayList komsular = ermeydani.KomsuBolgeleriVer(1, koordinat);
            ArrayList Dusman = new ArrayList();
            foreach(object b in komsular)
            {
                if(b is Bolge)
                {
                    if(((Bolge)b).Dolumu)
                        if (Bolge.DusmanMi(this.koordinat, (Bolge)b))
                            Dusman.Add(((Bolge)b)._Asker);
                }
            }
            if (Dusman.Count > 0)
            {
                int sec = random.Next(0, Dusman.Count);
                Asker temp = (Asker)Dusman[sec];
                double prob = random.NextDouble();
                int hasar = (prob < 0.3) ? 5 : ((prob < 0.6) ? 10 : 15);
                Console.WriteLine($"{this.Takim.Isim}:{this.GetType().Name}, {temp.Takim.Isim}:{temp.GetType().Name}'e  ateş etti ve {hasar} hasar verdi. ");
                LogWriter.LogMessage($"{this.Takim.Isim}:{this.GetType().Name}, {temp.Takim.Isim}:{temp.GetType().Name}'e  ateş etti ve {hasar} hasar verdi. ");
                temp.Hasar(hasar);
               
            }


        }

        public override void HaraketEt()
        {
            double a = random.NextDouble();
            int delta_y = (a < 0.6) ? 1 : -1;
            BolgeyiIsgalEt(0, delta_y);
        }
    }
}
