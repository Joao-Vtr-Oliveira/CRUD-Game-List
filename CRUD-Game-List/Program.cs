using CRUD_Game_List.Business;
using CRUD_Game_List.Business.Implementations;
using CRUD_Game_List.Model.Context;
using CRUD_Game_List.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("PostgreConnection");
Console.WriteLine("[DB] " + new Npgsql.NpgsqlConnectionStringBuilder(connectionString) { Password = "***" });

builder.Services.AddDbContext<PostgreSQLContext>(options =>
		options.UseNpgsql(connectionString)
);

builder.Services.AddControllers(options =>
{
	options.Filters.Add<ApiExceptionFilter>();
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
			policy.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
});

// Dependency Injection
builder.Services.AddScoped<ICategoryBusiness, CategoryBusiness>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Força URL para funcionar dentro do container
app.Urls.Add("http://0.0.0.0:8080");

// Swagger (antes dos middlewares de roteamento)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD Game List API v1");
	c.RoutePrefix = "swagger"; // deixa acessível em /swagger
});

// Remove redirecionamento HTTPS no container para evitar problema
// app.UseHttpsRedirection(); // <- comentado para ambiente Docker

app.UseCors();
app.UseAuthorization();
app.MapControllers();

// Garante que migrações rodem no startup
using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<PostgreSQLContext>();
	db.Database.Migrate();
}

app.Run();
