namespace OhceKata
{
    public class Greeter : IGreeter
    {
        private readonly IDayPartProvider _day_part_provider;

        public Greeter(IDayPartProvider day_part_provider)
        {
            _day_part_provider = day_part_provider;
        }

        public string SayHello(string name)
        {
            if (_day_part_provider.GetDayPart() == DayPart.Afternoon) return string.Format("Buenas tardes {0}", name);
            if(_day_part_provider.GetDayPart() == DayPart.Morning) return string.Format("Buenos días {0}", name);

            return string.Format("Buenas noches {0}", name);
        }

        public string SayBye(string name)
        {
            return string.Format("Adios {0}", name);
        }
    }
}