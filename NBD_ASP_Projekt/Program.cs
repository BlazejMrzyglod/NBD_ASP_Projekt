using NBD_ASP_Projekt.Models.Models;
using NBD_ASP_Projekt.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.Configure<MongoDbSet>(builder.Configuration.GetSection("MongoDb"));
//var connectionString = builder.Configuration.GetConnectionString("MongoDb");
//builder.Services.AddDbContext<ComputerContext>();
builder.Services.AddSingleton<ComputerContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
