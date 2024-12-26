using EventBus0032.Interfaces;
using EventBus0032.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using TaskService0032.Data;
using TaskService0032.Services;
using TaskService0032.Services.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddSingleton<IConnection>(sp =>
{
    var factory = new ConnectionFactory
    {
        HostName = "localhost",
        UserName = "guest",
        Password = "guest"
    };
    return factory.CreateConnection();
});
builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>();

// Register Task0032Service
builder.Services.AddScoped<ITaskService0032, Task0032Service>();
builder.Services.AddDbContext<TaskDbContext0032>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITaskService0032, Task0032Service>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
