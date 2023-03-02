using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_demo
{
	public class Association
	{
		[Key] public int AssocciationId { get; set; }
		public string Title { get; set; }
		public ICollection<Customer> Customers { get; set; } 
	}
}
