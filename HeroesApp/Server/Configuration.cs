using IdentityServer4.Models;
using IdentityModel;

namespace HeroesApp.Server
{
    public class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("HeroesWebApi", "WebApi")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("HeroesWebApi", "WebApi", new [] 
                    {JwtClaimTypes.Name})
                {
                    Scopes = {"HeroesWebApi"}
                }
            };

       /* public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId ="heroes-web-api",
                    ClientName = "Heroes Web",
                    AllowedGrantTypes = ""
                }
            };*/
    }
}
