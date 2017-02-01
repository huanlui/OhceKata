using System;

namespace OhceKata
{
    public class CurrentHourProvider : ICurrentHourProvider
    {
        public int GetHour()
        {
            return DateTime.Now.Hour;
        }
    }
}