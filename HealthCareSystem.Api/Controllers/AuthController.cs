using Google.Apis.Auth.AspNetCore3;
using HealthCareSystem.Application.Commands.Google;
using HealthCareSystem.Core.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCareSystem.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public AuthController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Auth");
            var properties = new AuthenticationProperties {RedirectUri = redirectUrl };
            return Challenge(properties, GoogleOpenIdConnectDefaults.AuthenticationScheme); 
        }


        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme); // --> Verifica se o usuário está autenticado e recupera os dados no cookie depois do login com o google

            var accessToken = await HttpContext.GetTokenAsync("access_token"); // usado para acessar a API do Google(ex: Google Calendar)
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token"); // Usado para pedir novos tokens quando o access_token expirar
            var expiresAt = await HttpContext.GetTokenAsync("expires_at"); // data/hora de expiração do access token 
            var email = result.Principal?.FindFirst(ClaimTypes.Email)?.Value; // Pega o email do usuário logado no Google, que está dentro das Claims(dados do login)


            var command = new SaveGoogleTokenCommand(email!, accessToken!, refreshToken!, DateTime.Parse(expiresAt!));
            await _mediator.Send(command);

            return Redirect("/");
        }
    }
}

