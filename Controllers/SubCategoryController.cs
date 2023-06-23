using Core_CategoryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_CategoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        EcomMgmtContext ecomMgmtContext;
        public SubCategoryController(EcomMgmtContext company_DbContext)
        {
            ecomMgmtContext = company_DbContext;
        }

        [HttpGet]
        [Route("GetSubCategories")]
        public async Task<IActionResult> GetSubCategories()
        {
            string ErrorMessage = "";
            var result = ecomMgmtContext.SubCategories.Include("Category").Where(a => a.IsActive == true).Take(100).ToList();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSubCategoryById")]
        public async Task<IActionResult> GetSubCategoryById(int subCategoryId)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.SubCategories.Where(a => a.SubCategoryId == subCategoryId).FirstOrDefault();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddSubCategory")]
        public async Task<IActionResult> AddSubCategory(SubCategory subCategory)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            subCategory.CreatdDate = DateTime.UtcNow;
            subCategory.CreatedBy = "israr";
            subCategory.IsActive = true;
            ecomMgmtContext.SubCategories.Add(subCategory);
            await ecomMgmtContext.SaveChangesAsync();
            return Ok("Record Save");
        }

        [HttpPost]
        [Route("UpdateSubCategory")]
        public async Task<IActionResult> UpdateSubCategory(SubCategory subCategory)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.SubCategories.Where(a => a.SubCategoryId == subCategory.SubCategoryId).FirstOrDefault();
            if (result != null)
            {
                result.SubCategoryName = subCategory.SubCategoryName;
            }

            await ecomMgmtContext.SaveChangesAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteSubCategory")]
        public async Task<IActionResult> DeleteSubCategory(int subCategoryId)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.SubCategories.Where(a => a.SubCategoryId == subCategoryId).FirstOrDefault();
            if (result != null)
            {
                result.IsActive = false;
            }
            await ecomMgmtContext.SaveChangesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetSubCategoriesByCategoryId")]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(int categoryId)
        {
            string ErrorMessage = "";
            ecomMgmtContext = new EcomMgmtContext();
            var result = ecomMgmtContext.SubCategories.Where(a => a.CategoryId == categoryId).FirstOrDefault();
            return Ok(result);
        }
    }
}
