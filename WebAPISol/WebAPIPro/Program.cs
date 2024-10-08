using Microsoft.EntityFrameworkCore;
using WebAPIPro.DataAccess.IRepositories;
using WebAPIPro.DataAccess.Repositories;
using WebAPIPro.DBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer("server=ARUN\\SQLEXPRESS;Uid=sa;password=143;database=ProjectDB;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true"));
builder.Services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConStrLocal")));
//builder.Services.AddTransient<IDeptRepository, DeptRepository>();
//builder.Services.AddScoped<IDeptRepository, DeptRepository>();
//builder.Services.AddSingleton<IDeptRepository, DeptRepository>();
builder.Services.AddTransient<IDeptRepository, DeptRepository>();
builder.Services.AddTransient<IEmpRepository, EmpRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
