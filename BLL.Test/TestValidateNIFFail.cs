using System;
using Xunit;
using FluentAssertions;

namespace BLL.Test
{
    public class TestValidateNIFFail
    {      
        [Theory(DisplayName = "Fail Test for NIF validation")]
        [InlineData("137761512", false)]
        [InlineData("172834679", false)]
        [InlineData("268843831", false)]
        public void TestValidateNIF(string nif, bool resultUnexpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.IsValid.Should().Be(resultUnexpected);
        }
      

        [Theory(DisplayName = "Fail Test for validation of single person NIF")]
        [InlineData("246711752", "Legal Person")]
        [InlineData("216574749", "Legal Person")]
        [InlineData("216574749", "Legal Person")]
        public void TestValidateNIFSinglePerson(string nif, string resultUnexpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.Type.Should().Be(resultUnexpected);
        }     
        
        [Theory(DisplayName = "Fail Test for validation of legal person NIF")]
        [InlineData("577724762", "Single Person")]
        [InlineData("598294104", "Single Person")]
        [InlineData("534350607", "Single Person")]
        public void TestValidateNIFLegalPerson(string nif, string resultUnexpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.Type.Should().Be(resultUnexpected);
        }
    }
}
