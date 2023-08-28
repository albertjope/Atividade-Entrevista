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
    public class BeneficiarioModel
    {
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }

        /// <summary>
        /// Id do Cliente
        /// </summary>
        public long IdCliente { get; set; }
    }    
}