using Core.Dal.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record Review : BaseEntityDal<Guid>
    {
        [Required]
        public Guid ReviewId { get; init; }
        
        [Required]
        public Guid UserId { get; init; }

        [Required]
        public Movie SelectedMovie { get; init; }

        [Required]
        public DateTime ViewingDate { get; init; }

        [Required]
        [MaxLength(500)]
        public string ReviewText { get; init; }

        [Required]
        [Range(1,5)]
        public int Rating { get; init; }

        [Required]
        public CreatedReviewUserName UserName { get; init; }
    }

    public class CreatedReviewUserName
    {
        [Required]
        public string Name { get; init; }
    }
}
