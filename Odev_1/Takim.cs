using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Takim
    {
        Asker[] birlik = new Asker[7];
        String isim;
        Bolge baslangicBolge;
        Random random;
        Ermeydani tahta;
      

        public Takim(String isim,Bolge bas_bolge,Ermeydani tahta)
        {
            this.tahta = tahta;
            this.isim = isim;
            this.baslangicBolge = bas_bolge;
            
            random = new Random();
            TakimiYarat();
        }

        private void TakimiYarat()
        {
            int k = 0;
            int[] askerRütbeleri = new int[3];
            askerRütbeleri[0] = random.Next(0, 2);
            askerRütbeleri[1] = random.Next(1, 3);
            askerRütbeleri[2] = 7 - askerRütbeleri[1] - askerRütbeleri[0];
            for (int i = 0; i < askerRütbeleri.Length; i++)
                for (int j = 0; j < askerRütbeleri[i]; j++)
                {
                    Bolge a = tahta.BaslangıcNoktasıVer(baslangicBolge, 5);
                    switch (i)
                    {
                        case 0:
                            birlik[k] = new Yuzbasi(a,this,tahta);
                            break;
                        case 1:
                            birlik[k] = new Tegmen(a,this,tahta);
                            break;
                        case 2:
                            birlik[k] = new Er(a, this,tahta);
                            break;
                    }
                    a.Doldur(birlik[k]);
                    k++; 
                }
            
        }

        public int Canlisay()
        {
            
                int canliSay = 0;
                for(int i=0;i<7;i++)
                {
                    if (birlik[i].Canli) canliSay++;
                }
                return canliSay;
            
        }
        public String Isim
        {
            get
            {
                return isim;
            }
        }
        public Asker this[int index]
        {
           
            get
            {
                int i = index;
                if (i >= 0 && i < 7 && Canlisay() > 0)
                {
                    if(birlik[i].Canli)
                        return birlik[i];
                    else
                    {
                        do
                        {
                            i++;
                            i = (i) % 7;
                        }
                        while (!birlik[i].Canli);
                        return birlik[i];
                    }
                }
                else return null;
            }
        }

        
    }
}
