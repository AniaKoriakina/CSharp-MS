using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public record Filter
    {
        public Guid MovieId { get; init; }

        public Guid GenreId { get; init; }

        public string Title { get; init; }
        public int ReleaseYear { get; init; }

        public double MinRating { get; init; }
        public double MaxRating { get; init; }
        public int MinReleaseYear { get; init; }
        public int MaxReleaseYear { get; init; }
    }
}
