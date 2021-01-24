using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NYSEPro;

namespace UnitTestPro
{
   
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //test function for admin login
        public void Test_login_Admin()
        {
            User adminUser = new User();
            // Arrange
            string username = "admin";
            string password = "admin123";
            string expected = "Admin";

            // Act
            string actual = adminUser.login(username, password);

            // Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        //test function for client login
        public void Test_login_Client()
        {
            User adminUser = new User();
            // Arrange
            string username = "1";
            string password = "1";
            string expected = "Client";

            // Act
            string actual = adminUser.login(username, password);

            // Assert

            Assert.AreEqual(expected, actual);
        }
    }
}
