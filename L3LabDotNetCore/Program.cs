using L3Lab.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from settings
string connection = builder.Configuration.GetConnectionString("DefaultLocalHost");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Mannage Swagger
builder.Services.AddSwaggerGen();
//Mannage DB Context
builder.Services.AddDbContext<MessagesContext>(options => options.UseSqlServer(connection));
/*builder.Services.AddDbContext<BloggingContext>(opt =>
    opt.UseInMemoryDatabase("BloggingList"));*/

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<MessagesContext>();
    context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// добавляем контекст ApplicationContext в качестве сервиса в приложение

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
