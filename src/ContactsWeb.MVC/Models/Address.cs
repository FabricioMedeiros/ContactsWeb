using System.ComponentModel.DataAnnotations;

namespace ContactsWeb.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int ContactId { get; set; }       

        [Display(Name ="Endereço")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} o tamanho dever ter entre {2} e {1} caracteres")]
        public string Street { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "{0} o tamanho dever ter entre {2} e {1} caracteres")]
        public string Number { get; set; }

        [Display(Name = "Complemento")]
        public string Complement { get; set; }      

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "{0} o tamanho dever ter entre {2} e {1} caracteres")]
        public string Neighborhood { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "{0} o tamanho dever ter entre {2} e {1} caracteres")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} o tamanho dever ter entre {2} e {1} caracteres")]
        public string State { get; set; }

        [Display(Name = "Cep")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "{0} precisa ter {1} caracteres")]
        public string ZipCode { get; set; }

        public Contact Contact { get; set; }
    }
}
