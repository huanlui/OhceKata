using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace OhceKata
{
    [TestFixture]
    public class GreeterTest
    {
        private static IDayPartProvider CreateDayPartProviderReturning(DayPart part)
        {
            Mock<IDayPartProvider> mock = new Mock<IDayPartProvider>();
            mock.Setup(p => p.GetDayPart()).Returns(part);
            IDayPartProvider day_part_provider = mock.Object;
            return day_part_provider;
        }

        [Test]
        public void When_we_are_at_night_and_Paco_is_passed_it_greets_Buenas_noches_Paco()
        {
            var day_part_provider = CreateDayPartProviderReturning(DayPart.Night);
            Greeter tested = new Greeter(day_part_provider);

            String greet = tested.SayHello("Paco");

            Assert.AreEqual("Buenas noches Paco",greet);
        }


        [Test]
        public void When_we_are_at_night_and_Pepe_is_passed_it_greets_Buenas_noches_Pepe()
        {
            var day_part_provider = CreateDayPartProviderReturning(DayPart.Night);
            Greeter tested = new Greeter(day_part_provider);

            String greet = tested.SayHello("Pepe");

            Assert.AreEqual("Buenas noches Pepe", greet);
        }

        [Test]
        public void When_we_are_in_the_morning_and_Paco_is_passed_it_greets_Buenas_noches_Paco()
        {
            var day_part_provider = CreateDayPartProviderReturning(DayPart.Morning);
            Greeter tested = new Greeter(day_part_provider);

            String greet = tested.SayHello("Paco");

            Assert.AreEqual("Buenos días Paco", greet);
        }

        [Test]
        public void When_we_are_in_the_morning_and_Juan_is_passed_it_greets_Buenas_noches_Juan()
        {
            var day_part_provider = CreateDayPartProviderReturning(DayPart.Morning);
            Greeter tested = new Greeter(day_part_provider);

            String greet = tested.SayHello("Juan");

            Assert.AreEqual("Buenos días Juan", greet);
        }

        [Test]
        public void When_we_are_in_the_afternoon_and_Paco_is_passed_it_greets_Buenas_tardes_Paco()
        {
            var day_part_provider = CreateDayPartProviderReturning(DayPart.Afternoon);
            Greeter tested = new Greeter(day_part_provider);

            String greet = tested.SayHello("Paco");

            Assert.AreEqual("Buenas tardes Paco", greet);
        }

        [Test]
        public void When_we_are_in_the_afternoon_and_Juan_is_passed_it_greets_Buenas_noches_Juan()
        {
            var day_part_provider = CreateDayPartProviderReturning(DayPart.Afternoon);
            Greeter tested = new Greeter(day_part_provider);

            String greet = tested.SayHello("Juan");

            Assert.AreEqual("Buenas tardes Juan", greet);
        }

        [TestCase(DayPart.Afternoon)]
        [TestCase(DayPart.Morning)]
        [TestCase(DayPart.Night)]
        public void In_any_moment_it_says_bye_returning_Adios_plus_name(DayPart day_part)
        {
            var day_part_provider = CreateDayPartProviderReturning(day_part);
            Greeter tested = new Greeter(day_part_provider);

            String bye = tested.SayBye("Juan");

            Assert.AreEqual("Adios Juan", bye);        
        }
    }
}
