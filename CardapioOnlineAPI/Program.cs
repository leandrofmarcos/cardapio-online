using CardapioOnlineAPI.Db;
using CardapioOnlineAPI.Repositories;
using CardapioOnlineAPI.Repositories.Impl;
using CardapioOnlineAPI.Services;
using CardapioOnlineAPI.Services.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddTransient<IMenuRepository, MenuEFRepositoryImpl>();

//builder.Services.AddDbContext<AppDbContext>(options =>
//        options.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var sp = scope.ServiceProvider;
    var dbContext = sp.GetRequiredService<AppDbContext>();

    dbContext.Database.EnsureCreated();
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
