using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication4.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ������ ������� ��� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ��������� middleware ��� ��������� �������
app.UseMiddleware<ErrorLoggingMiddleware>();

// ������������ ������� ������
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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

