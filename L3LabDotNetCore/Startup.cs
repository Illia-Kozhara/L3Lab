using L3Lab.EntityFrameworkCore;
using L3Lab.EntityFrameworkCore.Entities;
using L3LabDotNetCore.Repositories;
using Microsoft.EntityFrameworkCore;


namespace L3LabDotNetCore
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //MVC

            // Get connection string from settings
            string connection = Configuration.GetConnectionString("DefaultLocalHost");

            // Mannage CORS
            services.AddCors(options =>
                     options.AddPolicy("AllowSpecific", p => p.WithOrigins("https://localhost:4200")
                                                               .WithMethods("*")
                                                               .WithHeaders("*")));

            //Mannage Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "L3LabApi", Version = "v1" });
            });

            //Mannage DB Context
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));
            
            //services.AddSingleton<INoteAppService, NoteAppService>();
            services.AddSingleton<IRepository<Note>, NoteRepository>();
            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
        }

        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "L3LabApi v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors();


        }
    }
}
