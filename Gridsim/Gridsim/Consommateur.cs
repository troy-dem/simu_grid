using System;
using System.Collections.Generic;
using System.Text;

namespace Gridsim
{
    class Consommateur
    {
        private int consumption;
        public Consommateur(int consumption)
        {
            this.consumption = consumption;
        }

        public double UpdateConso()
        {
            Random aleatoire = new Random();
            int change = aleatoire.Next(-40, 40);
            if (this.consumption + change > 0)
            {
                this.consumption += change;
            }
            return this.consumption;
        }
    }
}
