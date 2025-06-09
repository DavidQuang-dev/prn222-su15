using DrugPrevention.RazorWebApp.QuangTNV.Hubs;
using DrugPrevention.Services.QuangTNV;
using DrugPrevention.Repositories.QuangTNV;
using DrugPrevention.Repositories.QuangTNV.DBContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add repositories
builder.Services.AddScoped<CoursesQuangTnvRepository>();
builder.Services.AddScoped<UserCoursesQuangTnvRepository>();
builder.Services.AddScoped<SystemUserAccountRepository>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IUserCoursesQuangTnvService, UserCoursesQuangTnvService>();
builder.Services.AddScoped<ICoursesQuangTnvService, CoursesQuangTnvService>();
builder.Services.AddScoped<ISystemUserAccountService, SystemUserAccountService>();
builder.Services.AddSignalR();

//// Add CORS
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = "/Account/Forbidden";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages().RequireAuthorization();
app.MapHub<DrugPreventionHubs>("/drugPreventionHub");

app.Run();
