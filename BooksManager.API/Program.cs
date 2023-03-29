using Microsoft.IdentityModel.Tokens;
using BooksManager.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

BooksManager.Infrastructure.InversionOFControl.DependencyInjection.Inject(builder.Services, builder.Configuration);

//jwt
var tokenValidationParams = new TokenValidationParameters()
{
    IssuerSigningKey = new SymmetricSecurityKey(TokenService.Key()),
    ValidateAudience = false,
    ValidateIssuer = false
};
builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = tokenValidationParams;
    });


// Configure the HTTP request pipeline.
var app = builder.Build();

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
