using LoginForm.BL.Services;
using LoginForm.BL.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
//move to another project

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
