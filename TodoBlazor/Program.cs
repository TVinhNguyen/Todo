using TodoBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TodoBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ HTTP client
builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("http://localhost:5289") });

// Đăng ký dịch vụ TodoService
builder.Services.AddScoped<TodoService>();

// Đăng ký Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Đăng ký Razor Pages và Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Đăng ký Antiforgery
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN"; // Tùy chỉnh tên header nếu cần
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Thêm middleware Antiforgery (phải đăng ký dịch vụ trước)
app.UseAntiforgery();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Nếu sử dụng API Controllers
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
