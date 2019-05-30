using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciftlik
{
    class Hayvan
    {
        public int verimlilik;
        public int sayi=1;
        public bool yasam=true;
    }
    class Tavuk : Hayvan
    {
        public Tavuk()
        {
            verimlilik = 100;
        }
        public void update()
        {
            verimlilik -= 2;
            if (verimlilik<=0)
            {
                verimlilik = 0;
                yasam = false;
            }            
        }
    }
    class Ordek : Hayvan
    {
        public Ordek()
        {
            verimlilik = 100;
        }
        public void update()
        {
            verimlilik -= 3;
            if (verimlilik <= 0)
            {
                verimlilik = 0;
                yasam = false;
            }
        }
    }
    class Inek : Hayvan
    {
        public Inek()
        {
            verimlilik = 100;
        }
        public void update()
        {
            verimlilik -= 8;
            if (verimlilik <= 0)
            {
                verimlilik = 0;
                yasam = false;
            }
        }
    }
    class Keci : Hayvan
    {
        public Keci()
        {
            verimlilik = 100;
        }
        public void update()
        {
            verimlilik -= 6;
            if (verimlilik <= 0)
            {
                verimlilik = 0;
                yasam = false;
            }
        }
    }

}
