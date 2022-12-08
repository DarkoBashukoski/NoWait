using Microsoft.EntityFrameworkCore;
using NoWait.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("NoWaitContext");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NoWaitContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

DatabaseInitializer.init(app.Services.CreateScope().ServiceProvider.GetRequiredService<NoWaitContext>());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();