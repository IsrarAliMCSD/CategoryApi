using Core_CategoryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core_CategoryApi.Controllers
{
    public class CategoryController : ControllerBase
    {
        EcomMgmtContext ecomMgmtContext;
        public CategoryController(EcomMgmtContext company_DbContext)
        {
            ecomMgmtContext = company_DbContext;
        }
      
        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.Categories.Where(a=>a.IsActive==true).Take(10).ToList();
                return Ok(result);
        }

        [HttpGet]  

        [Route("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.Categories.Where(a=> a.CategoryId==categoryId).FirstOrDefault();
            return Ok(result);
        }
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            category.CreatdDate = DateTime.UtcNow;
            category.CreatedBy = "israr";
            category.IsActive = true;
            ecomMgmtContext.Categories.Add(category);
           await ecomMgmtContext.SaveChangesAsync();
            return Ok("Record Save");
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.Categories.Where(a => a.CategoryId == category.CategoryId).FirstOrDefault();
            if (result != null)
            {
                result.CategoryName = category.CategoryName;
            }

            await ecomMgmtContext.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int  categoryId)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.Categories.Where(a => a.CategoryId == categoryId).FirstOrDefault();
            if(result!=null)
            {
                result.IsActive = false;
            }
            await ecomMgmtContext.SaveChangesAsync();
            return Ok(result);
        }
    }
}
