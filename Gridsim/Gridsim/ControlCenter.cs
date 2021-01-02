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
        public void UpdateAll()
        {
            foreach (Centrale centralei in Centralesl)
            {
                centralei.getPower();
            }
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
                    Console.WriteLine(logcnt);
                    logcnt++;
                    noeudi.UpdateNoeud();
                }
            }
            Display();
        }
        public void Display()
        {
            // centrales
            Console.WriteLine("info centrales:");
            int logcnt = 1;
            foreach (Centrale centralei in Centralesl)
            {
                Console.WriteLine("ProdCentrale "+logcnt+": "+ centralei.Power);
                logcnt++;
            }
            Console.WriteLine("");

            // centrales
            Console.WriteLine("info consommateurs:");
            logcnt = 1;
            foreach (Consommateur consoi in Consommateursl)
            {
                Console.WriteLine("Consom " + logcnt + ": " + consoi.Consumption);
                logcnt++;
            }
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
