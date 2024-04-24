using Application;
using Application.Abstractions;
using Carter;
using Infrastructure;
using Infrastructure.Data;
using WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAplication()
    .AddInfrastructure(builder.Configuration)
    .AddCarter(configurator: c => c.WithValidatorLifetime(ServiceLifetime.Scoped))
    .AddValidators()
    .AddMapping();

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//builder.Host.UseSerilog((context, configuration) =>
//  configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.UseHttpsRedirection();
app.MigrateDbContext<MedicalManagementDbContext>();

app.Run();