using BankingSystem.Domain.DomainRules;
using BankingSystem.Domain.Models;

namespace BankingSystem.UnitTesting
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("rushab@gmail.com")]
        [InlineData("rushab@rushabrisal.com.np")]
        [InlineData("rushabofficials@gmail.com")]
        public void IsEmailValid_ValidEmail_True(string email)
        {
            //Arrange
            IEmailValidator _validator = new EmailValidator();

            //Act
            var result = _validator.IsEmailValid(email);

            //Assertion
            Assert.True(result?.Result);
        }

        //[Theory]
        //[InlineData("rushab@gmail.com")]
        //[InlineData("rusha@bgmail.com")]
        //[InlineData("rushabrisal@gmail.com")]
        //public void IsEmailValid_InvalidEmail_False(string email)
        //{
        //    IEmailValidator _validator = new EmailValidator();

        //    var result = _validator.IsEmailValid(email);

        //    Assert.False(result?.Result);
        //}
    }
}