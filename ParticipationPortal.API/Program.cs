using Microsoft.EntityFrameworkCore;
using ParticipationPortal.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<ParticipationPortalContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ParticipationPortal"), serverOptions =>
    {
        serverOptions.MigrationsAssembly
        (typeof(Program).Assembly.FullName);
        serverOptions.CommandTimeout(600);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
