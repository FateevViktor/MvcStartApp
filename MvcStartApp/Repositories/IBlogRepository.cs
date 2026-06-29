using MvcStartApp.Models.Db;
using System.Threading.Tasks;

namespace MvcStartApp.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
        Task AddLog(Request request);
        Task<Request[]> GetLogs();
    }
}
