using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using POS.Application.Commons.Bases;
using POS.Application.DTOs.User.Request;
using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Infrastucture.Persistences.Interfaces;
using POS.Utilities.Static;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatchDog;
using BC = BCrypt.Net.BCrypt;

namespace POS.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserApplication(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<BaseResponse<string>> GenerateToken(TokenRequestDTO requestDTO)
        {
            var response = new BaseResponse<string>();

            try
            {
                // Busca la cuenta (información) por el nombre de usuario
                var account = await _unitOfWork.User.AccountByUserName(requestDTO.Username!);

                if (account is not null)
                {
                    // Verifica si la contraseña es correcta
                    if (BC.Verify(requestDTO.Password, account.Password))
                    {
                        response.IsSuccess = true;
                        response.Data = GenerateToken(account); // Genera el token
                        response.Message = ReplyMessage.MESSAGE_TOKEN;

                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_TOKEN_ERROR;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterUser(UserRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var account = _mapper.Map<User>(requestDTO);

                account.Password = BC.HashPassword(account.Password);

                if (requestDTO.Image is not null)
                {
                    account.Image = await _unitOfWork.Storage.SaveFile(AzureContainers.USERS, requestDTO.Image);
                }

                response.Data = await _unitOfWork.User.RegisterAsync(account);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_SAVE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILDED;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));

            var credentials  = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Email!),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.UserName!),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Email!),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, Guid.NewGuid().ToString()!)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
