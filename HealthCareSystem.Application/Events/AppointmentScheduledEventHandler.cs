using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using HealthCareSystem.Application.DomainEvent;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HealthCareSystem.Application.Events
{
    public class AppointmentScheduledEventHandler : INotificationHandler<AppointmentScheduledEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public AppointmentScheduledEventHandler(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }
        public async Task Handle(AppointmentScheduledEvent notification, CancellationToken cancellationToken)
        {
            var appointment = await _unitOfWork.Appointmens.GetById(notification.AppointmentId); 
            if (appointment is null)
            {
                return;
            }

            var doctor = await _unitOfWork.Doctors.GetById(appointment.DoctorId); 
            if (doctor is null)
            {
                return;
            }

            var token = await _unitOfWork.Tokens.GetByDoctorId(doctor.Id); 
            if (token is null)
            {
                return;
            }


            var patient = await _unitOfWork.Patients.GetByIdAsync(appointment.PatientId); 
            var service = await _unitOfWork.Services.GetById(appointment.ServiceId);

            var googleCredential = GoogleCredential.FromAccessToken(token.AccessToken); 

            var calendarService = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = googleCredential,
                ApplicationName = "HealthCareSystem" 
            });

            var calendarEvent = new Event
            {
                Summary = $"Consulta com {patient.FirstName} {patient.LastName}",
                Description = service?.Description ?? "Consulta médica",
                Start = new EventDateTime
                {
                    DateTime = appointment.StartTime,
                    TimeZone = "America/Sao_Paulo"
                },
                End = new EventDateTime
                {
                    DateTime = appointment.EndTime,
                    TimeZone = "America/Sao_Paulo"
                }
            };

            try
            {
                await calendarService.Events.Insert(calendarEvent, "primary").ExecuteAsync(); // Envia o evento para o calendário principal do médico.
                Console.WriteLine("Evento criado no Google Calendar com sucesso!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro ao criar evento no Google Calendar:");
                Console.WriteLine(ex.Message);
                throw;
            }
           
        }
    }
}

// O que é um Access Token?
// --> O que tem dentro? sub(ID único do usuário), email(e-mail do médico que autorizou), scope(o que seu app tem permissão para accessar), exp(quando o token expira).)
// --> Quando o médico faz login com o Google na sua aplicação, o google DEVOLVE um access_token.
//     Esse token é uma CHAVE TEMPORÁRIA que dá permissão para minha aplicação(API) acessar recursos protegidos
//     da conta do médico, como: O Google Calendar, O E-mail, O perfil.
//     Esse token é salvo no banco com o RefreshToken e a data de expiração

// O que é GoogleCredential.FromAccessToken(...)?
// --> Esse método transforma o Token em uma credencial real
// --> O token.AccessToken é só um código(string)
// --> GoogleCredential é um objeto de atuenticação real que o Google entende e aceita para fazer ações
// --> Pensa assim: A API do Google Calendar NÃO ACEITA UM SIMPLES TOKEN STRING.
// --> Ela exige uma "credencial"(um objeto que implementa a autenticação).

// Analogia fácil de entender
// --> Você tem um ingresso para um show   =======> token.AccessToken (string)
// --> Você apresenta esse ingresso na porta ======> GoogleCredential  (obeto pronto)
// --> Segurança verifica e te libera ========>  Google Calendar deixa você criar evento

// O que new CalendarService faz?
// --> Ela cria um cliente para se comunicar com o Google Calendar usando as permissões do médico logado