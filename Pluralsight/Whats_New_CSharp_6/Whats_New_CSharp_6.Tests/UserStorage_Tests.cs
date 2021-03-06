﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Whats_New_CSharp_6.Tests
{
    [TestClass]
    public class UserStorage_Tests
    {
        [TestMethod]
        public void Can_Have_Default_Users_Present()
        {
            var store = new UserStorage();
            Assert.AreEqual(2, store.Count());
        }

        [TestMethod]
        public void Can_Add_New_Users()
        {
            var store = new UserStorage
            {
                new User("sallen"),
                new User("venus"),
                new User("robot")
            };

            Assert.AreEqual(5, store.Count());
        }
    }
}
