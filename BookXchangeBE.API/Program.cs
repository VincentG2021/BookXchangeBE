using BookXchangeBE.BLL.Services;
using BookXchangeBE.DAL.Interfaces;
using BookXchangeBE.DAL.Repositories;
using System.Data.SqlClient;
using Tools.Connections;

var BookXchangeAPICorsPolicy = "_BookXchangeAPICorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: BookXchangeAPICorsPolicy,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7132") // voir BlazorApp (launchSettings.json)

                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(LivreService));

// ToolBox Tools.Connections
builder.Services.AddTransient<Connection>((service) =>
{
    return new Connection(
        SqlClientFactory.Instance,
        builder.Configuration.GetConnectionString("Home")
    );
});

// - DAL
builder.Services.AddTransient<ILivreRepository, LivreRepository>();
builder.Services.AddTransient<IMembreRepository, MembreRepository>();
// - BLL
builder.Services.AddTransient<LivreService>();
builder.Services.AddTransient<MembreService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(BookXchangeAPICorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();

