using MeusContatos.Api.Agenda;
using MeusContatos.Api.Data;

namespace MeusContatos.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<AppDbContext>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin()
                                                          .AllowAnyMethod()
                                                          .AllowAnyHeader());
        });

        var app = builder.Build();
        app.UseCors("AllowAll");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.AddContatos();

        app.Run();
    }
}