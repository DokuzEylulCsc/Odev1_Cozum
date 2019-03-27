using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Odev_1
{
    abstract class Asker
    {
        private int can;

        private bool canlimi;

        protected Bolge koordinat;

        protected Takim takim;

        protected Ermeydani ermeydani;

        protected Random random;

        public Asker(Bolge bolge, Takim takim, Ermeydani ermeydani)
        {
            this.koordinat = bolge;
            this.takim = takim;
            this.ermeydani = ermeydani;
            can = 100;
            canlimi = true;
            random = new Random();
        }

        public Takim Takim { get { return takim; } }
        public Bolge Koordinat { get { return koordinat; } }

        protected void BolgeyiIsgalEt(int delta_x, int delta_y)
        {
            int x = this.koordinat.X;
            int y = this.koordinat.Y;
            if (this.koordinat.X + delta_x >= 0 && this.koordinat.X + delta_x < ermeydani.Boyut && this.koordinat.Y + delta_y < ermeydani.Boyut && this.koordinat.Y + delta_y >= 0)
            {

                if (!ermeydani[this.koordinat.X + delta_x, this.koordinat.Y + delta_y].Dolumu)
                {
                    koordinat.Bosalt(this);
                    ermeydani[this.koordinat.X + delta_x, this.koordinat.Y + delta_y].Doldur(this);
                    koordinat = ermeydani[this.koordinat.X + delta_x, this.koordinat.Y + delta_y];
                }

            }
            else
            {
                if (this is Er)
                {
                    if (this.koordinat.Y + delta_y >= ermeydani.Boyut || this.koordinat.Y + delta_y < 0)
                    {

                        double a = random.NextDouble();
                        int d_x = (a < 0.5) ? 1 : -1;
                        if (this.koordinat.X + d_x >= ermeydani.Boyut) d_x = 0;
                        else if (this.koordinat.X + d_x < 0) d_x = 0;

                        if (!ermeydani[this.koordinat.X + d_x, this.koordinat.Y].Dolumu)
                        {
                            koordinat.Bosalt(this);
                            ermeydani[this.koordinat.X + d_x, this.koordinat.Y].Doldur(this);
                            koordinat = ermeydani[this.koordinat.X + d_x, this.koordinat.Y];
                        }


                    }
                }

            }

            LogWriter.LogMessage($"{this.Takim.Isim}:{this.GetType().Name} {x}--{y} koordinatından {this.koordinat.X},{this.koordinat.Y}'a gitti.");
        }
        public int Can
        {
            get
            {
                return can;
            }
        }
        public bool Canli
        {
            get { return canlimi; }
        }

        public void Hasar(int a)
        {
            this.can -= a;
            if (can <= 0)
            {
                canlimi = false;
                koordinat.Bosalt(this);
                koordinat = null;
                Console.WriteLine($"{this.Takim.Isim}:{this.GetType().Name} öldü!!");
                LogWriter.LogMessage($"{this.Takim.Isim}:{this.GetType().Name} öldü!!");
            }
        }
        //Dökümanda var olan 3 abstract sınıfları
        public abstract void HaraketEt();

        public abstract void Bekle();

        public abstract void AtesEt();

        public void Sıra()
        {
            double a = random.NextDouble();
            if (a < 0.2)
            {
               
                Bekle();
            }
            else if (a < 0.4)
            {
                
                AtesEt();
            }
            else
            {
                HaraketEt();
            }
            

        }

        public override string ToString()
        {
            return $"Takim: {this.takim.Isim} Rütbe:{this.GetType().Name} Bolge:{this.koordinat.ToString()} Can: {this.can}";
        }


    }
}
