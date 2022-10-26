using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ParticipationPortal.API.Extensions;
using ParticipationPortal.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddUserSecrets<Program>();
// Add services to the container.

FirebaseAdmin.FirebaseApp.Create(new FirebaseAdmin.AppOptions()
{
    Credential = GoogleCredential.FromFile(builder.Configuration.GetSection("Firebase:SDK:Path").Value)
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContextPool<ParticipationPortalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ParticipationPortal"), serverOptions =>
    {
        serverOptions.MigrationsAssembly
        (typeof(Program).Assembly.FullName);
        serverOptions.CommandTimeout(600);
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://securetoken.google.com/{builder.Configuration.GetSection("Firebase:AuthSeries").Value}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"https://securetoken.google.com/{builder.Configuration.GetSection("Firebase:AuthSeries").Value}",
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetSection("Firebase:AuthSeries").Value,
            ValidateLifetime = true
        };
    });

//services
builder.Services
    .AddTransient<ParticipationPortal.Domain.Services.v1.IUserService, ParticipationPortal.Services.Application.v1.UserService>()
    .AddTransient<ParticipationPortal.Domain.Services.v1.IRoleService, ParticipationPortal.Services.Application.v1.RoleService>()
    .AddTransient<ParticipationPortal.Domain.Services.v1.IIncomingEventService, ParticipationPortal.Services.Application.v1.IncomingEventService>()
    ;

//repositories
builder.Services
    .AddTransient<ParticipationPortal.Domain.Repositories.v1.IUserRepository, ParticipationPortal.Infrastructure.Repositories.v1.UserRepository>()
    .AddTransient<ParticipationPortal.Domain.Repositories.v1.IRoleRepository, ParticipationPortal.Infrastructure.Repositories.v1.RoleRepository>()
    .AddTransient<ParticipationPortal.Domain.Repositories.v1.IIncomingEventRepository, ParticipationPortal.Infrastructure.Repositories.v1.IncomingEventRepository>()
    .AddTransient<ParticipationPortal.Domain.Repositories.v1.IWeeklyEventRepository, ParticipationPortal.Infrastructure.Repositories.v1.WeeklyEventRepository>()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
