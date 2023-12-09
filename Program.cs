using System.Text;
using ASC_TEST;
using ASC_TEST.Data;
using ASC_TEST.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer("Server=sql-server, 1433;Initial Catalog=asc;User Id=sa;Password=Ep2uU9ytumP1;TrustServerCertificate=True;Encrypt=false;");
});
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<TokenService>();
builder.Services.AddTransient<PasswordService>();

var key = Encoding.ASCII.GetBytes(Configs.SecretTokenHash);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
DbManager.MigrationInit(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
