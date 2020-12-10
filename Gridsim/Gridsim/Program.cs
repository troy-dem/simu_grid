using System;

namespace Gridsim
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
        

    }        
}
