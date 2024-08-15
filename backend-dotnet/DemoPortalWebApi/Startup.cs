namespace DemoPortalWebApi
{
    using Common;
    using Common.IRepo;
    using Common.IService;
    using Common.Models.DbConnectionModels;
    using DataAccess;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MongoDB.Driver.Core.Configuration;
    using Service;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use thi s method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSingleton<IMongoDbContext>(sp =>
            new MongoDbContext(
            Configuration.GetConnectionString("MongoDb"), "employee"));
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepo, TransactionRepo>();
            services.Configure<ProductDBSettings>(
            Configuration.GetSection(nameof(ProductDBSettings)));
            services.AddScoped<IProductService, ProductService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization(); // This should be placed between UseRouting and UseEndpoints

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
