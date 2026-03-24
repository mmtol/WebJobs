// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebJobChollometro.Data;
using WebJobChollometro.Repositories;

//Console.WriteLine("Bienvenido a los chollos !!");

string connString = "Data Source=sqlmaria3430.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=adminsql;Password=Admin123;Encrypt=True;Trust Server Certificate=True";

//necesitamos la inyeccion de depdndencias
var provider = new ServiceCollection()
    .AddTransient<RepositoryChollometro>()
    .AddDbContext<ChollometroContext>
    (options => options.UseSqlServer(connString))
    .BuildServiceProvider();

//recuperamos el repo de la inyeccion
RepositoryChollometro repo = provider.GetService<RepositoryChollometro>();

//Console.WriteLine("Pulse Enter para comenzar ...");
//Console.ReadLine();
await repo.PopulateChollosAzureAsync();
//Console.WriteLine("Proceso completado correctamente");
