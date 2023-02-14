using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRMES.Data;
using QRMES.Entities;
using QRMES.Models;
using QRMES.Services;
using System.Text;

namespace QRMES.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public ProductsController(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> Get([FromQuery] int page = 1)
        {
            var products = _dataContext.Products.AsQueryable();
            var pageDto = new PageModel
            {
                PageNumber = page,
                PageSize = 10,
            };
            var pagedResult = await PagedResult.FromAsync(products, pageDto);
            return Ok(pagedResult);
        }

        [HttpGet("{codIdx}")]
        public async Task<ActionResult<Product>> GetById(string codIdx)
        {
            var result = await _dataContext.Products.FirstOrDefaultAsync(p => p.CodIdx == codIdx);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<Product>> Create([FromBody] AddProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mappedProduct = _mapper.Map<Product>(product);
            _dataContext.Products.Add(mappedProduct);
            await _dataContext.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Product>> Update([FromBody] UpdateProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existing = await _dataContext.Products.FirstOrDefaultAsync(p => p.CodIdx == product.CodIdx);
            _mapper.Map<UpdateProductDto, Product>(product, existing);
            existing.RegistrationDate = existing.RegistrationDate.AddHours(2);
            await _dataContext.SaveChangesAsync();

            return Ok(existing);
        }

        [HttpDelete("{codIdx}")]
        public async Task<ActionResult<Product>> Delete(string codIdx)
        {
            var existing = await _dataContext.Products.FirstOrDefaultAsync(p => p.CodIdx == codIdx);
            _dataContext.Remove(existing);
            await _dataContext.SaveChangesAsync();

            return Ok(existing);
        }
    }
}