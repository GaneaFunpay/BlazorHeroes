namespace HeroesApp.Shared
{
    public class Hero
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HeroName { get; set; }
        public Comic? Comic { get; set; }
        public int ComicId { get; set; } = 0;

    }
}
