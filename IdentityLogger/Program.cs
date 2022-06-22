using Demo63Assignment.Models;
using Demo63Assignment.Models.Interface;
using Demo63Assignment.Models.Service;
using Demo63Assignment.Models.ViewModel;
using IdentityLogger.Data;
using IdentityLogger.Data.Service;
using IdentityLogger.Data.UtilityClass;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationIdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
AddDependacyInjection(builder);

//Emai configuration
builder.Services.Configure<SMTPConfigModel>(builder.Configuration.GetSection("SMTPConfig"));




var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//to check you have account in system or not
app.UseAuthorization();//user permissions

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();  //all identity page has made in razor view that's why we map that

app.Run();
void AddDependacyInjection(WebApplicationBuilder builder)
{
    var ConnectionString = builder.Configuration.GetConnectionString("defaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    builder.Services.AddScoped<ICrudService<UserViewModel>, UserService>();
    builder.Services.AddScoped<ICrudService<DepartmentViewModel>, DepartmentService>();
    builder.Services.AddScoped<IDepartmentService, DepartmentService>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IEmailService, EmailService>();

}