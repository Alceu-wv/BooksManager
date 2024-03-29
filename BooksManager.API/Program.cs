using Microsoft.IdentityModel.Tokens;
using BooksManager.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//jwt
var tokenValidationParams = new TokenValidationParameters()
{
    IssuerSigningKey = new SymmetricSecurityKey(TokenService.Key()),
    ValidateAudience = false,
    ValidateIssuer = false
};
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = tokenValidationParams;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

BooksManager.Infrastructure.InversionOFControl.DependencyInjection.Inject(builder.Services, builder.Configuration);

// Session - backup das sessions
builder.Services.AddDistributedMemoryCache();

// Session - Implementa o modelo de gerenciamento de Session
builder.Services.AddSession();

// Configure the HTTP request pipeline.
var app = builder.Build();

// Session - Habilita o uso
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
