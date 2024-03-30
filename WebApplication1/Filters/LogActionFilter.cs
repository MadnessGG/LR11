
namespace WebApplication1.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.IO;

    public class LogActionFilter : IActionFilter
    {
        private readonly string _logFilePath;

        public LogActionFilter()
        {
            // Получаем путь к папке Filters внутри директории приложения
            string filtersFolder = Path.Combine(Directory.GetCurrentDirectory(), "Filters");

            // Создаем папку Filters, если она не существует
            if (!Directory.Exists(filtersFolder))
            {
                Directory.CreateDirectory(filtersFolder);
            }

            // Формируем путь к файлу внутри папки Filters
            _logFilePath = Path.Combine(filtersFolder, "log.txt");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Запись информации в лог-файл
            using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
            {
                writer.WriteLine($"Action method {context.ActionDescriptor.DisplayName} started at {DateTime.Now}");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Запись информации в лог-файл
            using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
            {
                writer.WriteLine($"Action method {context.ActionDescriptor.DisplayName} finished at {DateTime.Now}");
            }
        }
    }


}


