using Microsoft.EntityFrameworkCore;

namespace Dealership.API.Models
{
	public static class ModelBuilderExtension
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Brand>().HasData(
				new Brand { Id = 1, Name = "Mercedes-Benz"},
				new Brand { Id = 2, Name = "Ford" },
				new Brand { Id = 3, Name = "Volkswagen" });

			modelBuilder.Entity<Model>().HasData(
				new Model { Id = 1, BrandId = 1, Type = "Hatchback", Name = "A-Class", Year = 2022, Description = "C-segment/Subcompact executive hatchback." },
				new Model { Id = 2, BrandId = 1, Type = "Sedan", Name = "C-Class", Year = 2021, Description = "D-segment/compact executive sedan." },
				new Model { Id = 3, BrandId = 1, Type = "Coupe/Convertible", Name = "E-Class", Year = 2021, Description = "E-segment/executive coupe and convertible." },
				new Model { Id = 4, BrandId = 1, Type = "SUV", Name = "GLC", Year = 2020, Description = "Compact luxury crossover SUV/coupe SUV." },
				new Model { Id = 5, BrandId = 1, Type = "Sport car", Name = "AMG GT 4-Door Coupé", Year = 2021, Description = "Front-engine, rear-wheel-drive 5-door liftback sedan." },
				new Model { Id = 6, BrandId = 1, Type = "Van", Name = "Citan", Year = 2022, Description = "Panel van and leisure activity vehicle." },

				new Model { Id = 7, BrandId = 2, Type = "Hatchback", Name = "Focus", Year = 2021, Description = "C-segment/Small family/Compact hatchback." },
				new Model { Id = 8, BrandId = 2, Type = "Sedan", Name = "Taurus", Year = 2019, Description = "E-segment/Full-size sedan." },
				new Model { Id = 9, BrandId = 2, Type = "SUV", Name = "Explorer", Year = 2022, Description = "Three-row mid-size crossover SUV." },
				new Model { Id = 10, BrandId = 2, Type = "Sport car", Name = "Mustang", Year = 2022, Description = "Long-running pony/muscle car." },
				new Model { Id = 11, BrandId = 2, Type = "Van", Name = "E-Series", Year = 2021, Description = "Full-size van sold in North America." },

				new Model { Id = 12, BrandId = 3, Type = "Hatchback", Name = "Golf", Year = 2019, Description = "C-segment hatchback." },
				new Model { Id = 13, BrandId = 3, Type = "Sedan", Name = "Passat", Year = 2019, Description = "D-segment sedan for the European market." },
				new Model { Id = 14, BrandId = 3, Type = "SUV", Name = "T-Cross", Year = 2019, Description = "B-segment crossover SUV built above the MQB A0 platform." },
				new Model { Id = 16, BrandId = 3, Type = "Van", Name = "Transporter", Year = 2019, Description = "Mid-size van. Available as a panel van." });

			modelBuilder.Entity<Customer>().HasData(
				new Customer { Id = 1, Name = "Customer1" },
				new Customer { Id = 2, Name = "Customer2" },
				new Customer { Id = 3, Name = "Customer3" });
		}
	}
}
