using OpsBoard.Api.DTOs;
using OpsBoard.Api.Entities;

namespace OpsBoard.Api.Services
{
    public interface IAuthManager
    {
        Task<bool> RegisterAsync(RegisterUserDto dto);
        Task<AuthResponseDto?> LoginAsync(LoginUserDto dto);
    }
}