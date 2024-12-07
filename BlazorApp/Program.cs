using BlazorApp.Components;
using BlazorApp.Database;
using BlazorApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AgroContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConfig")));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor();


builder.Services.AddScoped<EmployeeService>();

builder.Services.AddScoped<TreeService>();

builder.Services.AddScoped(sp => new AgroContext(builder.Configuration.GetConnectionString("PostgreConfig")));

builder.Services.AddControllers().AddNewtonsoftJson();






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
app.UseRouting();
app.UseAntiforgery();
app.MapControllers();   

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
