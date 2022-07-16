namespace BookXchangeBE.API.Models
{
    public class ApiExemplaireModel : ApiEditionModel
    {
        public int IdExemplaire { get; set; }
        public int IdMembre { get; set; }
        public int IdEdition { get; set; }

    }
}
