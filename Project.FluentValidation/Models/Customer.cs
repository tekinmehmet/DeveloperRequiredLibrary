namespace Project.FluentValidation.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
        public DateTime? BirthDay { get; set; }

        public IList<Adress>? Adresses { get; set; }
        public GenderEnum? Gender { get; set; }
        public CreditCard CreditCard { get; set; }

        public string FerreAnkastre()
        {
            return $"{Name}--{Email}--{Age}";
        }
    }
}
