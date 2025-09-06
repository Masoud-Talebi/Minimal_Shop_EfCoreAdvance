using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Minimal_Shop.Domain.Entities.Identity;
using Minimal_Shop.FrameWork.Tools;
using Minimal_Shop.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
{
    //User Option
    option.User.RequireUniqueEmail = true;
    //SignIn Option
    option.SignIn.RequireConfirmedEmail = false;
    //Password Option
    option.Password.RequireUppercase = false;
    option.Password.RequireNonAlphanumeric = false;
    //Lockout Option
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);

}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddErrorDescriber<PersianIdentityErrors>();
builder.Services.ConfigureApplicationCookie(option =>
{
    option.AccessDeniedPath = "/Home/AccessDenied";
    option.LoginPath = "/Account/Login";
    option.LogoutPath = "/Account/LogOut";
    option.Cookie.HttpOnly = true;
    option.ExpireTimeSpan = TimeSpan.FromDays(3);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
