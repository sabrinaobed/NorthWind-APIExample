using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NorthWind_APIExample.Models;
using NorthWind_APIExample.Dto;


namespace NorthWind_APIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly IMapper _mapper;

        public ProductController(NorthwindContext context, IMapper mapper)
        {
             _context = context;
            _mapper = mapper;

        }

        //GET ALL PRODUCTS
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products= await _context.Products.ToListAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productDtos);
        }
    }
}
