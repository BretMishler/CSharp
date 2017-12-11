using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Test.Types
{
    [TestClass]
    public class ReferenceTypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);
            Assert.AreEqual(89.1f, grades[1]);

            AddGrades2(grades);
            Assert.AreNotEqual(89.2f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        private void AddGrades2(float[] grades)
        {
            grades = new float[5];
            grades[1] = 89.2f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "bret";

            name.ToUpper();
            Assert.AreEqual("bret", name);

            name = name.ToUpper();
            Assert.AreEqual("BRET", name);

        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);

            date.AddDays(1);
            Assert.AreEqual(1, date.Day);

            date = date.AddDays(1);
            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassByValue()
        {
            int x = 46;
            IncrementNumber(x);

            Assert.AreEqual(46, x);
        }

        private void IncrementNumber(int number)
        {
            number++;
        }

        [TestMethod]
        public void ReferenceTypesPassByRefKeyword()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);

            GiveBookANameRef(ref book2);
            // book 2 now points to a new, different GradeBook
            Assert.AreNotEqual("A New GradeBook", book1.Name);
            Assert.AreEqual("A New GradeBook", book2.Name);
        }

        private void GiveBookANameRef(ref GradeBook book)
        {
            // pointer from book2 now points to a new GradeBook
            book = new GradeBook();
            // this change will be reflected inside book2 now

            book.Name = "A New GradeBook";
        }
        
        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";

            // new gradebook made but pointer in book1 and book2 not changed
            book = new GradeBook();
        }

        //[TestMethod]
        //public void StringComparisons() 
        //{
        //    string name1 = "Bret";
        //    string name2 = "bret";

        //    // original code in course but invariantculture not in VS Mac
        //    //bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
        //    Assert.IsTrue(result); 
        //} 

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldARefence()
        {
            // reference type, val inside g1 is a pointer
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Bret's grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        } 
    }
} 