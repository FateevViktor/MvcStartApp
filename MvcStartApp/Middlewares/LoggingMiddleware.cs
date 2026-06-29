using Microsoft.AspNetCore.Http;
using MvcStartApp.Models.Db;
using MvcStartApp.Repositories;
using System;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        
        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context, IBlogRepository repo)
        {
            string url = $"http://{context.Request.Host.Value + context.Request.Path}";
            // Добавим создание нового лога
            var newLog = new Request()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = url,
            };
            // Для логирования данных о запросе используем свойста объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to + {url}");

            await  repo.AddLog(newLog);
            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
