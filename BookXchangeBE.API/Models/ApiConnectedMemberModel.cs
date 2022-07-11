namespace BookXchangeBE.API.Models
{
    public class ApiConnectedMemberModel
    {
        public int IdMembre { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string? Prenom { get; set; }
        public string? Nom { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }

    }
}
