using System;
using OhceKata;

namespace OhceKataApp
{
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