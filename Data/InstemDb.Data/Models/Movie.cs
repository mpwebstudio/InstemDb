using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstemDb.Data.Models
{

    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Year { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        public MovieInfo MovieInfo { get; set; }
    }

}