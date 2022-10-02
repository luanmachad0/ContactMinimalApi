namespace Microsoft.AspNetCore.Builder;
internal static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app,
        IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        return app;
    }
    public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
    {
        app.UseCors(p =>
        {
            p.AllowAnyMethod();
            p.AllowAnyOrigin();
            p.AllowAnyHeader();
        });
        return app;
    }

    public static IApplicationBuilder UseSwaggerEndpoints(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => { });

        return app;
    }
}