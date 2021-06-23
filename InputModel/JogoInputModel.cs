using System.ComponentModel.DataAnnotations;
using System;

namespace CadastroDeJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do Jogo deve conter entre 3 e 100 caracteres")]  
        public string Nome { get; set; }     

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da Produtora deve conter entre 3 e 100 caracteres")]  
        public string Produtora { get; set; }   

        [Required]
        [Range(1, 1000, ErrorMessage = "O valor do jogo deve ser entre 1 e 1000 reais")]  
        public double Preco { get; set; }   
    }
}