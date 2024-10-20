using BuildingBlocks.Behaviors;
using FluentValidation;
using Marten;
using Marten.Linq.CreatedAt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    //opts.AutoCreateSchemaObjects.CreatedBefore();
}).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();

app.Run();
