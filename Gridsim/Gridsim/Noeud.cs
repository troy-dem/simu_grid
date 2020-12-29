using System;
using System.Collections.Generic;
using System.Text;

namespace Gridsim
{
    class Noeud
    {
        public List<Ligne> Lignes_in;
        public List<Ligne> Lignes_out;
        private float Pin;
        private float Pout;
        private float Pdif;
        private float Pgot;
        public Noeud()
        {
            this.Lignes_in = new List<Ligne>();
            this.Lignes_out = new List<Ligne>();
        }
        public bool UpdateNoeud()
        {
            Pout = 0;
            Pin = 0;
            //calcul de la consigne de puissance
            foreach (Ligne Ligne_out in Lignes_out)
            {
                Pout += Ligne_out.Pnow;
            }
            foreach (Ligne Ligne_in in Lignes_in)
            {
                Pin += Ligne_in.Pnow;
            }
            Pdif = Pout - Pin;
            //essai de régulation
            foreach (Ligne Ligne_in in Lignes_in)
            {
                if (Ligne_in.SetPower(Pdif))
                {
                    return true;
                }
                if (Ligne_in.SetPower(Ligne_in.Pmax - Ligne_in.Pnow))
                {
                    Pgot = Ligne_in.Pmax - Ligne_in.Pnow;
                    Pdif -= Pgot;
                    Pgot = 0;
                }
            }
            return false;
        }
        public void AddLineIn(Ligne ligne)
        {
            Lignes_in.Add(ligne);
        }
        public void AddLineOut(Ligne ligne)
        {
            Lignes_out.Add(ligne);
        }
    }
}
