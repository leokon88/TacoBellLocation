using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {

        [Theory]
        [InlineData("34.07,-84.67,Taco Bell Acwort")]
        [InlineData("31,-84.17,Taco Bell Albany")]
        [InlineData("31,0,Taco Bell Albany")]
        public void ShouldParse(string line)
        {

            //Arrange
            TacoParser tester = new TacoParser();

            //Act

            ITrackable actual = tester.Parse(line);

            //Assert
            Assert.NotNull(actual);

        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" 31,Taco,Taco Bell Albany")]
      
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            //Arrange
            TacoParser tester = new TacoParser();

            //Act
            ITrackable actual = tester.Parse(str);

            //Assert

            Assert.Null(actual);
        }
    }
}
