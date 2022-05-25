
using L3Lab.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from settings
string connection = builder.Configuration.GetConnectionString("DefaultLocalHost");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//Mannage Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "L3LabApi", Version = "v1" });
});
//Mannage DB Context
builder.Services.AddDbContext<NotesContext>(options => options.UseSqlServer(connection));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<NotesContext>();
    context.Database.EnsureCreated();
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "L3LabApi v1"));
}


// ��������� �������� ApplicationContext � �������� ������� � ����������

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
