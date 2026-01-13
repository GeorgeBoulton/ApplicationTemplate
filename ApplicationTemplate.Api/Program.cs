using ApplicationTemplate.Api;
using ApplicationTemplate.Shared.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add logging.
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add some basic injectable config. provided validation for URI.
builder.Services
    .AddOptions<ConfigOptions>()
    .BindConfiguration(ConfigOptions.SectionName)
    .ValidateDataAnnotations()
    .Validate(o =>
            Uri.IsWellFormedUriString(o.UpstreamService.BaseUri, UriKind.Absolute),
        "UpstreamService:BaseUri must be a valid absolute URI")
    .ValidateOnStart();

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
