using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    class Program
    {
        static void Main(string[] args)
        {
            LogWriter.logBool = false; //Log tutulsun mu?
            Ermeydani tahta = new Ermeydani(16);
            Takim red = new Takim("Red", new Bolge(0, 0), tahta);
            Console.WriteLine(red.Isim);
            for(int i=0;i<7;i++)
            {
                Console.WriteLine(red[i]);
            }
            Takim blue = new Takim("Blue", new Bolge(11, 11), tahta);
            Console.WriteLine(blue.Isim);
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(blue[i]);
            }
            Console.WriteLine("Savas baslıyor.....3....2....1");
            LogWriter.LogMessage($"Yeni Tur basliyor!!!");
            Savas(red, blue);  
            Console.WriteLine("Tekrar?[y|n]"); 
            if (Console.ReadKey().KeyChar == 'y' || Console.ReadKey().KeyChar == 'Y') Main(args);
        }

        public static void Savas(Takim r,Takim m)
        {
            Random rand = new Random();
            while (r.Canlisay()>0 && m.Canlisay()>0)
            {
                int ind_r = rand.Next(0, 7);
                int ind_m = rand.Next(0, 7);
               

                if (rand.NextDouble() < 0.5)
                {
                   if(r[ind_r] != null) r[ind_r].Sıra();
                   if(m[ind_m] != null) m[ind_m].Sıra();
                }
                else
                {
                    if (m[ind_m] != null) m[ind_m].Sıra();
                    if (r[ind_r] != null) r[ind_r].Sıra();
                }
                
            }
            if (r.Canlisay() > 0)
            {
                Console.WriteLine($"Kazanan takim:{r.Isim}");
                LogWriter.LogMessage($"Kazanan takim:{r.Isim}");
            }
            else
            {
                Console.WriteLine($"Kazanan takim:{m.Isim}");
                LogWriter.LogMessage($"Kazanan takim:{m.Isim}");
            }
            Console.WriteLine("Kalan asker sayileri");
            Console.WriteLine($"{r.Isim}: {r.Canlisay()} -- {m.Isim}: {m.Canlisay()}");
            LogWriter.LogMessage($"Kalan asker sayileri:{r.Isim}: {r.Canlisay()} -- {m.Isim}: {m.Canlisay()}");
        }
    }
}
