using System;
using Workshop;
using Xunit;

namespace WorkshopTests
{
    public class StringCalculatorTest
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int result = StringCalculator.SumString("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("12", 12)]
        [InlineData("1", 1)]
        [InlineData("225", 225)]
        public void SingleNumberReturnsValue(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12,12", 24)]
        [InlineData("1,13", 14)]
        [InlineData("0,225", 225)]
        public void NumbersSeparatedWithComaReturnsSum(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12\n12", 24)]
        [InlineData("1\n13", 14)]
        [InlineData("0\n225", 225)]
        public void NumbersSeparatedWithNewLineReturnsSum(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12\n12,1", 25)]
        [InlineData("2,1\n13", 16)]
        [InlineData("0\n225\n2", 227)]
        [InlineData("0,225,2", 227)]
        public void NumbersSeparatedWithNewLineOrComaReturnsSum(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("12\n12,-1")]
        [InlineData("-2,1\n13")]
        [InlineData("0\n-225\n2")]
        [InlineData("-234")]
        public void NegativeNumbersThrowsArgumentException(string str)
        {
            Assert.Throws<ArgumentException>(() => StringCalculator.SumString(str));
        }

        [Theory]
        [InlineData("12\n12,1001", 24)]
        [InlineData("3000,2,1,13", 16)]
        [InlineData("0\n225\n2\n3452", 227)]
        [InlineData("1000", 1000)]
        [InlineData("1001", 0)]
        public void IgnoreNumbersGreaterThen1000(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("//#\n12#12,1001", 24)]
        [InlineData("3000,2,1,13", 16)]
        [InlineData("//#\n0\n225#2\n3452", 227)]
        [InlineData("//#\n1000", 1000)]
        public void CustomSeparator(string str, int expectedValue)
        {
            int result = StringCalculator.SumString(str);
            Assert.Equal(expectedValue, result);
        }
    }
}
