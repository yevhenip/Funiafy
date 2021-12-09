using AutoMapper;
using Identity.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Shared.Services.Interfaces.DTO.Identity;
using Shared.Services.Interfaces.Jwt;

namespace Identity.Business.MediatrHandlers.Identity.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticatedUserDTO>
    {
        private const string ErrorMessage = "Invalid credentials";
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public LoginCommandHandler(SignInManager<User> signInManager, UserManager<User> userManager,
            IJwtService jwtService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<AuthenticatedUserDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Login.EmailOrUsername);
            if (user is null)
            {
                user = await _userManager.FindByNameAsync(request.Login.EmailOrUsername);
                if (user is null) throw new ApplicationException(ErrorMessage);
            }

            var result =
                await _signInManager.PasswordSignInAsync(user, request.Login.Password, request.Login.RememberMe, false);
            if (!result.Succeeded) throw new ApplicationException(ErrorMessage);

            await _userManager.UpdateAsync(user);

            var loginUser = _mapper.Map<UserDTO>(user);

            var token = await _jwtService.GenerateJwtToken(loginUser, await _userManager.GetRolesAsync(user));

            return new AuthenticatedUserDTO(loginUser, token);
        }
    }
}