using Microsoft.EntityFrameworkCore;
using LookMedico.API.ProfilesManagement.Domain.Repositories;
using LookMedico.API.ProfilesManagement.Domain.Services;
using LookMedico.API.ProfilesManagement.Persistence.Repositories;
using LookMedico.API.ProfilesManagement.Services;
using LookMedico.API.Security.Domain.Repositories;
using LookMedico.API.Security.Domain.Services;
using LookMedico.API.Security.Persistence.Repositories;
using LookMedico.API.Security.Services;
using LookMedico.API.Shared.Domain.Repositories;
using LookMedico.API.Shared.Persistence.Contexts;
using LookMedico.API.Shared.Persistence.Repositories;
using LookMedico.API.Store_Inventory_Management.Domain.Repositories;
using LookMedico.API.Store_Inventory_Management.Domain.Services;
using LookMedico.API.Store_Inventory_Management.Interfaces.Internal;
using LookMedico.API.Store_Inventory_Management.Persistence.Repositories;
using LookMedico.API.Store_Inventory_Management.Services;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IStoreInventoryManagementContextFacade, StoreInventoryManagementContextFacade>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(
    typeof(LookMedico.API.ProfilesManagement.Mapping.ModelToResourceProfile),
    typeof(LookMedico.API.ProfilesManagement.Mapping.ResourceToModelProfile));


builder.Services.AddAutoMapper(
    typeof(LookMedico.API.Store_Inventory_Management.Mapping.ModelToResourceProfile),
    typeof(LookMedico.API.Store_Inventory_Management.Mapping.ResourceToModelProfile));

builder.Services.AddAutoMapper(
    typeof(LookMedico.API.Security.Mapping.ModelToResourceProfile),
    typeof(LookMedico.API.Security.Mapping.ResourceToModelProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:5174") // Reemplaza con tu origen permitido
            .AllowAnyHeader()
            .AllowAnyMethod());
});

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
using (AppDbContext context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin");

app.Run();

public partial class Program {}