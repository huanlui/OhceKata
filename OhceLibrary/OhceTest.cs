using System;
using System.Xml;
using Moq;
using NUnit.Framework;

namespace OhceKata
{
    [TestFixture]
    public class OhceTest
    {
        private static IReverser CreateReverser(string input, string output)
        {
            var mock = new Mock<IReverser>();
            mock.Setup(g => g.Reverse(input)).Returns(output);
            IReverser reverser = mock.Object;
            
            return reverser;
        }

        private static IGreeter CreateGreeter(string input, string hello_output, string bye_output)
        {
            var mock_greeter = new Mock<IGreeter>();
            mock_greeter.Setup(g => g.SayHello(input)).Returns(hello_output);
            mock_greeter.Setup(g => g.SayBye(input)).Returns(bye_output);
            IGreeter greeter = mock_greeter.Object;
            return greeter;
        }

        [Test]
        public void When_created_writes_to_console_the_result_of_greeter_say_hello()
        {
            var application = new Mock<IApplication>();
            var greeter = CreateGreeter("Pedro", "Hello Pedro", "Bye Pedro");
            var reverser = CreateReverser("loc", "col");

            new Ohce("Pedro",application.Object,greeter, reverser);

            application.Verify(a => a.WriteToConsole("Hello Pedro"),Times.Once);
        }

        [Test]
        public void When_write_line_is_called_writes_to_console_the_result_of_reverser()
        {
            var application = new Mock<IApplication>();
            var greeter = CreateGreeter("Pedro", "Hello Pedro", "Bye Pedro");
            var reverser = CreateReverser("loc", "col");
            Ohce tested = new Ohce("Pedro", application.Object, greeter, reverser);

            tested.WriteLine("loc");

            application.Verify(a => a.WriteToConsole("col"), Times.Once);
        }

        [Test]
        public void When_input_of_write_line_is_a_palindrome_then_it_writes_to_console_the_result_of_reverser_and_adds_bonita_palabra()
        {
            string palindrome = "Adivina ya te opina ya ni miles origina ya ni cetro me domina ya ni monarcas a repaso ni mulato carreta acaso nicotina ya ni cita vecino anima cocin, pedazo gallina cedazo terso nos retoza de canilla goza de pánico camina ónice vaticina ya ni tocino saca a terracota luminosa pera sacra nómina y ánimo de mortecina ya ni giros elimina ya ni poeta ya ni vida";
            var application = new Mock<IApplication>();
            var greeter = CreateGreeter("Pedro", "Hello Pedro", "Bye Pedro");
            var reverser = CreateReverser(palindrome, palindrome);
            Ohce tested = new Ohce("Pedro", application.Object, greeter, reverser);
            
            tested.WriteLine(palindrome);

            application.Verify(a => a.WriteToConsole(palindrome), Times.Once);
            application.Verify(a => a.WriteToConsole("¡Bonita palabra!"), Times.Once);
        }

        [Test]
        public void When_input_of_write_line_is_not_a_palindrome_then_it_writes_to_console_the_result_of_reverser_but_is_does_not_add_bonita_palabra()
        {
            var application = new Mock<IApplication>();
            var greeter = CreateGreeter("Pedro", "Hello Pedro", "Bye Pedro");
            var reverser = CreateReverser("No soy palindromo", "No soy palindromo al revés");
            Ohce tested = new Ohce("Pedro", application.Object, greeter, reverser);

            tested.WriteLine("No soy palindromo");

            application.Verify(a => a.WriteToConsole("No soy palindromo al revés"), Times.Once);
            application.Verify(a => a.WriteToConsole("¡Bonita palabra!"), Times.Never);
        }

        [Test]
        public void When_input_of_write_line_is_Stop_then_it_writes_to_console_the_result_of_greeter_say_bye_and_exits_application_in_this_order()
        {
            var application = new Mock<IApplication>();
            var greeter = CreateGreeter("Pedro", "Hello Pedro", "Bye Pedro");
            var reverser = CreateReverser("loc", "col");
            Ohce tested = new Ohce("Pedro", application.Object, greeter, reverser);

            tested.WriteLine("Stop!");

            application.Verify(a => a.WriteToConsole("Bye Pedro"), Times.Once);
            application.Verify(a => a.Exit(), Times.Once);
        }
    }
}