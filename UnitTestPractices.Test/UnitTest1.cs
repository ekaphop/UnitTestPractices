using System;
using Xunit;

namespace UnitTestPractices.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestCase1()
        {
            // Arrange
            string expect = "YES";
            string actual;

            // Act
            actual = "YES";

            // Assert
            Assert.Equal(expect, actual);
        }
    }
}
