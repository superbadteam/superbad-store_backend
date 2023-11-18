using BuildingBlock.Presentation.API.Extensions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddOcelot();
builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddApplicationCors(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseCors(builder.Configuration.GetRequiredValue("CORS"));
app.UseSwaggerForOcelotUI().UseOcelot();
app.Run();