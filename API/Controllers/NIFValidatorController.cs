using BLL.Model;
using BLL.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NIFValidatorController : ControllerBase
    {      
        [HttpGet]
        public Response Get(string nif)
        {
            return new ValidateNIF(nif).Action();
        }
    }
}
