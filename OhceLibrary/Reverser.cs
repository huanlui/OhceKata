using System;
using System.Linq;

namespace OhceKata
{
    public class Reverser:IReverser
    {
        public string Reverse(string input)
        {
            return String.Concat(input.Reverse());
        }
    }
}