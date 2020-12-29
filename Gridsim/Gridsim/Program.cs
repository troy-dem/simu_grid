using System;
using System.Collections.Generic;

namespace Gridsim
{
    class Program
    {
        static void Main(string[] args)
        {
            //création de centrales
            Centrale Centrale1 = new Centrale(180);
            Centrale Centrale2 = new Centrale(0);
            Centrale Centrale3 = new Centrale(0);

            //création consommateurs
            Consommateur consom1 = new Consommateur(300);
            Consommateur consom2 = new Consommateur(0);
            Consommateur consom3 = new Consommateur(400);
            Consommateur consom4 = new Consommateur(370);
            Consommateur consom5 = new Consommateur(55);
            Consommateur consom6 = new Consommateur(150);
            

            //création de noeuds
            Noeud Noeud1 = new Noeud();
            Noeud Noeud2 = new Noeud();
            Noeud Noeud3 = new Noeud();
            Noeud Noeud4 = new Noeud();
            Noeud Noeud5 = new Noeud();
            List<Noeud> testNoeuds = new List<Noeud>();
            testNoeuds.Add(Noeud1);
            testNoeuds.Add(Noeud2);
            testNoeuds.Add(Noeud3);
            testNoeuds.Add(Noeud4);
            testNoeuds.Add(Noeud5);

            //creation de lignes
            //lignes centrales
            Ligne Ligne1 = new Ligne(Centrale1, Noeud1, 800);
            Ligne Ligne2 = new Ligne(Centrale2, Noeud5, 800);
            Ligne Ligne3 = new Ligne(Centrale3, Noeud5, 800);
            //lignes normales
            Ligne Ligne12 = new Ligne(Noeud1, Noeud2, 1000);
            Ligne Ligne23 = new Ligne(Noeud2, Noeud3, 1000);
            Ligne Ligne42 = new Ligne(Noeud4, Noeud2, 1000);
            Ligne Ligne54 = new Ligne(Noeud5, Noeud4, 1000);
            //Ligne Ligne14 = new Ligne(Noeud1, Noeud4, 1000);
            //lignes consommateurs
            Ligne Ligne01 = new Ligne(Noeud1, consom1, 600);
            Ligne Ligne02 = new Ligne(Noeud3, consom2, 600);
            Ligne Ligne03 = new Ligne(Noeud3, consom3, 600);
            Ligne Ligne04 = new Ligne(Noeud3, consom4, 600);
            Ligne Ligne05 = new Ligne(Noeud4, consom5, 600);
            Ligne Ligne06 = new Ligne(Noeud2, consom6, 600);

            List<Ligne> testLignes = new List<Ligne>();
            testLignes.Add(Ligne1);
            testLignes.Add(Ligne2);
            testLignes.Add(Ligne3);
            testLignes.Add(Ligne12);
            testLignes.Add(Ligne23);
            testLignes.Add(Ligne42);
            testLignes.Add(Ligne54);
            //testLignes.Add(Ligne14);
            testLignes.Add(Ligne01);
            testLignes.Add(Ligne02);
            testLignes.Add(Ligne03);
            testLignes.Add(Ligne04);
            testLignes.Add(Ligne05);
            testLignes.Add(Ligne06);


            //test de réseau

            //update du réseau
            int upcnt = 0;
            for (upcnt=0; upcnt< 50;upcnt++)
            {
                foreach (Noeud noeudi in testNoeuds)
                {
                    noeudi.UpdateNoeud();
                }
            }
                

            //affichage état final
            // centrales
            Console.WriteLine("info centrales:");
            Console.WriteLine("ProdCentrale 1: " + Centrale1.Power);
            Console.WriteLine("LigneCentrale 1: " + Ligne1.Pnow);
            Console.WriteLine("ProdCentrale 2: " + Centrale2.Power);
            Console.WriteLine("LigneCentrale 2: " + Ligne2.Pnow);
            Console.WriteLine("ProdCentrale 3: " + Centrale3.Power);
            Console.WriteLine("LigneCentrale 3: " + Ligne3.Pnow);
            Console.WriteLine("");
            //consommateurs
            Console.WriteLine("info consommateurs:");
            Console.WriteLine("Consom 1: " + consom1.Consumption);
            Console.WriteLine("LigneConso 1: " + Ligne01.Pnow);
            Console.WriteLine("Consom 2: " + consom2.Consumption);
            Console.WriteLine("LigneConso 2: " + Ligne02.Pnow);
            Console.WriteLine("Consom 3: " + consom3.Consumption);
            Console.WriteLine("LigneConso 3: " + Ligne03.Pnow);
            Console.WriteLine("Consom 4: " + consom4.Consumption);
            Console.WriteLine("LigneConso 4: " + Ligne04.Pnow);
            Console.WriteLine("Consom 5: " + consom5.Consumption);
            Console.WriteLine("LigneConso 5: " + Ligne05.Pnow);
            Console.WriteLine("Consom 6: " + consom6.Consumption);
            Console.WriteLine("LigneConso 6: " + Ligne06.Pnow);
            Console.WriteLine("");
            //info lignes générales
            Console.WriteLine("Lignes générales:");
            Console.WriteLine("LigneInter 12: " + Ligne12.Pnow);
            Console.WriteLine("LigneInter 23: " + Ligne23.Pnow);
            Console.WriteLine("LigneInter 42: " + Ligne42.Pnow);
            Console.WriteLine("LigneInter 54: " + Ligne54.Pnow);
            //Console.WriteLine("LigneInter 14: " + Ligne14.Pnow);

                
        }
    }        
}
