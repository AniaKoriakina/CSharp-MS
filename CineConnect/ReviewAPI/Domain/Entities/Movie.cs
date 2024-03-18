using Core.Dal.Base;
using Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record Movie : BaseEntityDal<Guid>
    {
        [Required]
        public Guid MovieId { get; init; }

        [Required]
        public Guid GenreId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        //[Required]
        //[ValidImageUrl]
        //public string CoverImageUrl { get; init; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }
    }
}
