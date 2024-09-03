using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		readonly private IProductWriteRepository _productWriteRepository;
		readonly private IProductReadRepository _productReadRepository;

		public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
		{
			_productWriteRepository = productWriteRepository;
			_productReadRepository = productReadRepository;
		}
		[HttpGet]
		public async Task GetAsync()
		{
			await _productWriteRepository.AddRangeAsync(new()
			{
				new() { Id = Guid.NewGuid(), Name = "Product1", Price = 100, CreatedDate = DateTime.Now, Stock = 10 },
				new() { Id = Guid.NewGuid(), Name = "Product2", Price = 200, CreatedDate = DateTime.Now, Stock = 20 },
				new() { Id = Guid.NewGuid(), Name = "Product3", Price = 400, CreatedDate = DateTime.Now, Stock = 30 },
				new() { Id = Guid.NewGuid(), Name = "Product4", Price = 500, CreatedDate = DateTime.Now, Stock = 40 },
			});
			await _productWriteRepository.SaveAsync();
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
		{
			Product product = await _productReadRepository.GetByIdAsync(id);
			return Ok(product);
		}

    }
}
