using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        // ссылка на репозиторий
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;

        // Также добавим инициализацию в конструктор
        public LogsController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetLogs();
            var sortedLogs = logs.OrderByDescending(log => log.Date); //Сортируем по дате
            return View(sortedLogs);
        }
    }
}
