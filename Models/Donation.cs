using System.ComponentModel.DataAnnotations;

namespace donations.Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set;} 

        [Required(ErrorMessage = "Este campo é obrigatório")]

        public string Title { get; set; }

        public Donation()
        {
            this.Id = 0;
            this.Title = "";
        }

    }
}