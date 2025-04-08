﻿using Microsoft.AspNetCore.Http;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return Ok(productDtos);
        }
    

    //GET PRODUCT BY ID
    [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            
              return NotFound();

                return Ok(_mapper.Map<ProductDto>(product));
            
        }

        //CREATE PRODUCT
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, _mapper.Map<ProductDto>(product));
        }


    }
} 
