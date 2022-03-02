using HeroesApp.Shared;

namespace HeroesApp.Client.Services
{
    public interface IAuthService
    {
        List<User> Users { get; set; }
    }
}
