

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UsePathBase(new PathString("/index.html"));
app.UseAuthorization();

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.UseForwardedHeaders();

WebBackendService.Models.USER.UserManager.LoadUsersList();
WebBackendService.Utilities.LoadPlatformConfig();


app.Run();
