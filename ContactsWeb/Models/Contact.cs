using System;
using System.ComponentModel.DataAnnotations;

namespace ContactsWeb.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "Data Cadastro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RegistreDate { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} o tamanho dever ter entre {2} e {1} caracteres")]
        public String Name { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(15, MinimumLength = 14, ErrorMessage = "{0} o tamanho dever ter entre {2} e {1} caracteres")]
        public String Phone { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        [EmailAddress(ErrorMessage = "Informe um Email válido")]
        public String Email { get; set; }

        public Address Address { get; set; }
    }
}
