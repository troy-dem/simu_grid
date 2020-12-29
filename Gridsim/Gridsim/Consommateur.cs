using System;
using System.Collections.Generic;
using System.Text;

namespace Gridsim
{
    class Consommateur
    {
        public float Consumption { get; private set; }
        public Consommateur(int consumption)
        {
            this.Consumption = consumption;
        }

        public double UpdateConso()
        {
            Random aleatoire = new Random();
            int change = aleatoire.Next(-40, 40);
            if (this.Consumption + change > 0)
            {
                this.Consumption += change;
            }
            return this.Consumption;
        }
    }
}
