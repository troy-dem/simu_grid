using System;
using System.Collections.Generic;
using System.Text;

namespace Gridsim
{
    class ControlCenter
    {
        List<Centrale> Centralesl;
        List<Consommateur> Consommateursl;
        List<Noeud> Noeudsl;
        List<Ligne> Lignesl;
        private Marche marche;
        public ControlCenter()
        {
            //création de centrales
            Centralesl = new List<Centrale>();

            //création consommateurs
            Consommateursl = new List<Consommateur>();

            //création de noeuds
            Noeudsl = new List<Noeud>();

            //création de lignes
            Lignesl = new List<Ligne>();
        }
        public void AddCentrale(Centrale c)
        {
            Centralesl.Add(c);
        }
        public void AddConso(Consommateur co)
        {
            Consommateursl.Add(co);
        }
        public void AddNoeud(Noeud n)
        {
            Noeudsl.Add(n);
        }
        public void AddLigne(Ligne l)
        {
            Lignesl.Add(l);
        }
        public void AddMarche(Marche marche)
        {
            this.marche = marche;
        }
        public void UpdateAll()
        {
                foreach (Consommateur consoi in Consommateursl)
            {
                consoi.UpdateConso();
                foreach(Ligne lignei in Lignesl)
                {
                    if ( lignei.type== "LigneConsommateur")
                    {
                        if (lignei.consommateur.Equals(consoi))
                        {
                            lignei.UpdatePnow(consoi.Consumption);
                        }
                        
                    }
                }
            }
            int upcnt;
            for (upcnt = 0; upcnt < 1; upcnt++)
            {
                int logcnt = 1;
                foreach (Noeud noeudi in Noeudsl)
                {
                    //Console.WriteLine(logcnt);
                    logcnt++;
                    noeudi.UpdateNoeud();
                }
            }
            Display();
        }
        public void Display()
        {
            

            // consommateur
            Console.WriteLine("info consommateurs:");
            int logcnt = 1;
            float consotot = 0;
            foreach (Consommateur consoi in Consommateursl)
            {
                Console.WriteLine("Consom " + logcnt + ": " + consoi.Consumption);
                consotot += consoi.Consumption;
                logcnt++;
            }
            Console.WriteLine("Conso totale: " + consotot);
            Console.WriteLine("");

            // centrales
            Console.WriteLine("info centrales:");
            float costprodtot = 0;
            foreach (Centrale centralei in Centralesl)
            {
                Console.WriteLine(centralei.info());
                costprodtot += (centralei.curCost+(centralei.curCO2*marche.CO2Cost));
            }
            float revenu = ((consotot * marche.elecSell) - costprodtot);
            Console.WriteLine("Revenu total: " + revenu);
            Console.WriteLine("");

            //info lignes générales
            Console.WriteLine("Lignes générales:");
            logcnt = 1;
            foreach (Ligne lignei in Lignesl)
            {
                Console.WriteLine("Ligne " + logcnt + ": " + lignei.Pnow);
                logcnt++;
            }
            Console.WriteLine("");

        }

    }
}
