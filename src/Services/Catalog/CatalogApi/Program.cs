using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add service 
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request
app.MapCarter();

app.UseExceptionHandler(options => { });

app.Run();
