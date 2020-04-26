using Data;
using Data.Gateway;
using Domain.Gateway;
using Domain.Interactor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogisticWebApplication {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public static LogisticDbContext Context = new LogisticDbContext();

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            
            services.AddDbContext<LogisticDbContext>(options =>
                options.UseSqlite("Data Source=logistic.db")
            );

            services.Add(
                new ServiceDescriptor(
                    typeof(IStocksGateway), typeof(StocksGatewayDb), ServiceLifetime.Singleton
                )
            );

            services.Add(
                new ServiceDescriptor(
                    typeof(IWorkersGateway), typeof(WorkersGatewayDb), ServiceLifetime.Singleton
                )
            );

            services.Add(
                new ServiceDescriptor(
                    typeof(IProductsGateway), typeof(ProductsGatewayDb), ServiceLifetime.Singleton
                )
            );

            services.Add(new ServiceDescriptor(typeof(IAddProductInStockInteractor),
                typeof(AddProductInStockInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(IAddStockInteractor),
                typeof(AddStockInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(IAddWorkerInStockInteractor),
                typeof(AddWorkerInStockInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(ILoadProductsInStockInteractor),
                typeof(LoadProductsInStockInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(ILoadStocksInteractor),
                typeof(LoadStocksInteractor), ServiceLifetime.Scoped));
            
            services.Add(new ServiceDescriptor(typeof(ILoadWorkersInStockInteractor),
                typeof(LoadWorkersInStockInteractor), ServiceLifetime.Scoped));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}