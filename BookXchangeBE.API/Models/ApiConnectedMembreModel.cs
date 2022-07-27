namespace BookXchangeBE.API.Models
{
    public class ApiConnectedMembreModel
    {
        public int IdMembre { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }
        public string? Localisation { get; set; }
        public string? Image { get; set; }
        public IFormFile? File { get; set; }


    }
}
