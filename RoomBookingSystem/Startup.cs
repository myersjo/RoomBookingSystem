using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using RoomBookingSystem.Business.Bookings;
using RoomBookingSystem.Business.IDAL;
using RoomBookingSystem.DAL.Context;
using RoomBookingSystem.DAL.Repository;

namespace RoomBookingSystem.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            services.AddDbContext<BookingContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddAzureAdB2CBearer(options => _config.Bind("AzureAdB2C", options));

            services.AddLogging();

            services.AddMvc();

            services.AddScoped<IBookingManager, BookingManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
