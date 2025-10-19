using TransactionAggregationApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services and dependencies
builder.Services.AddControllers();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Optional: Add basic console logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();

// ----------------------------------------------------------
// Middleware pipeline
// ----------------------------------------------------------

// Enable Swagger for all environments
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transaction Aggregation API v1");
});

// Uncomment if HTTPS certificates are configured
// app.UseHttpsRedirection();

app.UseAuthorization();

// Map API controllers
app.MapControllers();

// Run the application
app.Run();
