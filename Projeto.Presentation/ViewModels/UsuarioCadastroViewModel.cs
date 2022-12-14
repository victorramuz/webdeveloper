using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.ViewModels
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Password { get; set; }
    }
}
