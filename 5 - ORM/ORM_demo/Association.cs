using Microsoft.VisualBasic;
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
		[Key] public int AssociationId { get; set; }
		public string Title { get; set; } = string.Empty;
		public ICollection<Customer> Customers { get; set; } = new List<Customer>();
	}
}
