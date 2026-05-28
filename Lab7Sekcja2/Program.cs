
using Contracts;
using Services.Memory;

namespace Lab7Sekcja2
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

            //builder.Services.AddTransient<IPeopleService, PeopleMemoryRepository>();
            builder.Services.AddScoped<IPeopleService, PeopleMemoryRepository>();
            //builder.Services.AddSingleton<IPeopleService, PeopleMemoryRepository>();

            const string CORS_POLICY_NAME = "myCORS";

            builder.Services.AddCors(cors => cors.AddPolicy(CORS_POLICY_NAME, policy => policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(CORS_POLICY_NAME);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
