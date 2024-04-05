using Abstodo.Business.Abstract;
using Abstodo.Business.Concrete;
using Abstodo.DataAccess.Abstract;
using Abstodo.DataAccess.Concrete.EntityFramework;
using Abstodo.WebUI.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EfAbstodoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EfAbstodoContext"));
});


// Add services to the container.
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddScoped<ITaskService, TaskManager>();
builder.Services.AddScoped<ITaskRepository, EfTaskRepository>();

builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IProjectRepository, EfProjectRepository>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.  
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddAutoMapper(typeof(MappingProfile));
//builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews()
.AddJsonOptions(options => 
{
    //We need to configure the JSON serializer options if you want to keep the property names exactly as they are in our C# models (i.e., without converting them to camelCase)
    // A property naming policy, or null to leave property names unchanged.
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
//builder.Services.AddDbContext<AbstodoContext>();

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
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Task}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
