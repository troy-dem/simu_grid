using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Gridsim
{
    class Meteo
    {
        private readonly Random _random = new Random();
        string[] meteolist = { "vent", "soleil", "pluie", "orage", "neige" };
        string maMeteo;
        public Meteo()
        {
            this.maMeteo = meteolist[RandomNumber(0, 5)];
        }
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public string getMeteo()
        {
            return maMeteo;
        }
    }
}