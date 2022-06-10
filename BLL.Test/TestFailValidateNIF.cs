using System;
using Xunit;
using FluentAssertions;
using BLL.Service;
using BLL.Model;

namespace BLL.Test
{
    public class TestFailValidateNIF
    {      
        [Theory(DisplayName = "Fail Test for NIF validation")]
        [InlineData("137761512", false)]
        [InlineData("172834679", false)]
        public void TestValidateNIF(string nif, bool resultUnexpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.IsValid.Should().Be(resultUnexpected);
        }
      

        [Theory(DisplayName = "Fail Test for validation of single person NIF")]
        [InlineData("246711752", "Legal Person")]
        [InlineData("216574749", "Legal Person")]
        public void TestValidateNIFSinglePerson(string nif, string resultUnexpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.Type.Should().NotBe(resultUnexpected);
        }     
        
        [Theory(DisplayName = "Fail Test for validation of legal person NIF")]
        [InlineData("577724762", "Single Person")]
        [InlineData("598294104", "Single Person")]
        public void TestValidateNIFLegalPerson(string nif, string resultUnexpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.Type.Should().NotBe(resultUnexpected);
        }

        [Theory(DisplayName = "Fail Test for NIF validation when length is incorrect")]
        [InlineData("2467117523", "The NIF length is incorrect")]
        [InlineData("21657474", "The NIF length is incorrect")]
        public void TestValidateNIFLenght(string nif, string errorMessage)
        {
            Response response = new ValidateNIF(nif).Action();
            
            response.ErrorMessage.Should().Be(errorMessage);
        }      

        [Theory(DisplayName = "Fail Test for NIF validation when value is null")]
        [InlineData(null, "The NIF value is null")]
        public void TestValidateNIFNull(string nif, string errorMessage)
        {
            Response response = new ValidateNIF(nif).Action();
            
            response.ErrorMessage.Should().Be(errorMessage);
        }    
    }
}
