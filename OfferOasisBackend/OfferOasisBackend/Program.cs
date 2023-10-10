
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OfferOasisBackend.Controllers;
using OfferOasisBackend.Model;
using OfferOasisBackend.Service;

var builder = WebApplication.CreateBuilder(args);

AddServices();
AddCors();
ConfigureSwagger();
AddAuthentication();

var app = builder.Build();

app.UseCors("ReactAppPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

void AddAuthentication()
{
    builder.Services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "apiWithAuthBackend",
                ValidAudience = "apiWithAuthBackend",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("!SomethingSecret!")
                ),
            };
        });
}

void AddServices()
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddSingleton<ILogger<UserController>, Logger<UserController>>();
    builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
    builder.Services.AddSingleton<ITestRepository, TestRepository>();
}

void AddCors()
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("ReactAppPolicy", builder =>
        {
            builder
                .WithOrigins("*")
                .AllowAnyMethod()
                .AllowAnyHeader();
        
        });
    });
}

void ConfigureSwagger()
{
    builder.Services.AddSwaggerGen();

}