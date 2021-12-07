using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using solarsystem.Data;


var builder = WebApplication.CreateBuilder(args);




// Add services to the container.



builder.Services.AddRazorPages();

builder.Services.AddDbContext<SolarSystContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SolarSystContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();
CreateDbIfNotExists(app);


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

app.UseAuthorization();

app.MapRazorPages();

app.Run();



static void CreateDbIfNotExists(WebApplication host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<SolarSystContext>();
            context.Database.EnsureCreated();
            // DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}