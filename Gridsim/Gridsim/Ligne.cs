using System;
using System.Collections.Generic;
using System.Text;

namespace Gridsim
{
    class Ligne
    {
        private float _Pnow;
        public float Pnow { get; }
        public readonly float Pmax;
        private Noeud Noeud_in;
        private Noeud Noeud_out;
        private readonly Centrale Centrale_in;
        private readonly bool CentraleLine;

        public Ligne(Noeud Noeud_in,Noeud Noeud_out,int Pmax)
        {
            this.Pmax = Pmax;
            this.Noeud_in = Noeud_in;
            this.Noeud_out = Noeud_out;
            this.Noeud_in.AddLineOut(this);
            this.Noeud_out.AddLineIn(this);
        }

        public Ligne(Centrale Centrale_in, Noeud Noeud_out, int Pmax)
        {
            this.CentraleLine = true;
            this.Pmax = Pmax;
            Pnow = Centrale_in.Power;
            this.Noeud_out = Noeud_out;
        }

        public bool SetPower(float Pchange)
        {
            if (Pnow + Pchange <= Pmax)
            {
                if (CentraleLine)
                {
                    Centrale_in.SetPower(Pchange);
                }
                else
                {
                    if (Noeud_in.UpdateNoeud())
                    {
                        this._Pnow += Pchange;
                        return true;
                    }
                } 
            }
            return false;
        }
    }
}
