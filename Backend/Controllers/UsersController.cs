using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _service;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserServices service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Consultado e listados todos os usuários!");
                var usersGetAll = await _service.GetAllAsync();
                return Ok(usersGetAll);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar usuários no método GetAllAsync()");
                return StatusCode(500, "Erro no servidor!");
            }
        }

        [HttpGet("{id}", Name = "RouteGetById")]
        public async Task<ActionResult<UserReadDto>> GetByIdAsync(int id)
        {
            try
            {
                var user = await _service.GetByIdAsync(id);
                if (user == null) return NotFound("Usuário não encontrado!");

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Erro ao buscar usuário {id} no método GetByIdAsync()");
                return StatusCode(500, "Erro no servidor!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateUser([FromBody] UserCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var user = await _service.CreateAsync(dto);
                if (user == null) return BadRequest("Dados inválidos!");

                return CreatedAtRoute("RouteGetById", new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar usuário do metodo CreateAsync()");
                return StatusCode(500, "Erro no servidor!");
            }
        }
    }
}
