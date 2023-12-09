using ASC_TEST;
using ASC_TEST.Data;
using ASC_TEST.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=sql-server, 1433;Initial Catalog=asc;User Id=sa;Password=Ep2uU9ytumP1;TrustServerCertificate=True;Encrypt=false;");
});
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<TokenService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
DbManager.MigrationInit(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
