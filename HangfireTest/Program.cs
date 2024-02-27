using Hangfire;
using HangfireTest.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// HangFire Services
builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("MyConn")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IEmailServices, EmailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Hangfire Dashboard
app.UseHangfireDashboard("/myDashboard");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
