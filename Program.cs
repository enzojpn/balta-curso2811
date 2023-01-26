using Todo2811.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDBContext>();
var app = builder.Build();

app.MapControllers();

// app.MapGet("/", () => "Hello World!");

app.Run();
