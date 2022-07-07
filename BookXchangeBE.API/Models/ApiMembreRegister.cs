using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookXchangeBE.API.Models
{
    public class ApiMembreRegister
    {
        [DisplayName("Pseudo")]
        [Required]
        public string Pseudo { get; set; }

        [DisplayName("E-Mail")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Mot de passe")]
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")]
        // Regle de la regex => Le mot de passe doit faire 8 caracteres, une miniscule, une majuscule et un chiffre
        public string Password { get; set; }

        [DisplayName("Confirmation")]
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string PasswordConfirm { get; set; }

        [DisplayName("Role")]
        public int Role { get; set; }

    }
}
