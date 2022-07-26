using BookXchangeBE.BLL.Services;
using BookXchangeBE.BLL.Tools;
using BookXchangeBE.DAL.Interfaces;
using BookXchangeBE.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data.SqlClient;
using System.Text;
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


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("isConnected", policy => policy.RequireAuthenticatedUser());
});

//Vérification de la validité du token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtToken").GetSection("secret").ToString())),
            ValidateIssuer = false,
            ValidIssuer = builder.Configuration.GetSection("JwtToken").GetSection("issuer").Value,
            ValidateAudience = false,
            ValidAudience = builder.Configuration.GetSection("JwtToken").GetSection("audience").Value
        };
    });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BookXchangeAPI",
        Version = "v1",
        Description = "Interface de Programmation d'Application pour échanges de livres",
        License = new OpenApiLicense
        {
            Name = "ISC",
            Url = new Uri("https://fr.wikipedia.org/wiki/Licence_ISC")
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Veuillez copier coller votre JWT ici précédé de \"Bearer\".",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});


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
builder.Services.AddTransient<IEditionRepository, EditionRepository>();
builder.Services.AddTransient<IExemplaireRepository, ExemplaireRepository>();
// - BLL
builder.Services.AddScoped<JwtManager>();
builder.Services.AddScoped(typeof(LivreService));
builder.Services.AddScoped<MembreService>();
builder.Services.AddScoped<EditionService>();
builder.Services.AddScoped<ExemplaireService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookXchangeAPI"));
}

app.UseHttpsRedirection();

app.UseCors(BookXchangeAPICorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

