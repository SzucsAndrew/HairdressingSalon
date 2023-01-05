using HairdressingSalon.Web.Helper;
using HairdressingSalon.Web.Helper.DepedencyInjectionHelper;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDataLayer(builder.Configuration);
services.AddBllLayer();
services.AddWebLayer(builder.Configuration);
services.AddRazorPages();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    new DatabaseIntegrityHelper().CheckMIgration(serviceProvider);
    await new SeedHelper().Seed(serviceProvider);
}

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
