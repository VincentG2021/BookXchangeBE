using BookXchangeBE.BLL.Services;
using BookXchangeBE.BLL.Tools;
using BookXchangeBE.DAL.Interfaces;
using BookXchangeBE.DAL.Repositories;
using System.Data.SqlClient;
using Tools.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ToolBox Tools.Connections
builder.Services.AddTransient<Connection>((service) =>
{
    return new Connection(
        SqlClientFactory.Instance,
        builder.Configuration.GetConnectionString("Default")
    );
});

// - DAL
builder.Services.AddTransient<ILivreRepository, LivreRepository>();
builder.Services.AddTransient<IMembreRepository, MembreRepository>();

// - BLL
builder.Services.AddTransient<JwtManager>();
builder.Services.AddTransient<LivreService>();
builder.Services.AddTransient<MembreService>();




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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
