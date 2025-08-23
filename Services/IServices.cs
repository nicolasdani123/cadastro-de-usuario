using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserReadDto>> GetAllAsync();
        Task<UserReadDto> GetByIdAsync(int id);
        Task<UserReadDto> CreateAsync(UserCreateDto dto);
    }
}