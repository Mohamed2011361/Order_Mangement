using Microsoft.OpenApi.Models;
using Order.Api.Extensions;
using Order.Core.Interfaces;
using Order.Infrastructure;
using Order.Infrastructure.Repository;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    var securitySechema = new OpenApiSecurityScheme
    {
        Name="Authorization",
        Description="Jwt Auth Bearer",
        In=ParameterLocation.Header,
        Type=SecuritySchemeType.Http,
        Scheme="bearer",
        Reference=new OpenApiReference
        {
            Id="Bearer",
            Type=ReferenceType.SecurityScheme,

        }
    };
    s.AddSecurityDefinition("Bearer",securitySechema);
    var sercurityRequirement = new OpenApiSecurityRequirement { { securitySechema, new[] { "Bearer" } } };
    s.AddSecurityRequirement(sercurityRequirement);
});
builder.Services.InfrastructureConfigruration(builder.Configuration);
builder.Services.AddApiRegestration();
//configur Token Service
builder.Services.AddScoped<ItokenServices, tokenServices>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();
//InfrastructuureRegisteration.InfrastructureMiddleWare(app);
app.InfrastructureCongigMiddleWare();
app.Run();
