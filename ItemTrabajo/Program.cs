
using ItemTrabajo.Clients;
using ItemTrabajo.Data;
using ItemTrabajo.Repositories;
using ItemTrabajo.Services;

namespace ItemTrabajo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<DbConnectionFactory>();
            builder.Services.AddScoped<ItemRepository>();
            builder.Services.AddScoped<ItemService>();

            builder.Services.AddHttpClient<UsuarioClient>(client =>
            {
                client.BaseAddress = new Uri(
                    builder.Configuration["Servicios:GestionUsuariosUrl"]!
                );
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
