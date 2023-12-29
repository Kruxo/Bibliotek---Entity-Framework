using Labb_2.Data;
using Labb_2.Services;
using Labb_2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IBookBorrowerService, BookBorrowerService>();
builder.Services.AddScoped<IBookAuthorService, BookAuthorService>();
builder.Services.AddScoped<IBorrowerService, BorrowerService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddDbContext<LibraryDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("Bibliotek")));

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
