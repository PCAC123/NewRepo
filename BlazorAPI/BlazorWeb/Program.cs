using BlazorWeb.Components;
using BlazorWeb.Components.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("BlazorAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7149/");
    //client.Timeout = TimeSpan.FromSeconds(5); //
});
builder.Services.AddScoped<CartService>();
//Service Blazorwweb
builder.Services.AddScoped<CarsService>();
builder.Services.AddScoped<CarStylesService>();
builder.Services.AddScoped<CarModelsService>();
builder.Services.AddScoped<PaymentsService>();
builder.Services.AddScoped<PromotionService>();
builder.Services.AddScoped<UsersService>();
builder.Services.AddScoped<OrdersService>();
builder.Services.AddScoped<OrderDetailsService>();
builder.Services.AddScoped<ViewsHistoryService>();
//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorAPI"));
//builder.Services.AddBlazoredLocalStorage();

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

//app.MapBlazorHub();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
