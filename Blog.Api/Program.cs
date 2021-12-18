using Blog.Application.Interface;
using Blog.Application.services;
using Blog.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region services
builder.Services.AddDbContext<applicationContext>(options => options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=blogApi;User Id=postgres;Password=229114;"));

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddTransient<IUser, UserSrivices>();
builder.Services.AddTransient<IPost, PostServices>();
builder.Services.AddTransient<IComment, CommentServices>();
builder.Services.AddTransient<IVote, VoteServices>();

#endregion



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
