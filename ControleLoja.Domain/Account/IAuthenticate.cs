using System.Threading.Tasks;

namespace ControleLoja.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string Senha);

        Task<bool> RegisterUser(string email, string Senha);

        Task Logout();

    }
}
