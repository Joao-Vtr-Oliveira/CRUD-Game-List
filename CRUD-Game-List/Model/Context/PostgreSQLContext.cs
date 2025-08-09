using Microsoft.EntityFrameworkCore;

namespace CRUD_Game_List.Model.Context
{
	public class PostgreSQLContext : DbContext
	{
		public PostgreSQLContext() { }

		public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options) { }

	}
}
