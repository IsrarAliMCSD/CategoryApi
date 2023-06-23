using Core_CategoryApi.JwtHelper;
using Core_CategoryApi.JWTToken1;
using Core_CategoryApi.Models;
using Core_CategoryApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Core_CategoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        EcomMgmtContext ecomMgmtContext;
        private readonly IJwtTokenProvider _jwtTokenProvider;

        JWTToken jWTToken;
        public UserController(EcomMgmtContext company_DbContext, JWTToken jWTToken1, IJwtTokenProvider jwtTokenProvider)
        {
            ecomMgmtContext = company_DbContext;
            jWTToken= jWTToken1;
            _jwtTokenProvider = jwtTokenProvider;
        }


        [HttpGet]
        [Route("LoginDemo")]
        public async Task<IActionResult> LoginDemo(string userName, string password)
        {
            try
            {
                string ErrorMessage = "";
                //ecomMgmtContext = new EcomMgmtContext();
                var result = ecomMgmtContext.Users.Include("Role").FirstOrDefault(a => a.UserName == userName && a.Password == password);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("The credentials is invalid");
                }
            }
            catch (Exception exx)
            {

                throw;
            }

        }

        [HttpPost]
        [Route("LoginDemo")]
        [AllowAnonymous]
        //[EnableCors]
        public async Task<IActionResult> LoginDemo(VMUserLogin vMUserLogin)
        {
            try
            {
                string ErrorMessage = "";
                //ecomMgmtContext = new EcomMgmtContext();
                var result = ecomMgmtContext.Users.Include("Role").FirstOrDefault(a => a.UserName == vMUserLogin.UserName && a.Password == vMUserLogin.Password);
                if (result != null)
                {
                   // return Ok(jWTToken.GetToken(result));
                    return Ok(_jwtTokenProvider.GenerateToken(result));
                   // return Ok(result);
                }
                else
                {
                    return Ok("The credentials is invalid");
                    return NotFound("The credentials is invalid");
                }
            }
            catch (Exception exx)
            {

                throw;
            }

         }


    }
}
