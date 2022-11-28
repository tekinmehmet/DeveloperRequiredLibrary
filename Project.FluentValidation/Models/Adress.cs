namespace Project.FluentValidation.Models
{
    public class Adress
    {
        public int Id { get; set; }
        public string? ContentAdress { get; set; }
        public string? Province { get; set; }
        public string? PostCode { get; set; }

        public virtual Customer? Customer { get; set; }


    }
}
