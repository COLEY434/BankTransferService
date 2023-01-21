using BankTransferService.Core.Intefaces.Services;
using BankTransferService.Core.Services;
using BankTransferService.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BankTransferServiceContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("BankTranaferServiceContext")));
builder.Services.AddHttpClient();

builder.Services.AddScoped<IFlutterwaveService, FlutterwaveService>();
builder.Services.AddScoped<IBankTransferService, BankTransferServices>();
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
