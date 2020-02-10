﻿namespace Almacen.Web.Data
{
    using Almacen.Web.Data.Entities;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class DataContext : IdentityDbContext<User>
	{
		public DbSet<Product> Products { get; set; }

		public DbSet<Country> Countries { get; set; }
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
	}

}
