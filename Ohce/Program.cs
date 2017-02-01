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
            Ohce ohce = CreateOhce(name);

            while (true)
            {
                ohce.WriteLine(Console.ReadLine());
            }
        }

        private static Ohce CreateOhce(String name)
        {
            Ohce ohce = new Ohce(name,CreateApplication(),CreateGreeter(),CreateReverser());

            return ohce;
        }

        private static IReverser CreateReverser()
        {
           return new Reverser();
        }

        private static IGreeter CreateGreeter()
        {
            return new Greeter(CreateDayPartProvider());
        }

        private static IDayPartProvider CreateDayPartProvider()
        {
            return new DayPartProvider(CreateCurrentHourProvider());
        }

        private static ICurrentHourProvider CreateCurrentHourProvider()
        {
            return new CurrentHourProvider();
        }

        private static IApplication CreateApplication()
        {
            return new OhceKataApplication();
        }
    }

    public class OhceKataApplication : IApplication
    {
        public void WriteToConsole(string text)
        {
            Console.WriteLine(text);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }

}
