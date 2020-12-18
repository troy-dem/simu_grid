using System;
using System.Collections.Generic;
using System.Text;

namespace Gridsim
{
    class Centrale
    {
        public float Power;
        public bool SetPower(float Pchange)
        {
            //implémenter vérification de la consigne de puissance et régulation de la centrale en fonction
            if (true)
            {
                Power = Power += Pchange;
            }
            return false;
        }
    }
}
