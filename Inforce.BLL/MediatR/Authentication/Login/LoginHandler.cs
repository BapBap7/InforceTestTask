using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using FluentResults;
using Inforce.BLL.DTO.Authentication.Login;
using Inforce.BLL.DTO.Users;
using Inforce.BLL.Interfaces.Authentication;
using Inforce.DAL.Entities.Users;
using Inforce.DAL.Repositories.Interfaces.Base;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Inforce.BLL.MediatR.Authentication.Login;

 public class LoginHandler : IRequestHandler<LoginQuery, Result<LoginResponseDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public LoginHandler(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService, UserManager<User> userManager)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<Result<LoginResponseDTO>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var userExistsExpression = GetUserExistsPredicate(request);
            var user = (await _repositoryWrapper.UserRepository
                .GetAllAsync())
                .FirstOrDefault(userExistsExpression);
            bool isUserNull = user is null;

            bool isValid = isUserNull ? false : await _userManager.CheckPasswordAsync(user, request.UserLogin.Password);
            if (isValid)
            {
                var token = _tokenService.GenerateJWTToken(user!);
                var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
                var userDTO = _mapper.Map<UserDTO>(user);
                userDTO.Password = request.UserLogin.Password;
                var response = new LoginResponseDTO()
                {
                    User = userDTO,
                    Token = stringToken,
                    ExpireAt = token.ValidTo
                };
                return Result.Ok(response);
            }

            string errorMessage = isUserNull ?
                "User with such Email and Username in not found" :
                "Password is incorrect";
            return Result.Fail(errorMessage);
        }

        private Func<User, bool> GetUserExistsPredicate(LoginQuery request)
        {
            Func<User, bool> userExistsPredicate = user =>
            {
                return user.UserName == request.UserLogin.Login || user.Email == request.UserLogin.Login;
            };
            return userExistsPredicate;
        }
    }