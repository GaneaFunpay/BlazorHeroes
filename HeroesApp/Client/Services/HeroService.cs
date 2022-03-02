using HeroesApp.Shared;
using System.Net.Http.Json;

namespace HeroesApp.Client.Services
{
    public class HeroService : IHeroService
    {
        private readonly HttpClient _httpClient;

        public HeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Comic> Comics { get; set; } = new List<Comic>();
        public List<Hero> Heroes { get; set; } = new List<Hero>();

        public event Action OnChange;

        public async Task<List<Hero>> CreateHero(Hero hero)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/hero", hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<Hero>>();
            
            return Heroes;
        }

        public async Task<List<Hero>> DeleteHero(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/hero/{id}");
            Heroes = await result.Content.ReadFromJsonAsync<List<Hero>>();
            OnChange.Invoke();
            return Heroes;
        }

        public async Task GetComics()
        {
            Comics = await _httpClient.GetFromJsonAsync<List<Comic>>($"api/hero/comics");
        }

        public async Task<Hero> GetHero(int id)
        {
            return await _httpClient.GetFromJsonAsync<Hero>($"api/hero/{id}");
        }

        public async Task<List<Hero>> GetHeroes()
        {
            Heroes = await _httpClient.GetFromJsonAsync<List<Hero>>("api/hero");
            return Heroes;
        }

        public async Task Register(UserLoginDto user)
        {
            await _httpClient.PostAsJsonAsync($"api/auth/register", user);
        }

        

        public async Task<List<Hero>> UpdateHero(Hero hero, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/hero/{id}", hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<Hero>>();
            //OnChange.Invoke();
            return Heroes;
        }
    }
}
