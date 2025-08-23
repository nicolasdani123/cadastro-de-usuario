using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
	public class UserCreateDto
	{    
		[Required(ErrorMessage = "O campo Name é obrigatório.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Email inválido.")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório.")]
        [MinLength(6, ErrorMessage = "A password deve ter no mínimo 6 caracteres.")]
        public string Password { get; set; }


	}
}
