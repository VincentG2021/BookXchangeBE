namespace BookXchangeBE.API.Models
{
    public class ApiEditionModel : ApiLivreModel
    {
        public int IdEdition { get; set; }
        public string Isbn { get; set; }
        public DateTime Parution { get; set; }
        public string Format { get; set; }
        public int IdLivre { get; set; }

    }
}
