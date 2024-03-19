using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CourseProject.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CourseProjectContextConnection") ?? throw new InvalidOperationException("Connection string 'CourseProjectContextConnection' not found.");

builder.Services.AddDbContext<CourseProjectContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<CourseProjectContext>();

// Add services for authentication and authorization
builder.Services.AddAuthentication()
    .AddCookie(); // Add any other authentication schemes if needed

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    // Define other policies if needed
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
