var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers(); // Enables [ApiController] routing
builder.Services.AddHttpClient(); // Required to call Spotify API
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.UseCors(); // Allow frontend to talk to this API
app.MapControllers(); // Enable controller endpoints

app.Run();
