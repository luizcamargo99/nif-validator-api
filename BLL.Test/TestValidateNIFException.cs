using System;
using Xunit;
using FluentAssertions;

namespace BLL.Test
{
    public class TestValidateNIFException
    {
        [Theory(DisplayName = "Exception Test for NIF validation when length is incorrect")]
        [InlineData("2467117523")]
        [InlineData("21657474")]
        public void TestValidateNIFLenghtException(string nif)
        {
            Action act = () => new ValidateNIF(nif).Action();
            
            act.Should().Throw<ArgumentException>().WithMessage("The NIF length is incorrect");
        }      

        [Theory(DisplayName = "Exception Test for NIF validation when value is null")]
        [InlineData(null)]
        public void TestValidateNIFNullException(string nif)
        {
            Action act = () => new ValidateNIF(nif).Action();
            
            act.Should().Throw<ArgumentNullException>().WithMessage("The NIF value is null");
        }      
    }
}
