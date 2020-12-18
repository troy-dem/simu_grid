using System;
using System.Collections.Generic;

namespace Gridsim
{
    class Program
    {
        static void Main(string[] args)
        {
            //test de la classe consommateur
            /*
            Consommateur consom1 = new Consommateur(25);
            Consommateur consom2 = new Consommateur(286);
            while (true)
            {
                if (Console.ReadLine() == "c")
                {
                    Console.WriteLine("conso1 : " + consom1.UpdateConso());
                    Console.WriteLine("conso2 : " + consom2.UpdateConso());
                }
            }
            */


            //test de réseau

            //création de noeuds
            Noeud Noeud1 = new Noeud();
            Noeud Noeud2 = new Noeud();
            Noeud Noeud3 = new Noeud();
            List<Noeud> testNoeuds = new List<Noeud>();
            testNoeuds.Add(Noeud1);
            testNoeuds.Add(Noeud2);
            testNoeuds.Add(Noeud3);

            //creation de lignes
            Ligne Ligne1 = new Ligne(Noeud1, Noeud2, 60);
            Ligne Ligne2 = new Ligne(Noeud2, Noeud3, 150);
            Ligne Ligne3 = new Ligne(Noeud1, Noeud3, 10);

            //afichege des lignes
            foreach (Noeud noeudi in testNoeuds)
            {
                foreach (Ligne Ligne_in in noeudi.Lignes_in)
                {
                    Console.WriteLine("Noeud1 : " + Ligne_in.Pmax);
                }
            }
            Console.WriteLine("Noeud2 : " + Noeud2.Lignes_in[0].Pmax);

        }
        

    }        
}
