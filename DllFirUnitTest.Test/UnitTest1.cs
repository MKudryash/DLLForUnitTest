using DLLForUnitTest;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace DllFirUnitTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod_LevenshteinDistance_Expected2Result2()
        {
            string[] s1 = { "зарево", "зорька", "зарница", "озарение", "заря", "озарить", "озаряться", "лучезарный" };
            string s2 = "зор";
            ClassForTest classForTest = new ClassForTest();
            int countWords = 0;
            foreach (var s in s1)
            {
                int diff = classForTest.LevenshteinDistance(s, s2);
                if (diff <= 3)
                {
                    countWords++;
                }
            }
            int expected = 2;
            Assert.AreEqual(expected, countWords);

        }

        [TestMethod]
        public void TestMethod_LevenshteinDistance_str_null_ExpectedThrowResultThrow()
        {
            string s1 = "Зарево";
            string s2 = null;
            ClassForTest classForTest = new ClassForTest();
            int expected = 2;
            Action act = () => classForTest.ArgumentNullException(s1, s2);
            Assert.ThrowsException<ArgumentNullException>(act);

        }
        [TestMethod]
        public void TestMethod_ArgumentNullException_null_str_ExpectedThrowResultThrow()
        {
            string s1 = null;
            string s2 = "зор";
            ClassForTest classForTest = new ClassForTest();
            int expected = 2;
            Action act = () => classForTest.ArgumentNullException(s1, s2);
            Assert.ThrowsException<ArgumentNullException>(act);
        }
        [TestMethod]
        public void TestMethod_ArgumentNullException_ExpectedNotNullResult2()
        {
            string s1 = "зарево";
            string s2 = "";
            ClassForTest classForTest = new ClassForTest();
            Assert.IsNotNull(classForTest.LevenshteinDistance(s1, s2));
        } 
        [TestMethod]
        public void TestMethod_ArgumentNullException_ExpectedIntResultInt()
        {
            string s1 = "зарево";
            string s2 = "";
            ClassForTest classForTest = new ClassForTest();

            Assert.IsInstanceOfType(classForTest.LevenshteinDistance(s1, s2), typeof(int));
        }
        [TestMethod]

        public void TestMethod_RegexEmail_ExpectedTrueResultTrue()
        {
            var emailRegex = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");
            var email = "1@mail.ru";
            Assert.IsTrue(emailRegex.IsMatch(email));
        }
        [TestMethod]
        public void TestMethod_RegexEmail_ExpectedFalseResultFalse()
        {
            var emailRegex = new Regex(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$");
            var email = "1@mailru";
            Assert.IsFalse(emailRegex.IsMatch(email));
        }

        [TestMethod]
        public void TestMethod_Contains_ExpectedTrueResultTrue()
        {
            var expectedSubString = "Зоря";
            var actualString = "Зо";
            Assert.IsTrue(expectedSubString.Contains(actualString));
        }
        [TestMethod]
        public void TestMethod_Contains_ExpectedFalseResultFalse()
        {
            var expectedSubString = "Зоря";
            var actualString = "Зя";
            Assert.IsFalse(expectedSubString.Contains(actualString));
        }
        [TestMethod]
        public void TestMethod_Same_ExpectedObj1ResultObj1()
        {
            var obj1 = new object();
            var obj2 = obj1;
            var obj3 = obj1;

            Assert.AreSame(obj2, obj3);
        }

    }
}