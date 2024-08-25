using API.StefaniniTest;
using API.StefaniniTest.Domain;
using API.StefaniniTest.Domain.Notifications;
using API.StefaniniTest.Infrastructure;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

IServiceCollection serviceCollection = builder.Services.AddDbContext<ApiStefaniniTestDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var assemblies = Assembly.Load("API.StefaniniTest.Domain");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

builder.Services.AddFluentValidationAutoValidation();

Startup.ConfigureValidators(builder.Services);
Startup.ConfigureRepositories(builder.Services);

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<INotificationService, NotificationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

//builder.Services.AddInfrastructureSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();