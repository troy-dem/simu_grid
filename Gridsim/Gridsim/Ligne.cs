using System;
using System.Collections.Generic;
using System.Text;

namespace Gridsim
{
    class Ligne
    {
        public float Pnow { get; private set; }
        public readonly float Pmax;
        private Noeud Noeud_in;
        private Noeud Noeud_out;
        private Centrale Centrale_in;
        public readonly Consommateur consommateur;
        public readonly string type;

        public Ligne(Noeud Noeud_in,Noeud Noeud_out,int Pmax)
        {
            this.Pmax = Pmax;
            this.Pnow = 0;
            this.Noeud_in = Noeud_in;
            this.Noeud_out = Noeud_out;
            this.Noeud_in.AddLineOut(this);
            this.Noeud_out.AddLineIn(this);
        }

        //constructeur d'une LigneCentrale
        public Ligne(Centrale Centrale_in, Noeud Noeud_out, int Pmax)
        {
            this.type = "LigneCentrale";
            this.Pmax = Pmax;
            this.Centrale_in = Centrale_in;
            this.Pnow = Centrale_in.Power;
            this.Noeud_out = Noeud_out;
            this.Noeud_out.AddLineIn(this);
        }

        //constructeur d'une LigneConsommateur
        public Ligne(Noeud Noeud_in, Consommateur consommateur, int Pmax)
        {
            this.type = "LigneConsommateur";
            this.Pmax = Pmax;
            this.consommateur = consommateur;
            UpdatePnow(consommateur.Consumption);
            this.Noeud_in = Noeud_in;
            this.Noeud_in.AddLineOut(this);
        }

        public void UpdatePnow(float conso)
        {
            if (conso <= Pmax)
            {
                this.Pnow = conso;
            }
            else
            {
                this.Pnow = Pmax;
            }
        }
        
        public bool SetPower(float Pchange)
        {
            Console.WriteLine("Pnow " + Pnow);
            if (Pnow + Pchange <= Pmax & Pnow + Pchange >= 0)
            {
                this.Pnow += Pchange;
                Console.WriteLine("Type " + type);
                Console.WriteLine("Pend " + Pnow);
                switch (this.type) {
                    case "LigneCentrale":
                        //Console.WriteLine("Ligne Centrale");
                        if (Centrale_in.SetPower(Pchange))
                        {
                            return true;
                        }
                        break;
                    case "LigneConsommateur":
                        //Console.WriteLine("Ligne Conso");
                        this.Pnow = consommateur.Consumption;
                        if (Noeud_in.UpdateNoeud())
                        {
                            return true;
                        }
                        break;
                    default:
                        //Console.WriteLine("delault case");
                        if (Noeud_in.UpdateNoeud())
                        {
                            return true;
                        }
                        //this.Pnow += Pchange;
                        break;
                }
                this.Pnow -= Pchange;
            }
            return false;
        }
    }
}
