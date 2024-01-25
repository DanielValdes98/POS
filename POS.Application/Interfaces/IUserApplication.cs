using Azure.Core;
using POS.Application.Commons.Bases;
using POS.Application.DTOs.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> RegisterUser(UserRequestDTO requestDTO);
        Task<BaseResponse<string>> GenerateToken(TokenRequestDTO requestDTO);
    }
}
