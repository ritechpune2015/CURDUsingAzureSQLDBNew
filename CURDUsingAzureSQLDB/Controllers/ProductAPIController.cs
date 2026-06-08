using CURDUsingAzureSQLDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CURDUsingAzureSQLDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        CompanyContext cc;
        public ProductAPIController(CompanyContext _cc)
        {
            cc = _cc;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this.cc.Products.ToList());
        }

        [HttpPost]
        public IActionResult addProduct(Product rec)
        {
            if (rec == null)
                return BadRequest();

            this.cc.Products.Add(rec);
            this.cc.SaveChanges();
            return Ok("Product Added Successfully");
        }

        [HttpPut]
        public IActionResult updateProduct(Product rec)
        {
            if (rec == null)
                return BadRequest();

            this.cc.Entry(rec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.cc.SaveChanges();
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteProduct(int id)
        {
            var rec = this.cc.Products.SingleOrDefault(p => p.ProductID == id);

            if (rec == null)
                return NotFound();

            this.cc.Products.Remove(rec);
            this.cc.SaveChanges();

            return Ok("Product Deleted Successfully");
        }
    }
}
