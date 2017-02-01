namespace OhceKata
{
    public class DayPartProvider :IDayPartProvider
    {
        private readonly ICurrentHourProvider _current_hour_provider;

        public DayPartProvider(ICurrentHourProvider current_hour_provider)
        {
            _current_hour_provider = current_hour_provider;
        }

        public DayPart GetDayPart()
        {
            if(IsMorningHour()) return DayPart.Morning;
            if (IsAfternoonHour()) return DayPart.Afternoon;
            return DayPart.Night;
        }

        private bool IsAfternoonHour()
        {
            var hour = _current_hour_provider.GetHour();
            return hour >= 12 && hour < 20;
        }

        private bool IsMorningHour()
        {
            var hour = _current_hour_provider.GetHour();
            return hour >= 6 && hour < 12;
        }
    }
}