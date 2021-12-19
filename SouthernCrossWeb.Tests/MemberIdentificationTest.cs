using SouthernCross.Web.Dto;
using Xunit;

namespace SouthernCrossWeb.Tests
{
    public class MemberIdentificationTest
    {
        private const int DigitLength = 10;

        [Fact]
        public void MemberCardNumberIdentification_Should_Be_Digits()
        {
            var memberIdentification = new MemberIdentification { CardNumber = 1025458014 };
            Assert.True(memberIdentification.CardNumber.ToString().Length == DigitLength);
        }

        [Fact]
        public void PolicyNumberIdentification_Should_Be_Digits()
        {
            var memberIdentification = new MemberIdentification { PolicyNumber = 800148901 };
            Assert.True(memberIdentification.PolicyNumber.ToString().Length == DigitLength);
        }
    }
}
