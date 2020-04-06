using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InstemDb.Data.Models
{

    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public ICollection<MovieInfoDirector> MovieInfoDirectors { get; set; }
    }

}