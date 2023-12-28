using BuildingBlock.Presentation.API.Extensions;
using BuildingBlock.Presentation.API.Hosts;
using BuildingBlock.Presentation.API.Middlewares;
using ReviewManagement.Core.Application;
using ReviewManagement.Core.Domain;
using ReviewManagement.Infrastructure.EntityFrameworkCore;
using ReviewManagement.Presentation.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

await builder.Services
    .AddDefaultExtensions<ReviewApplicationAssemblyReference, ReviewDomainAssemblyReference, ReviewDbContext>(
        builder.Configuration);

builder.Services.AddReviewExtensions(builder.Configuration);

builder.Host.UseDefaultHosts(builder.Configuration);

var app = builder.Build();

await app.UseDefaultMiddlewares<ReviewApplicationAssemblyReference>(app.Environment, builder.Configuration);

app.MapControllers();

app.Run();