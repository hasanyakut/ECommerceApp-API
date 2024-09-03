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

		private readonly IOrderWriteRepository _orderWriteRepository;
		private readonly IOrderReadRepository _orderReadRepository;
		private readonly ICustomerWriteRepository _customerWriteRepository;

		public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
		{
			_productWriteRepository = productWriteRepository;
			_productReadRepository = productReadRepository;
			_orderWriteRepository = orderWriteRepository;
			_customerWriteRepository = customerWriteRepository;
			_orderReadRepository = orderReadRepository;
		}
		[HttpGet]
		public async Task GetAsync()
		{
			Order order = await _orderReadRepository.GetByIdAsync("349cde41-0e6c-4e31-95bc-10c76d3dc28d");
			order.Address = "Istanbul";
			await _orderWriteRepository.SaveAsync();
		}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
		{
			Product product = await _productReadRepository.GetByIdAsync(id);
			return Ok(product);
		}

    }
}
