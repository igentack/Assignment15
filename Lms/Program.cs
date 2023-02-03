using Microsoft.EntityFrameworkCore;
using Lms.Data.Data;
using Lms.Data.AutoMApper;
using Lms.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LmsDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LmsAPIContext") ?? throw new InvalidOperationException("Connection string 'LmsAPIContext' not found.")));

// Add services to the container.
builder.Services.AddControllers(opt => opt.ReturnHttpNotAcceptable = true)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));

var app = builder.Build();

app.SeedDataAsync().GetAwaiter().GetResult();

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
