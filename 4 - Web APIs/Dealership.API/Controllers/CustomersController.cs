using Dealership.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dealership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly DealershipContext _context;

		public CustomersController(DealershipContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}

		[HttpGet]
		public async Task<ActionResult> GetAllCustomers()
		{
			var customers = _context.Customers.ToArrayAsync();
			return Ok(customers);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetCustomer(int id)
		{
			var customer = await _context.Customers.FindAsync(id);

			if (customer == null)
			{
				return NotFound();
			}

			return Ok(customer);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> BuyModel(int id, Model model)
		{
			if (!_context.Models.Any(m => m.Id == model.Id))
			{
				return NotFound();
			}

			var customer = await _context.Customers.FindAsync(id);

			if (customer == null)
			{
				return NotFound();
			}

			customer.PurchasedModels.Add(model);
			_context.Entry(customer).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}

			return Ok(customer);
		}
	}
}
