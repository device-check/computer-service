using dependency_injection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplicationLayerDependencies();

builder.Services.AddInfrastructureLayerDependencies(builder.Configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.AddApiVersioningConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
