using Database.Contracts;
using Database.CreationDbContext;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ICreateDatabase>(x =>
            new CreateDatabase(
                builder.Configuration.GetConnectionString("SetupConnection"),
                builder.Configuration.GetConnectionString("OrganizationsDatabase")
            ));
builder.Services.AddSingleton<ICreateTables>(x => new CreateTables(builder.Configuration.GetConnectionString("OrganizationsDatabase")));


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
