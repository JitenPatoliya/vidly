using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        //public DateTime AddedDate { get; set; }

        [Required]
        [Range(1, 25)]
        public int Stock { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public int GenreId { get; set; }
    }
}