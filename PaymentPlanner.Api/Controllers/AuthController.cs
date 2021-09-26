using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentPlanner.Api.ResourceModels;
using PaymentPlanner.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public ActionResult< bool> Login(LoginRequest request)
        {
            var authService = new AuthService();

            return Ok( authService.Login(request.LastName));
        }

    }
}
