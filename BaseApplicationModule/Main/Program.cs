using BaseApplicationModule;
using BaseApplicationModule.Infra;
using BaseApplicationModule.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.RegisterAuthenticationSetup(builder.Configuration);
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddSingleton<ISettings, Settings>();
builder.Services.RegisterServices();
builder.Services.AddAuthorizationPolicies();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthentication();    
app.UseAuthorization();

app.MapControllers();

app.Run();
