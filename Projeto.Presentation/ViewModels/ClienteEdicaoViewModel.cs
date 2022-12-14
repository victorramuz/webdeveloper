using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Presentation.ViewModels
{
    public class ClienteEdicaoViewModel
    {
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public int IdCliente { get; set; }

        [MinLength(3, ErrorMessage = "{0} deve conter no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "{0} deve conter no máximo {1} caracteres.")]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "{0} deve ser um endereço de email válido.")]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Email { get; set; }
    }
}
