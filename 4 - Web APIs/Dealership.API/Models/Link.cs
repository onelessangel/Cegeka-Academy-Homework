using System.ComponentModel.DataAnnotations;

namespace Dealership.API.Models
{
	public class Link
	{
		public int Id { get; set; }
		[Required] public string Href { get; set; }
		[Required] public string Rel { get; set; }
		[Required] public string Method { get; set; }

		public Link(string href, string rel, string method) {
			Href = href;
			Rel = rel;
			Method = method;
		}
	}
}
