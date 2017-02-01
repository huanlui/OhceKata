using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OhceKata;

namespace OhceKataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = String.Concat(args.Select(a=> a+" "));
            Ohce ohce = Container.CreateOhce(name);

            while (true)
            {
                ohce.WriteLine(Console.ReadLine());
            }
        }
    }
}
