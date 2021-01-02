using System;
using System.Collections.Generic;
using System.Text;

namespace Gridsim
{
    class Centrale
    {
        public float Power { get; private set; }

        public Centrale(float initpower)
        {
            this.Power = initpower;
        }
        public bool SetPower(float Pchange)
        {
            //implémenter vérification de la consigne de puissance et régulation de la centrale en fonction
            Power += Pchange;
            if (Power < 0 || Power>800)
            {
                Power -= Pchange;
                return false;
            }
            return true;
        }
    }
}
