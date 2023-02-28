using System.ComponentModel.DataAnnotations;

namespace Dealership.API.Models
{
	public class Brand
	{
		public int Id { get; set; }
		[Required] public string Name { get; set; } = string.Empty;
		public virtual List<Model>? Models { get; set; }
	}
}
