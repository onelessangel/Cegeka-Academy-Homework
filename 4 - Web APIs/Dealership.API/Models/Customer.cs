using System.ComponentModel.DataAnnotations;

namespace Dealership.API.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required] public string Name { get; set; } = string.Empty;
		[Required] public List<Model> PurchasedModels { get; set; } = new List<Model>();
		//public List<Link> Links { get; set; } = new List<Link>();

		public Customer() { }

		public Customer(string name, List<Model> purchasedModels)
		{
			Name = name;
			PurchasedModels = purchasedModels;
		}

		public Customer(Customer customer)
		{
			Name = customer.Name;
			PurchasedModels = customer.PurchasedModels;
		}
	}
}
