using System;
using NUnit.Framework;

namespace OhceKata
{
    [TestFixture]
    public class ReverserTest
    {
        [TestCase("casa","asac")]
        [TestCase("pop", "pop")]
        [TestCase("rape", "epar")]
        [TestCase("sas", "sas")]
        [TestCase("rata", "atar")]
        public void Reverses_the_word_passed_as_paramter(String input,String expected_output)
        {
            Reverser tested = new  Reverser();

            String output = tested.Reverse(input);

            Assert.AreEqual(expected_output,output);
        }

    }
}