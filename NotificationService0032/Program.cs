using Microsoft.EntityFrameworkCore;
using NotificationService0032.Services.IService;
using NotificationService0032.Services;
using NotificationService0032.Data;
using NotificationService0032.Handlers;
using RabbitMQ.Client;
using EventBus0032.Interfaces;
using EventBus0032.RabbitMQ;
using TaskService0032.Messaging.Events;

var builder = WebApplication.CreateBuilder(args);

// Add RabbitMQ Connection and EventBus
builder.Services.AddSingleton<IConnection>(sp =>
{
    var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
    return factory.CreateConnection();
});
builder.Services.AddSingleton<IEventBus, RabbitMQEventBus>();
builder.Services.AddSingleton<TaskCreatedEventHandler>();
builder.Services.AddSingleton<TaskUpdatedEventHandler>();



// Subscribe to events


// Add services to the container.
builder.Services.AddDbContext<NotificationDbContext0032>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<INotification0032Service, Notification0032Service>();
builder.Services.AddScoped<INotificationPreference0032Service, NotificationPreference0032Service>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var eventBus = scope.ServiceProvider.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TaskCreatedEvent, TaskCreatedEventHandler>();
    eventBus.Subscribe<TaskUpdatedEvent, TaskUpdatedEventHandler>();
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
