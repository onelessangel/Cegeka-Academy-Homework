using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_demo
{
	public class Association
	{
		public int AssociationId { get; set; }
		public string Title { get; set; }
		public ICollection<Customer> Customers { get; set; }
	}
}
