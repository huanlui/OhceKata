using Moq;
using NUnit.Framework;

namespace OhceKata
{
    [TestFixture]
    public class DayPartProviderTest
    {
        private static ICurrentHourProvider CreateCurrentHourProviderReturning(int hour)
        {
            var mock = new Mock<ICurrentHourProvider>();
            mock.Setup(p => p.GetHour()).Returns(hour);
            ICurrentHourProvider result = mock.Object;
            return result;
        }

        [Test]
        public void At_20_returns_night()
        {
            ICurrentHourProvider current_hour_provider = CreateCurrentHourProviderReturning(20);
            DayPartProvider tested = new DayPartProvider(current_hour_provider);

            DayPart result = tested.GetDayPart();

            Assert.AreEqual(DayPart.Night,result);
        }

        [Test]
        public void At_6_returns_morning()
        {
            ICurrentHourProvider current_hour_provider = CreateCurrentHourProviderReturning(6);
            DayPartProvider tested = new DayPartProvider(current_hour_provider);

            DayPart result = tested.GetDayPart();

            Assert.AreEqual(DayPart.Morning, result);
        }

        [Test]
        public void At_12_returns_afternoon()
        {
            ICurrentHourProvider current_hour_provider = CreateCurrentHourProviderReturning(12);
            DayPartProvider tested = new DayPartProvider(current_hour_provider);

            DayPart result = tested.GetDayPart();

            Assert.AreEqual(DayPart.Afternoon, result);
        }
    }
}