using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Test()
        {
            return Ok(new CreateToken().TokenCreate());
        }  
        [HttpGet("[action]")]
        public IActionResult TestCreateAdminOrVisitor()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult TestAuth()
        {
            return Ok("Authorized");
        }
        
        [Authorize(Roles = "Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult TestAdmin()
        {
            return Ok("Token Başarılı Bir şekilde giriş yaptı");
        }


    }
}
