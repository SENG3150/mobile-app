using Inspect.Models;
using System.Threading.Tasks;

namespace Inspect.Data
{
    public interface IRestService
    {
        Task Authenticate(LoginCredentials loginDetails);
    }
}
