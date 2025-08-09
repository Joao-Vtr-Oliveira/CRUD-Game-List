// Program.cs
using CRUD_Game_List.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("PostgreConnection");

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
