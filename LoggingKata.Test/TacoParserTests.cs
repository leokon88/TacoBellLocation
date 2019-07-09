using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }


        [Theory]
        [InlineData("34.07,-84.67,Taco Bell Acwort", 34.07, -84.67, "Taco Bell Acwort")]
        [InlineData("31,-84.17,Taco Bell Albany", 31.00, -84.17, "Taco Bell Albany")]
        [InlineData("31,0,Taco Bell Albany", 31.00, 0.00, "Taco Bell Albany")]


        public void ShouldParse(string line, object expectedResult)
        {

            //Arrange
            TacoParser tester = new TacoParser();

            //Act

            ITrackable taco = tester.Parse(line);

            //Assert
            Assert.Equal(expectedResult, taco);

        }
     

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" 31,Taco,Taco Bell Albany", "Invalid")]
        //[InlineData("34.07,aaa,Taco Bell Acwort")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            //Arrange
            TacoParser tester = new TacoParser();
            //Act

            ITrackable actual = tester.Parse(str);
            //Assert

            Assert.Null(null);

            Assert.Empty(str);



        }
    }
}
