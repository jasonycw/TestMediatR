using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestMediatR.Features;

namespace TestMediatR
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMediatR(typeof(Startup))
                // MediatR do not pick up partially closed generic IRequest type, so need to add DI mapping.
                // Ref: https://github.com/jbogard/MediatR/issues/534
                .AddTransient<IRequestHandler<TestGenericRequest<int>, string>, TestGenericRequestHandler<int>>()
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app) 
            => app
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => 
                    endpoints.MapControllers());
    }
}
