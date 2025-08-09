// Program.cs
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

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (registre ANTES de build)
builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
			policy.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
});


// Dependency Injection:
builder.Services.AddScoped<ICategoryBusiness, CategoryBusiness>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<PostgreSQLContext>();
	db.Database.Migrate();
}


app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
