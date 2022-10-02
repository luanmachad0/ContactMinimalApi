using ContactMinimalApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.AddDependencies();
builder.AddPersistence();

var app = builder.Build();

app.MapGet("/", () => "It's alive!").WithName("Ping");

app.MapPeopleEndpoints();
app.MapContactEndpoints();

var environment = app.Environment;
app
    .UseExceptionHandling(environment)
    .UseSwaggerEndpoints()
    .UseAppCors();

app.Run();
