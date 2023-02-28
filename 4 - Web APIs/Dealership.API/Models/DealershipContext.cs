using Microsoft.EntityFrameworkCore;

namespace Dealership.API.Models
{
	public class DealershipContext:DbContext
	{
		public DealershipContext(DbContextOptions<DealershipContext> options) : base(options) { }

		public DbSet<Model> Models { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Customer> Customers { get; set; }

		protected override async void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Brand>()
				.HasMany(b => b.Models)
				.WithOne(a => a.Brand)
				.HasForeignKey(c => c.BrandId);
			modelBuilder.Seed();
		}
	}
}
