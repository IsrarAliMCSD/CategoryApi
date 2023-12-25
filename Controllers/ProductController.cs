using Core_CategoryApi.JwtHelper;
using Core_CategoryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;

namespace Core_CategoryApi.Controllers
{
    public class ProductController : ControllerBase
    {
        EcomMgmtContext ecomMgmtContext;
        private readonly IJwtTokenProvider _jwtTokenProvider;
        public ProductController(EcomMgmtContext company_DbContext, IJwtTokenProvider jwtTokenProvider)
        {
            ecomMgmtContext = company_DbContext;
            _jwtTokenProvider = jwtTokenProvider;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            string ErrorMessage = "";
            var result = ecomMgmtContext.Products.Where(a => a.IsActive == true).ToList();
            return Ok(result);
        }
        [HttpGet]

        [Route("GetProductById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductById(int productId)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.Products.Where(a => a.ProductId == productId).FirstOrDefault();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            product.CreatdDate = DateTime.UtcNow;
            product.CreatedBy = "israr";
            product.IsActive = true;
            ecomMgmtContext.Products.Add(product);
            await ecomMgmtContext.SaveChangesAsync();
            return Ok("Record Save");
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.Products.Where(a => a.ProductId == product.ProductId).FirstOrDefault();
            if (result != null)
            {
                result.ProductName = product.ProductName;
            }

            await ecomMgmtContext.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.Products.Where(a => a.ProductId == productId).FirstOrDefault();
            if (result != null)
            {
                result.IsActive = false;
            }
            await ecomMgmtContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
