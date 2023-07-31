using marcaconsulta_web_dotnet_infra;
using marcaconsulta_web_dotnet_service;
using marcaconsulta_web_dotnet_service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MarcaConsultaDbContext>();

builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IProfissionalAgendaService, ProfissionalAgendaService>();
builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
builder.Services.AddScoped<IEspecialidadeService, EspecialidadeService>();

//builder.Services.AddScoped<ICidadeService, CidadeService>();
//builder.Services.AddScoped<IUfService, UfService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
