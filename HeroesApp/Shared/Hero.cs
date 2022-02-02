using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeroesApp.Shared
{
    public class Hero
    {
        public int Id { get; set; } = 0;

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string HeroName { get; set; }

        public Comic? Comic { get; set; }

        [Required]
        public int ComicId { get; set; } = 0;

    }
}
