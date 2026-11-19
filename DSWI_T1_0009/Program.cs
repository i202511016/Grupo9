
using DSWI_T1_0009.Data;
using DSWI_T1_0009.Repositories;
using DSWI_T1_0009.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración MVC
builder.Services.AddControllersWithViews();

// Conexión con SQL Server
builder.Services.AddDbContext<EmpresaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmpresaDB")
    ));

// Registro de Repository
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// Registro de Services
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

var app = builder.Build();

// Configuración del entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// PRUEBA DE REPOSITORY Y SERVICE
using (var scope = app.Services.CreateScope())
{
    var clienteService = scope.ServiceProvider
        .GetRequiredService<IClienteService>();

    var pedidoService = scope.ServiceProvider
        .GetRequiredService<IPedidoService>();

    Console.WriteLine();
    Console.WriteLine("===== PRUEBA DE EMPRESADB =====");

    try
    {
        var clientes = await clienteService.GetAllAsync();
        Console.WriteLine($"Clientes encontrados: {clientes.Count}");

        var pedidos = await pedidoService.GetAllAsync();
        Console.WriteLine($"Pedidos encontrados: {pedidos.Count}");

        var primerCliente = clientes.FirstOrDefault();

        if (primerCliente != null)
        {
            var cliente = await clienteService.GetByIdAsync(
                primerCliente.ClienteId);

            Console.WriteLine(
                $"Búsqueda de cliente por ID: {(cliente != null ? "Correcta" : "No encontrado")}");
        }

        var primerPedido = pedidos.FirstOrDefault();

        if (primerPedido != null)
        {
            var pedido = await pedidoService.GetByIdAsync(
                primerPedido.PedidoId);

            Console.WriteLine(
                $"Búsqueda de pedido por ID: {(pedido != null ? "Correcta" : "No encontrado")}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("ERROR EN LA PRUEBA:");
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("===== FIN DE LA PRUEBA =====");
    Console.WriteLine();
}

app.Run();
