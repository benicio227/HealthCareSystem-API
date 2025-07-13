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
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; // --> Use cookies para manter a sessão do usuário depois que ele fizer login
    options.DefaultAuthenticateScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme; // --> Quero que o usuário entre usando a conta do Google
})
.AddCookie() // --> Ativa o uso de cookies para armazenar a sessão de login do usuário. Depois que o login com o Google é feito, o cookie mantém o usuário autenticado no sistema. Ele armazena quem está logado(por exemplo, o email do google), evita que o usuário tenha que logar toda hora e mantém a identidade do usuário entre requisições.
             // --> Quando o login é bem-sucedido, o ASP.NET Core recebe os claims do Google, como: email, name e sub. Essas informações ficam dentro de User.Claims.
.AddGoogleOpenIdConnect(options => // --> Vou configurar login com o Google
{
    var config = builder.Configuration.GetSection("GoogleOAuth"); // --> Pega as configurações do appsettings
    options.ClientId = config["ClientId"]; // --> Minha credencial do google que identifica minha aplicação
    options.ClientSecret = config["ClientSecret"]; // -- Minha creencial do google que identifica minha aplicação
    options.Scope.Add("openid"); // --> Cada Scope é uma permissão que minha api pede para o Google
    options.Scope.Add("profile");
    options.Scope.Add("email");
    options.Scope.Add("https://www.googleapis.com/auth/calendar");
});



// Início - Esse bloco de código está adicionadno o MediatR e o FluentValidation
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
