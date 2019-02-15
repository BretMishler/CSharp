using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Whats_New_CSharp_6.Tests
{
    [TestClass]
    public class User_Tests
    {
        [TestMethod]
        public void User_Creates_An_Id()
        {
            var u1 = new User();

            Assert.AreNotEqual(Guid.Empty, u1.Id);
        }
    }
}
