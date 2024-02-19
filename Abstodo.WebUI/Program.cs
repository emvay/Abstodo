using Abstodo.Business.Abstract;
using Abstodo.Business.Concrete;
using Abstodo.DataAccess.Abstract;
using Abstodo.DataAccess.Concrete.EntityFramework;
using Abstodo.WebUI.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EfAbstodoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("EfAbstodoContext"));
});


// Add services to the container.
builder.Services.AddScoped<ITaskService, TaskManager>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IProjectRepository, EfProjectRepository>();
builder.Services.AddScoped<ITaskRepository, EfTaskRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllersWithViews();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
