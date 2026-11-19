
using DSWI_T1_0009.Data;
using DSWI_T1_0009.Repositories;
using DSWI_T1_0009.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar la conexión con SQL Server.
builder.Services.AddDbContext<EmpresaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("EmpresaDB")
    ));

// Registrar Repository.
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// Registrar Services.
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

// ==========================================
// PRUEBA TEMPORAL DE REPOSITORY Y SERVICE
// ==========================================

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
        // Obtener todos los clientes.
        var clientes = await clienteService.GetAllAsync();

        Console.WriteLine($"Clientes encontrados: {clientes.Count}");

        // Obtener todos los pedidos.
        var pedidos = await pedidoService.GetAllAsync();

        Console.WriteLine($"Pedidos encontrados: {pedidos.Count}");

        // Buscar cliente por ID.
        var primerCliente = clientes.FirstOrDefault();

        if (primerCliente != null)
        {
            var cliente = await clienteService.GetByIdAsync(
                primerCliente.ClienteId);

            Console.WriteLine(
                $"Búsqueda de cliente por ID: {(cliente != null ? "Correcta" : "No encontrado")}");
        }
        else
        {
            Console.WriteLine("No hay clientes para probar la búsqueda.");
        }

        // Buscar pedido por ID.
        var primerPedido = pedidos.FirstOrDefault();

        if (primerPedido != null)
        {
            var pedido = await pedidoService.GetByIdAsync(
                primerPedido.PedidoId);

            Console.WriteLine(
                $"Búsqueda de pedido por ID: {(pedido != null ? "Correcta" : "No encontrado")}");
        }
        else
        {
            Console.WriteLine("No hay pedidos para probar la búsqueda.");
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
