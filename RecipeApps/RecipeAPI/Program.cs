using RecipeSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.AddJsonFile("secret-appsettings.json", true, true);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string settingval = "";
#if DEBUG
settingval = "Settings:devconn";
#endif

string? connstring = builder.Configuration[settingval];
if (connstring is not null)
{
    DBManager.SetConnString(connstring, true);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
