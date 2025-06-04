var builder = WebApplication.CreateBuilder(args);

// Add service 
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request
app.MapCarter();

app.Run();
