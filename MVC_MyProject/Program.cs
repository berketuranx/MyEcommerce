using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyEcommerce.DAL.Context;
using MyEcommerce.Entity.Entity;
using MyEcommerce.BLL;
using MyEcommerce.BLL.Abstract;
using MyEcommerce.BLL.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyEcommerceContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBconnection")));


//Token iþlemi tanýmlandýðýnda user kayýt iþlemi yaptýðýmýzda mail geliyordu ama uygulama çalýþýrken hata veriyordu home pageye gidemiyorduk. AddDefaultTokenProviders() tanýmlayarak bu sorun çözüldü.
builder.Services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<MyEcommerceContext>();

//cookie
builder.Services.ConfigureApplicationCookie(x =>
{

    x.LoginPath = new PathString("/User/Login");
    x.Cookie = new CookieBuilder()
    {
        Name = "BerkeCookie"
    };
    x.SlidingExpiration = true;
    x.ExpireTimeSpan = TimeSpan.FromSeconds(20);
});



builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

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

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

});






app.Run();
