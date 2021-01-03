using System;
using System.Collections.Generic;

namespace Gridsim
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlCenter center1 = new ControlCenter();
            Meteo meteo1 = new Meteo();
            //création de centrales
            Centrale Centrale1 = new Centrale(0);
            Centrale Centrale2 = new Centrale(0,meteo1);
            Centrale Centrale3 = new Centrale(0);
            
            //ajout
            center1.AddCentrale(Centrale1);
            center1.AddCentrale(Centrale2);
            center1.AddCentrale(Centrale3);

            //création consommateurs
            Consommateur consom1 = new Consommateur(370);
            Consommateur consom2 = new Consommateur(236);
            Consommateur consom3 = new Consommateur(340);
            Consommateur consom4 = new Consommateur(165);
            Consommateur consom5 = new Consommateur(400);
            //ajout
            center1.AddConso(consom1);
            center1.AddConso(consom2);
            center1.AddConso(consom3);
            center1.AddConso(consom4);
            center1.AddConso(consom5);


            //création de noeuds
            Noeud Noeud1 = new Noeud();
            Noeud Noeud2 = new Noeud();
            Noeud Noeud3 = new Noeud();
            Noeud Noeud4 = new Noeud();
            Noeud Noeud5 = new Noeud();
            //ajout
            center1.AddNoeud(Noeud1);
            center1.AddNoeud(Noeud2);
            center1.AddNoeud(Noeud3);
            center1.AddNoeud(Noeud4);
            center1.AddNoeud(Noeud5);

            //creation de lignes
            //lignes centrales
            Ligne Ligne1 = new Ligne(Centrale1, Noeud1, 800);
            Ligne Ligne2 = new Ligne(Centrale2, Noeud5, 800);
            Ligne Ligne3 = new Ligne(Centrale3, Noeud5, 800);
            //lignes normales
            Ligne Ligne12 = new Ligne(Noeud1, Noeud2, 1000);
            Ligne Ligne23 = new Ligne(Noeud2, Noeud3, 1000);
            //Ligne Ligne42 = new Ligne(Noeud4, Noeud2, 1000);
            Ligne Ligne54 = new Ligne(Noeud5, Noeud4, 1000);
            //lignes consommateurs
            Ligne Ligne01 = new Ligne(Noeud1, consom1, 600);
            Ligne Ligne02 = new Ligne(Noeud3, consom2, 600);
            Ligne Ligne03 = new Ligne(Noeud3, consom3, 600);
            Ligne Ligne04 = new Ligne(Noeud3, consom4, 600);
            Ligne Ligne05 = new Ligne(Noeud4, consom5, 600);
            //ajout
            center1.AddLigne(Ligne1);
            center1.AddLigne(Ligne2);
            center1.AddLigne(Ligne3);
            center1.AddLigne(Ligne12);
            center1.AddLigne(Ligne23);
            //center1.AddLigne(Ligne42);
            center1.AddLigne(Ligne54);
            center1.AddLigne(Ligne01);
            center1.AddLigne(Ligne02);
            center1.AddLigne(Ligne03);
            center1.AddLigne(Ligne04);
            center1.AddLigne(Ligne05);

            while (true)
            {
                if (Console.ReadLine() == "y")
                {
                    center1.UpdateAll();
                }
                else
                {
                    System.Environment.Exit(1);
                }
            }
            
        }
    }        
}
