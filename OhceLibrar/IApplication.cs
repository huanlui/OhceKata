using System;
using System.Globalization;

namespace OhceKata
{

    public interface IApplication
    {
        void WriteToConsole(string text);
        void Exit();
    }
}