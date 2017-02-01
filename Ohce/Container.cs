using System;
using OhceKata;

namespace OhceKataApp
{
    public static class Container
    {
        public static Ohce CreateOhce(String name)
        {
            Ohce ohce = new Ohce(name,CreateApplication(),CreateGreeter(),CreateReverser());

            return ohce;
        }

        public static IReverser CreateReverser()
        {
            return new Reverser();
        }

        public static IGreeter CreateGreeter()
        {
            return new Greeter(CreateDayPartProvider());
        }

        public static IDayPartProvider CreateDayPartProvider()
        {
            return new DayPartProvider(CreateCurrentHourProvider());
        }

        public static ICurrentHourProvider CreateCurrentHourProvider()
        {
            return new CurrentHourProvider();
        }

        public static IApplication CreateApplication()
        {
            return new OhceKataApplication();
        }
    }
}