using System.ComponentModel.DataAnnotations;

namespace RodoNavesTest.Models.ViewModels
{
    public class AtualizarUsuarioViewModel
    {
        public string Senha { get; set; } = string.Empty;
        [Required]
        public bool Status { get; set; }
    }
}
