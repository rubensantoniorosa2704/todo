using Microsoft.EntityFrameworkCore;
using TodoApi.Core.Application;
using TodoApi.Core.Application.Controller;
using TodoApi.Core.Application.Interfaces;
using TodoApi.Core.Config;
using TodoApi.Core.Domain.Services;
using TodoApi.Core.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// Migrations Database Connection
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBString")));

builder.Services.AddControllers();
builder.Services.AddScoped<UserController>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
    });

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MyDbContext>();
        context.Database.Migrate();
    }

    app.UseCors(context =>
    {
        context.AllowAnyHeader();
        context.AllowAnyMethod();
        context.AllowAnyOrigin();
    });
}

Routing.MapEndpoints(app);

app.Run();
