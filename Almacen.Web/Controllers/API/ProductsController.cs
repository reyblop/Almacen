using Almacen.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        public IProductRepository ProductRepository { get; }

        public ProductsController(IProductRepository productRepository )
        {
            ProductRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(this.ProductRepository.GetAll());
        }
    }
}
