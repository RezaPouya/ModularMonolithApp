using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EndPointAddress = EndPoints.WebApi.bounded_contexts.account.EndPointAddress;
namespace EndPoints.WebApi.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        [Route(EndPointAddress.SignUp)]
        public async Task<IActionResult> SingUp()
        {

            return Ok();
        }
    }
}
