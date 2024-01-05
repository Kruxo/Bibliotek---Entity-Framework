using Labb_2.Data;
using Labb_2.Services;
using Labb_2.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //Ignore cirkelreferences and stops serialization to JSON 
builder.Services.AddScoped<IBookBorrowerService, BookBorrowerService>();
builder.Services.AddScoped<IBookAuthorService, BookAuthorService>();
builder.Services.AddScoped<IBorrowerService, BorrowerService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddDbContext<LibraryDbContext>(o =>
{
    var connectionString = builder.Configuration.GetConnectionString("AzureDb");
    var connBuilder = new SqlConnectionStringBuilder(connectionString)
    {
        Password = builder.Configuration["ConnectionStrings:AzureDb:Password"],
    };

    connectionString = connBuilder.ConnectionString;

    o.UseSqlServer(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
