using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// Контроллер HelloWorld для лабораторной работы №3.
// Демонстрирует маршрутизацию MVC и передачу данных в представление через ViewData.

namespace MvcMovie.Controllers;

public class HelloWorldController : Controller
{
    // Возвращает представление Views/HelloWorld/Index.cshtml.
    public IActionResult Index()
    {
        return View();
    }

    // Принимает параметры из строки запроса и складывает их в ViewData
    // для последующего отображения в Views/HelloWorld/Welcome.cshtml.
    public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
    }
}
