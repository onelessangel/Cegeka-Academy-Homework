using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dealership.API.Models
{
	public class Model
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Type { get; set; }
		[Required]
		public int Year { get; set; }
		[Required]
		public string Description { get; set; }
		[Required]
		public int BrandId { get; set; }
		[JsonIgnore]
		public virtual Brand? Brand { get; set; }
		
	}
}
