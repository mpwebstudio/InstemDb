using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstemDb.Data.Models
{

    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(256)]
        public string GenreType { get; set; }

        public ICollection<MovieInfoGenre> MovieInfoGenres { get; set; }
    }

}