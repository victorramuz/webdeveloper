using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Por favor, informe seu nome de usuário.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Por favor, informe sua senha de usuário.")]
        public string Password { get; set; }
    }
}
