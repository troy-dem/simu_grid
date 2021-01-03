using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Gridsim
{
    class Centrale
    {
        public float Power { get; private set; }
        private readonly float Cost;
        public float curCost;
        private readonly float CO2;
        public float curCO2;
        public float Meteo { get; private set; }
        public readonly string type;
        string[] meteolist = { "vent", "soleil", "pluie", "orage", "neige" };
        private readonly Random _random = new Random();

        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        //constructeur centrale gaz
        public Centrale(float initpower)
        {
            this.Power = initpower;
            this.CO2 = Convert.ToSingle(2.5);
            this.Cost = Convert.ToSingle(1.5);
            this.curCost = 0;
            this.type = "Centrale à gaz";
        }
        //Constructeur centrale eolienne
        public Centrale(float initpower, Meteo meteo)
        {
            this.type = "Centrale éolienne";
            this.Cost = Convert.ToSingle(4.6);
            float mult = 1;
            switch (meteo.getMeteo())
            {
                case "vent":
                    mult= Convert.ToSingle(2.0);
                    break;
                case "pluie":
                    mult = Convert.ToSingle(1.8);
                    break;
                case "neige":
                    mult = Convert.ToSingle(1.4);
                    break;
                case "soleil":
                    mult = Convert.ToSingle(1.2);
                    break;
                case "orage":
                    mult = Convert.ToSingle(5.0);
                    break;
                default:
                    mult = Convert.ToSingle(1.0);
                    break;

            }
            Power *= mult;
        }
        public bool SetPower(float Pchange)
        {
            //implémenter vérification de la consigne de puissance et régulation de la centrale en fonction
            Power += Pchange;
            if (Power < 0 || Power > 800)
            {
                Power -= Pchange;
                return false;
            }
            curCost = Cost*Power;
            curCO2 = CO2*Power;
            return true;
        }
        public string info()
        {
            switch (this.type)
            {
                case "Centrale éolienne":
                    return string.Format("La {0} produit {1} avec une météo : {2} pour le cout de {3}", type, Power, Meteo, curCost);
                case "Centrale à gaz":
                    return string.Format("La {0} produit {1} avec une quantitée de CO2 de : {2} pour le cout de {3}", type, Power, curCO2, curCost);
                default:
                    return string.Format("La {0} produit {1} pour le cout de {2}", type, Power, curCost);
            }
        }
    }
}