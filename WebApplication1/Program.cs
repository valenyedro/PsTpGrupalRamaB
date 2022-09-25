using Aplication.Interfaces;
using Aplication.Interfaces.IApprovalStatus;
using Aplication.UseCase;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Querys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketStatusService, TicketStatusService>();
builder.Services.AddScoped<ITicketBodyService, TicketBodyService>();
builder.Services.AddScoped<ITicketCategoryService, TicketCategoryService>();
builder.Services.AddScoped<IApprovalStatusService, ApprovalStatusService>();

builder.Services.AddScoped<ITicketQuery, TicketQuery>();
builder.Services.AddScoped<ITicketStatusQuery, TicketStatusQuery>();
builder.Services.AddScoped<ITicketBodyQuery, TicketBodyQuery>();
builder.Services.AddScoped<ITicketCategoryQuery, TicketCategoryQuery>();
builder.Services.AddScoped<IApprovalStatusQuery, ApprovalStatusQuery>();

builder.Services.AddScoped<ITicketCommand, TicketCommand>();
builder.Services.AddScoped<ITicketStatusCommand, TicketStatusCommand>();
builder.Services.AddScoped<ITicketBodyCommand, TicketBodyCommand>();
builder.Services.AddScoped<ITicketCategoryCommand, TicketCategoryCommand>();
builder.Services.AddScoped<IApprovalStatusCommand, ApprovalStatusCommand>();


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
