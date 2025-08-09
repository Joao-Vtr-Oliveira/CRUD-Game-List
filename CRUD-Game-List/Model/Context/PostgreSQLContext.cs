using Microsoft.EntityFrameworkCore;

namespace CRUD_Game_List.Model.Context
{
	public class PostgreSQLContext : DbContext
	{
		public PostgreSQLContext() { }

		public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options) { }

		public DbSet<Game> Games => Set<Game>();
		public DbSet<Category> Categories => Set<Category>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Relacionamento 1:N (Category -> Games)
			modelBuilder.Entity<Game>()
					.HasOne(g => g.Category)
					.WithMany()
					.HasForeignKey(g => g.CategoryID);

			// (Opcional) índice único para nome de categoria
			modelBuilder.Entity<Category>()
					.HasIndex(c => c.Name)
					.IsUnique();
		}
	}

}
