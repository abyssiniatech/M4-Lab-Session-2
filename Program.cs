
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<EnrollmentWorker>();
builder.Services.AddSingleton<EnrollmentWorker>();


builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateScopes = true;
    options.ValidateOnBuild = true;
});

var app = builder.Build();


app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();


