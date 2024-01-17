using Microsoft.EntityFrameworkCore;
using Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Repositories
{
	public class Context : DbContext
	{
		public DbSet<Client> Clients { get; set; }
        public DbSet<Article> Articles { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//optionsBuilder.UseInMemoryDatabase("API_DB");
				optionsBuilder.LogTo(Console.WriteLine);
			}
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var clts = new List<Client>()
			{
				new Client() { Id = 1, Name = "Ouit", Description = "efefffff"},
				new Client() { Id = 2, Name = "zfzf", Description = "dadadadae" },
				new Client() { Id = 3, Name = "vvevev", Description = "Paddadaad" },
                new Client() { Id = 4, Name = "zfzf", Description = "dadadadae" },
                new Client() { Id = 5, Name = "vvevev", Description = "Paddadaad" }
            };
            var arts = new List<Article>()
            {
                new Article() { Id = 1, Contenu = "efefffff", ClientId= 1 },
                new Article() { Id = 2, Contenu = "dadadadae",ClientId = 2 },
                
            };

            modelBuilder.Entity<Client>().HasData(clts);
            modelBuilder.Entity<Article>().HasData(arts);
            base.OnModelCreating(modelBuilder);
		}
	}
}
