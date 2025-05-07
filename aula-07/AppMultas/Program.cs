using AppMultas.Components;
using AppMultas.Services;
using AppMultas.Contexto; // Certifique-se de importar seu namespace de contexto
using Microsoft.EntityFrameworkCore; // Para usar UseMySql ou UseSqlServer, etc.




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<VeiculoController>();
builder.Services.AddScoped<MultaController>();

string mySqlConexao = builder.Configuration.GetConnectionString("BaseConexaoMySQL");

builder.Services.AddDbContext<ContextoBD>(options =>
    options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
