using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCE.Domain.Dtos.Login
{
    public class DtoLogin
    {
        [Required(ErrorMessage = "Email é obrigatorio para login.")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caractere.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatorio para login.")]
        [StringLength(8, ErrorMessage = "Email deve ter no máximo {1} caractere.")]
        public string Senha { get; set; }
    }
}
