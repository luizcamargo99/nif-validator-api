using Xunit;
using FluentAssertions;
using BLL.Model;
using BLL.Service;

namespace BLL.Test
{
    public class TestSuccessValidateNIF
    {
        [Theory(DisplayName = "Success Test for NIF validation")]
        [InlineData("246711752", true)]
        [InlineData("216574749", true)]
        public void TestValidateNIF(string nif, bool resultExpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.IsValid.Should().Be(resultExpected);
        }       

        [Theory(DisplayName = "Success Test for validation of single person NIF")]
        [InlineData("246711752", "Single Person")]
        [InlineData("216574749", "Single Person")]
        public void TestValidateNIFSinglePerson(string nif, string resultExpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.Type.Should().Be(resultExpected);
        }       

        [Theory(DisplayName = "Success Test for validation of legal person NIF")]
        [InlineData("577724762", "Legal Person")]
        [InlineData("598294104", "Legal Person")]
        public void TestValidateNIFLegalPerson(string nif, string resultExpected)
        {
            Response response = new ValidateNIF(nif).Action(); 
            
            response.Type.Should().Be(resultExpected);
        }       
    }
}
