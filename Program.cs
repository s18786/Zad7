using Zad7.Endpoints;
using Zad7.Services;
using Zad7.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbServiceDapper, DbServiceDapper>();

builder.Services.AddValidatorsFromAssemblyContaining<ProductWarehouseValidator>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.RegisterProductWarehouseEndpoints();
app.Run();
