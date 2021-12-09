using Identity.Business.MediatrHandlers.Identity.Commands.ChangePassword;
using Identity.Business.MediatrHandlers.Identity.Commands.ChangePhone;
using Identity.Business.MediatrHandlers.Identity.Commands.Login;
using Identity.Business.MediatrHandlers.Identity.Commands.Logout;
using Identity.Business.MediatrHandlers.Identity.Commands.Register;
using Identity.Business.MediatrHandlers.Identity.Commands.ResetPassword;
using Identity.Business.MediatrHandlers.Identity.Commands.VerifyEmail;
using Identity.Business.MediatrHandlers.Identity.Commands.VerifyPassword;
using Identity.Business.MediatrHandlers.Identity.Commands.VerifyPhone;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Server.Base;
using Shared.Services.Interfaces.DTO.Identity;

namespace Identity.Server.Controllers
{
    public class IdentityController : ApiControllerBase
    {
        public IdentityController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO register)
        {
            return Ok(await Mediator.Send(new RegisterCommand(register)));
        }

        [HttpPut("verifyEmail")]
        public async Task<IActionResult> VerifyEmail(VerificationEmailDTO dto)
        {
            return Ok(await Mediator.Send(new VerifyEmailCommand(dto)));
        }

        [HttpPut]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            return Ok(await Mediator.Send(new LoginCommand(login)));
        }

        [HttpPut("resetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("verifyPassword/{email}")]
        public async Task<IActionResult> VerifyPassword(string email, VerificationPasswordDTO dto)
        {
            return Ok(await Mediator.Send(new VerifyPasswordCommand(dto with { Email = email })));
        }

        [Authorize]
        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            return Ok(await Mediator.Send(new ChangePasswordCommand(dto with { Email = Email })));
        }

        [Authorize]
        [HttpPut("changePhone")]
        public async Task<IActionResult> ChangePhone(ChangePhoneCommand dto)
        {
            return Ok(await Mediator.Send(dto with { Email = Email }));
        }

        [Authorize]
        [HttpPut("verifyPhone/{phone}/{verifyToken}")]
        public async Task<IActionResult> VerifyPhone(string phone, string verifyToken)
        {
            return Ok(await Mediator.Send(new VerifyPhoneCommand(new VerificationPhoneDTO
                { Email = Email, Phone = phone, VerifyToken = verifyToken })));
        }


        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> Logout()
        {
            return Ok(await Mediator.Send(new LogoutCommand(Email)));
        }
    }
}