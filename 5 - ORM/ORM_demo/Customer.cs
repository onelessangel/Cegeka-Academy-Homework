using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_demo
{
	public class Customer
	{
		[Key] public int CustomerId { get; set; }
		public string Name { get; set; } = string.Empty;
		public ICollection<Association> Associations { get; set; } = new List<Association>();
	}
}
