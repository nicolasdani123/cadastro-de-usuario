using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserServices(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserReadDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            var ReadDto = _mapper.Map<IEnumerable<UserReadDto>>(users);
            return ReadDto;
        }


        public async Task<UserReadDto> GetByIdAsync(int id)
        {
            if (id <= 0) return null;
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;

            var ReadDto = _mapper.Map<UserReadDto>(user);
            return ReadDto;
        }


        public async Task<UserReadDto> CreateAsync([FromBody] UserCreateDto dto)
        {
            if (dto == null) return null;

            var   userEntity = _mapper.Map<User>(dto);
            await _repository.CreateAsync(userEntity);
            await _repository.SavesChangesAsync();

            var ReadDto = _mapper.Map<UserReadDto>(userEntity);
            return ReadDto;

        }

        public async Task<UserReadDto> UpdateAsync(int id, UserCreateDto dto)
        {
            if (dto == null || id <= 0) return null;

            var userEntity = await _repository.GetByIdAsync(id);
            if (userEntity == null) return null;

            _mapper.Map(dto, userEntity);
              
            _repository.Update(userEntity);
            await _repository.SavesChangesAsync();

             return _mapper.Map<UserReadDto>(userEntity);
        }
    }
}