using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookXchangeBE.API.Models
{
    public class ApiMembreLogin
    {
        [DisplayName("Pseudo")]
        [Required]
        public string Pseudo { get; set; }

        [DisplayName("Mot de passe")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

}
