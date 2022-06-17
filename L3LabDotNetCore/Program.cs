
using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Repositories;
using L3LabDotNetCore.Services.Notes;
using Microsoft.EntityFrameworkCore;
/*public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
}*/

var builder = WebApplication.CreateBuilder(args);

//Add logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Get connection string from settings
string connection = builder.Configuration.GetConnectionString("DefaultLocalHost");

// Add services to the container.
builder.Services.AddCors(options =>
         options.AddPolicy("AllowSpecific", p => p.WithOrigins("https://localhost:4200")
                                                   .WithMethods("*")
                                                   .WithHeaders("*")));

//builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//builder.Services.AddScoped<IServiceProvider, ServiceProvider>();
builder.Services.AddScoped<INoteService, NoteService>();
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Mannage Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "L3LabApi", Version = "v1" });
});

//Mannage DB Context
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));

var app = builder.Build();
app.UseCors();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDBContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "L3LabApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
