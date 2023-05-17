using Core_CategoryApi.Models;
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
        public UserController(EcomMgmtContext company_DbContext)
        {
            ecomMgmtContext = company_DbContext;
        }


        [HttpPost]
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
    }
}
