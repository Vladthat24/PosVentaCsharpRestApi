using POS.Aplication.Extensions;
using POS.Infraestructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

//Add serviuces to the container
var Cors = "Cors";

builder.Services.AddInjectionIntfraestructure(Configuration);
builder.Services.AddInjectionAplicacion(Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors(Cors);

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public partial class Program { }
