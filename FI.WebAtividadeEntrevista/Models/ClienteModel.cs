using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Cliente
    /// </summary>
    public class ClienteModel
    {
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        public string CEP { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string Cidade { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        public string Logradouro { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        [Required(ErrorMessage = "O campo Nacionalidade é obrigatório.")]
        public string Nacionalidade { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome
        /// </summary>
        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }

    }    
}