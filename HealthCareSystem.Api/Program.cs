using FluentValidation;
using FluentValidation.AspNetCore;
using Google.Apis.Auth.AspNetCore3;
using HealthCareSystem.Api.ExceptionsHandler;
using HealthCareSystem.Application.Commands.Patients;
using HealthCareSystem.Application.Validators.PatientValidators;
using HealthCareSystem.Core.Repositories;
using HealthCareSystem.Core.UnitOfWork;
using HealthCareSystem.Infrastructure.Email;
using HealthCareSystem.Infrastructure.Persistence;
using HealthCareSystem.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<HealthCareSystemDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HealthCareSystemCs")));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IDoctorTokenRepository, DoctorTokenRepository>();

builder.Services.AddScoped<ISmsService, SmsService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; // --> Use cookies para manter a sess�o do usu�rio depois que ele fizer login
    options.DefaultAuthenticateScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme; // --> Quero que o usu�rio entre usando a conta do Google
})
.AddCookie() // --> Ativa o uso de cookies para armazenar a sess�o de login do usu�rio. Depois que o login com o Google � feito, o cookie mant�m o usu�rio autenticado no sistema. Ele armazena quem est� logado(por exemplo, o email do google), evita que o usu�rio tenha que logar toda hora e mant�m a identidade do usu�rio entre requisi��es.
             // --> Quando o login � bem-sucedido, o ASP.NET Core recebe os claims do Google, como: email, name e sub. Essas informa��es ficam dentro de User.Claims.
.AddGoogleOpenIdConnect(options => // --> Vou configurar login com o Google
{
    var config = builder.Configuration.GetSection("GoogleOAuth"); // --> Pega as configura��es do appsettings
    options.ClientId = config["ClientId"]; // --> Minha credencial do google que identifica minha aplica��o
    options.ClientSecret = config["ClientSecret"]; // -- Minha creencial do google que identifica minha aplica��o
    options.Scope.Add("openid"); // --> Cada Scope � uma permiss�o que minha api pede para o Google
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.Scope.Add("https://www.googleapis.com/auth/calendar");
});



// In�cio - Esse bloco de c�digo est� adicionadno o MediatR e o FluentValidation
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(InsertPatientCommand).Assembly));

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<InsertPatientValidator>();
// Fim

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ApiExceptionHandler>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
