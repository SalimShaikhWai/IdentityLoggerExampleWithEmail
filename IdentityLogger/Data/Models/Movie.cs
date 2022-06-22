using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityLogger.Data.Models
{
    [Table(nameof(Movie),Schema ="movie")]
    public class Movie
    {
       [Key]
       public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public DateTime? ReleaseDate { get; set; }

        public int? Buget { get; set; }



    }
}
