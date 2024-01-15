using Business;
using Business.Contracts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Context>(o =>
{
	//o.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WikY_DB;Trusted_Connection = True; ");
	o.UseSqlServer(builder.Configuration.GetConnectionString("API_DB"));
});

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientBusiness, ClientBusiness>();


var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
	var services = serviceScope.ServiceProvider;
	var appDbContext = services.GetRequiredService<Context>();
	appDbContext.Database.EnsureDeleted();
	appDbContext.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
