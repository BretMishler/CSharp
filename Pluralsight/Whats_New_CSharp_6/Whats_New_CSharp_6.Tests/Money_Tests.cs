using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Whats_New_CSharp_6.Tests
{
    [TestClass]
    public class Money_Tests
    {
        [TestMethod]
        public void Can_Parse_Money()
        {
            var input = "12.1 inr";
            var money = Money.Parse(input);

            Assert.AreEqual(12.1m, money.Amount);
            Assert.AreEqual("inr", money.Currency);
        }

        [TestMethod]
        public void Amount_Is_0_When_Amount_Misformatted()
        {
            var input = "12x.1 inr";
            var money = Money.Parse(input);

            Assert.AreEqual(0m, money.Amount);
            Assert.AreEqual("inr", money.Currency);
        }

        [TestMethod]
        public void Can_Add_Money()
        {
            var m1 = new Money(10m, "usd");
            var m2 = new Money(12.1m, "usd");
            var m3 = m1 + m2;

            Assert.AreEqual(22.1m, m3.Amount);
            Assert.AreEqual("usd", m3.Currency);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Throws_If_Adding_Different_Currencies()
        {
            var m1 = new Money(10m, "usd");
            var m2 = new Money(12.1m, "nok");
            var m3 = m1 + m2;
        }
    }
}
