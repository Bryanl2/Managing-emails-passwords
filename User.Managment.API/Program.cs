global using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using System.Runtime.ConstrainedExecution;
using User.Management.Service.Models;
using User.Managment.API.Models;
using User.Management.Service.Services;
using IEmailService = User.Management.Service.Services.IEmailService;
using EmailService = User.Management.Service.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                                  .AddJsonFile("appsettings.json", true)
                  .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(configuration["ConnectionDatabase"]));

//Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireLowercase = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireDigit = false;
})
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


//Add config for required email
builder.Services.Configure<IdentityOptions>(x =>
{
    x.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    
});


//Email config
var emailConfig = configuration.GetSection("EmailConfiguration")
                               .Get<EmailConfiguration>();

builder.Services.AddScoped<IEmailService,EmailService>();

builder.Services.AddSingleton(emailConfig);

var app = builder.Build();

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
