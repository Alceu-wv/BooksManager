using Microsoft.EntityFrameworkCore;
using BooksManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//builder.Services.AddDbContext<BooksDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("InvestimentoDb")
//   ));
//BooksManager.Infrastructure.InversionOFControl.DependencyInjection.Inject(builder.Services, builder.Configuration);

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
