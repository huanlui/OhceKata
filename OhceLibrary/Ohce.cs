using System;

namespace OhceKata
{
    public class Ohce
    {
        private readonly IGreeter _greeter;
        private readonly IReverser _reverser;
        private IApplication _application;

        private string _name;

        public Ohce(string name, IApplication application, IGreeter greeter, IReverser reverser)
        {
            this._name = name;
            this._application = application;
            this._greeter = greeter;
            this._reverser = reverser;

            _application.WriteToConsole(_greeter.SayHello(_name));
        }

        public void WriteLine(string input)
        {
            if ("Stop!".Equals(input))
            {
                CloseApplication();
            }
            else
            {
                ReverseWord(input);
            }
        }

        private void CloseApplication()
        {
            _application.WriteToConsole(_greeter.SayBye(_name));
            _application.Exit();
        }

        private void ReverseWord(string input)
        {
            var reverse = _reverser.Reverse(input);

            _application.WriteToConsole(reverse);

            if (reverse.Equals(input))
            {
                _application.WriteToConsole("¡Bonita palabra!");
            }
        }
    }
}