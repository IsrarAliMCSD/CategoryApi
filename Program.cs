using Core_CategoryApi.JwtHelper;
using Core_CategoryApi.JWTToken1;
using Core_CategoryApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(); // Make sure you call this previous to AddMvc

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "_myAllowSpecificOrigins",
//                      builder =>
//                      {
//                          builder.WithOrigins("http://localhost:3000",
//                                              "https://localhost:3000")
//                            .AllowAnyHeader() 
//                            .AllowAnyOrigin()
//                            .AllowAnyMethod();
//                      });
//});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      builder =>
                      {
                          //builder.WithOrigins("http://localhost:3000",
                          //                    "https://localhost:3000")
                          //.WithHeaders()
                          //.WithMethods("GET", "POST", "DELETE");
                          ////.AllowAnyHeader()
                          ////.AllowAnyOrigin()
                          ////.AllowAnyMethod();

                          //you can configure your custom policy
                          builder.AllowAnyMethod().AllowAnyOrigin()
                                              .AllowAnyHeader()
                                              .AllowAnyMethod();

                      });


});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes("my_secret_key_12345");
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7194/",
        ValidAudience = "localhost:7194",//"Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});


builder.Services.AddScoped<JWTToken, JWTToken>();
builder.Services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();

builder.Services.AddDbContext<EcomMgmtContext>(options =>
//options.UseSqlServer(_configuration.GetConnectionString("CompanyDB")));
options.UseSqlServer("data source=localhost;Initial Catalog=EComMgmt;Integrated Security=True;"));


builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseCors("_myAllowSpecificOrigins");

app.MapControllers();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseCors();
app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.Run();
