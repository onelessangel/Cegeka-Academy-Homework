using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;
using ORM_demo;
using System.Linq;

internal class Program
{
	private static void Main(string[] args)
	{
		using (var db = new DatabaseContext())
		{
			Product product1 = new Product() { Price = 100, Description = "Movie" };
			Product product2 = new Product() { Price = 50, Description = "Book" };
			Product product3 = new Product() { Price = 20, Description = "Pen" };

			Association association1 = new Association() { Title = "Cegeka" };
			Association association2 = new Association() { Title = "ING" };
			Association association3 = new Association() { Title = "Auchan" };

			Customer customer1 = new Customer { Name = "Andrei" };
			Customer customer2 = new Customer { Name = "Alexandra" };
			Customer customer3 = new Customer { Name = "Ion" };
			Customer customer4 = new Customer { Name = "Angelica" };

			// adauga automat si legaturile pentru customers
			association1.Customers.Add(customer1);
			association1.Customers.Add(customer2);
			association2.Customers.Add(customer2);

			//customer1.Associations.Add(association1);
			//customer2.Associations.Add(association1);
			//customer2.Associations.Add(association2);

			//customer3.Associations.Add(association3);
			//customer4.Associations.Add(association3);

			association3.Customers.Add(customer3);
			association3.Customers.Add(customer4);


			// CUSTOMERS
			//AddCustomer(db, customer2);
			//RemoveCustomer(db, 5);

			// ASSOCIATIONS
			//AddAssociation(db, association3);
			//RemoveAssociation(db, 1);


			// TEST CUSTOMERS & ASSOCTIATIONS RETURN
			//Customer foundCustomer = GetCustomer(db, 7);
			//Console.WriteLine(foundCustomer.Name);

			//Association foundAssociation = GetAssociation(db, 5);
			//Console.WriteLine(foundAssociation.Title);


			// PRODUCTS
			//AddProduct(db, product1);
			//AddProduct(db, product2);
			//AddProduct(db, product3);
			//RemoveProduct(db, 15);
			//RemoveProduct(db, 16);
			//RemoveProduct(db, 17);


			// ORDER ITEMS
			//AddOrderItem(db, 18);
			//AddOrderItem(db, 19);
			//AddOrderItem(db, 20);
			//UpdateOrderItem(db, 14, 3);
			//RemoveOrderItem(db, 8);

			// ORDERS
			//AddOrder(db, 12, 1);
			//AddOrder(db, 13, 2);
			//UpdateOrder(db, 8, 14);
			//AddOrder(db, 10, 11);
			//AddOrder(db, 11, 11);
			//RemoveOrder(db, 4);
			//RemoveOrder(db, 5);
			//RemoveOrder(db, 6);


			// putem transforma in lista ca sa nu deschidem mai multi Data Readers
			//var products = db.Products;
			//foreach (var product in products)
			//{
			//	//RemoveProduct(db, product.ProductId);
			//}

			// STERGERE MULTIPLA
			////products.RemoveRange(products);
			///db.SaveChanges();

			// aduce referinta la customers - cand clasa mea contine referinte catre alte obiecte
			//var association = db.Associations.Include(a => a.Customers).FirstOrDefault(a => a.AssociationId == 1);

			GetTotalAssociationExpenses(db, 1);
		}
	}

	private static void AddProduct(DatabaseContext db, Product product)
	{
		db.Products.Add(product);
		db.SaveChanges();
	}

	private static void AddOrderItem(DatabaseContext db, int productId)
	{
		var product = db.Products.Find(productId);

		if (product == null)
		{
			return;
		}

		var item = new OrderItem { Quantity = 1, Product = product };
		db.OrderItems.Add(item);
		db.SaveChanges();
	}

	private static void UpdateOrderItem(DatabaseContext db, int orderItemId, int newQuantity)
	{
		var orderItem = db.OrderItems.Find(orderItemId);

		if (orderItem == null)
		{
			return;
		}

		orderItem.Quantity = newQuantity;
		db.SaveChanges();
	}

	private static void AddOrder(DatabaseContext db, int orderItemId, int customerId)
	{
		var orderItem = db.OrderItems.Find(orderItemId);
		var customer = db.Customers.Find(customerId);

		if (customer == null)
		{
			return;
		}

		var order = new Order() { Created = DateTime.Now, Customer = customer };
		db.Orders.Add(order);
		db.SaveChanges();

		// include referintele catre lista de itemi
		order = db.Orders.Include(o => o.Items).First();
		order.Items.Add(orderItem);
		db.SaveChanges();
	}

	private static void UpdateOrder(DatabaseContext db, int orderId, int orderItemId)
	{
		var order = db.Orders.Find(orderId);
		var orderItem = db.OrderItems.Find(orderItemId);

		if (orderItem == null)
		{
			return;
		}

		order = db.Orders.Include(o => o.Items).First();
		order.Items.Add(orderItem);
		db.SaveChanges();
	}

	private static void AddCustomer(DatabaseContext db, Customer customer)
	{
		db.Customers.Add(customer);
		db.SaveChanges();
	}

	private static void AddAssociation(DatabaseContext db, Association association)
	{
		db.Associations.Add(association);
		db.SaveChanges();
	}

	private static Customer? GetCustomer(DatabaseContext db, int customerId)
	{
		var customer = db.Customers.Find(customerId);
		return customer;
	}
	
	private static Association? GetAssociation(DatabaseContext db, int associationId)
	{
		var association = db.Associations.Find(associationId);
		return association;
	}

	private static void RemoveProduct(DatabaseContext db, int id)
	{
		var product = db.Products.Find(id);
		db.Products.Remove(product);
		db.SaveChanges();
	}

	private static void RemoveOrderItem(DatabaseContext db, int id)
	{
		var orderItem = db.OrderItems.Find(id);
		db.OrderItems.Remove(orderItem);
		db.SaveChanges();
	}

	private static void RemoveOrder(DatabaseContext db, int id)
	{
		var order = db.Orders.Find(id);
		db.Orders.Remove(order);
		db.SaveChanges();
	}

	private static void RemoveCustomer(DatabaseContext db, int id)
	{
		var customer = db.Customers.Find(id);
		db.Customers.Remove(customer);
		db.SaveChanges();
	}

	private static void RemoveAssociation(DatabaseContext db, int id)
	{
		var association = db.Associations.Find(id);
		db.Associations.Remove(association);
		db.SaveChanges();
	}

	private static void GetTotalAssociationExpenses(DatabaseContext db, int associationId)
	{
		var association = db.Associations
								.Include(a => a.Customers)
								.FirstOrDefault(a => a.AssociationId == 1);

		if (association == null)
		{
			return;
		}

		double total = 0;

		foreach (Customer customer in association.Customers)
		{
			foreach (Order order in db.Orders
										.Include(o => o.Items)
										.ThenInclude(i => i.Product)
										.Where(o => o.Customer.CustomerId != customer.CustomerId))
			{
				foreach (OrderItem item in order.Items)
				{
					total += item.Quantity * item.Product.Price;
				}
			}
		}

		Console.WriteLine($"Total {association.Title} expenses: {total} ron.");
	}

}