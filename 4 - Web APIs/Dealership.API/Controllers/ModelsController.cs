using Dealership.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dealership.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ModelsController : ControllerBase
	{
		private readonly DealershipContext _context;

		public ModelsController(DealershipContext context)
		{
			_context = context;
			_context.Database.EnsureCreated();
		}

		[HttpGet]
		public async Task<ActionResult> GetAllModels()
		{
			var models = _context.Models.ToArrayAsync();
			return Ok(models);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetModel(int id)
		{
			var model = await _context.Models.FindAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			return Ok(model);
		}

		[HttpPost]
		public async Task<ActionResult<Model>> AddModel(Model model)
		{
			_context.Models.Add(model);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetModel", new { id = model.Id }, model);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Model>> UpdateModel(int id, Model model)
		{
			if (id != model.Id)
			{
				return BadRequest();
			}

			_context.Entry(model).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!_context.Models.Any(m => m.Id == id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteModel(int id)
		{
			var model = await _context.Models.FindAsync(id);

			if (model == null)
			{
				return NotFound();
			}

			_context.Models.Remove(model);
			await _context.SaveChangesAsync();

			return Ok(model);
		}
	}
}
