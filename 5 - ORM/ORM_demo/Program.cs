using Microsoft.EntityFrameworkCore;
using ORM_demo;
using System.Linq;

internal class Program
{
	private static void Main(string[] args)
	{
		using (var db = new DatabaseContext())
		{
			var product1 = new Product() { Price = 100, Description = "Movie" };
			var product2 = new Product() { Price = 50, Description = "Book" };
			var product3 = new Product() { Price = 20, Description = "Pen" };

			//AddProduct(db, product1);
			//AddProduct(db, product2);
			//AddProduct(db, product3);

			//AddOrderItem(db, 7);
			//AddOrder(db, 8);

			//RemoveOrder(db, 3);
			//RemoveOrderItem(db, 8);
			//RemoveOrderItem(db, 6);
			//RemoveOrder(db);

			//var products = db.Products;

			//foreach (var product in products)
			//{
			//	RemoveProduct(db, product.ProductId);
			//}

			//var orders = db.Orders;
			//foreach (var order in orders)
			//{
			//	Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
			//}
		}
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

	private static void AddOrder(DatabaseContext db, int orderItemId)
	{
		var orderItem = db.OrderItems.Find(orderItemId);

		var order = new Order() { Created = DateTime.Now };
		db.Orders.Add(order);
		db.SaveChanges();

		order = db.Orders.Include(o => o.Items).First();
		order.Items.Add(orderItem);
		db.SaveChanges();
	}

	private static void AddOrderItem(DatabaseContext db, int productId)
	{
		var product = db.Products.Find(productId);

		if (product != null)
		{
			var item = new OrderItem
			{
				Quantity = 1,
				Product = product
			};
			db.OrderItems.Add(item);
			db.SaveChanges();

			//Console.WriteLine("{0} {1} Product: {2}", item.OrderItemId, item.Quantity, item.Product.Description);
		}
	}

	//private static void AddProduct(DatabaseContext db)
	//{
	//	var product = new Product() { Price = 50, Description = "Book" };
	//	db.Products.Add(product);
	//	db.SaveChanges();

	//	foreach (var p in db.Products)
	//	{
	//		Console.WriteLine("{0} {1} {2}", p.ProductId, p.Description, p.Price);
	//	}
	//}

	private static void AddProduct(DatabaseContext db, Product product)
	{
		db.Products.Add(product);
		db.SaveChanges();
	}
}