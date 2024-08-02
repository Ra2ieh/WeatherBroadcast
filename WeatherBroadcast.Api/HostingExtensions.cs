
namespace WeatherBroadcast.Api
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        {

            // AddAsync services to the container.
            builder.Services.AddMvc();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeatherBroadcastWebAPI", Version = "v1" });
            });

            
            InfrastructureServiceInstaller.InstallServices(builder.Services, builder.Configuration);
            Application.ApplicationDependencyInjection.InstallServices(builder.Services, builder.Configuration);

            return builder.Build();
        }
        public static WebApplication ConfigurePileLine(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapDefaultControllerRoute();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherBroadcastWebAPI");
            });
            return app;
        }
    }
}
