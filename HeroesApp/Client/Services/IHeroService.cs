using HeroesApp.Shared;

namespace HeroesApp.Client.Services
{
    public interface IHeroService
    {
        event Action OnChange;
        List<Comic> Comics { get; set; }
        List<Hero> Heroes { get; set; }
        Task<List<Hero>> GetHeroes();
        Task GetComics();
        Task<Hero> GetHero(int id);
        Task<List<Hero>> CreateHero(Hero hero);
        Task<List<Hero>> UpdateHero(Hero hero, int id);
        Task<List<Hero>> DeleteHero(int id);
    }
}
