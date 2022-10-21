using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaCadeteria.Models;
using System.IO;

namespace SistemaCadeteria.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    Cadeteria cadeteria = CadeteriaSingleton.Instance;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;


    }

    public IActionResult Index()
    {
        return View(cadeteria);
    }

    public IActionResult CrearCadete(Cadete cadete)
    {
        while (true)
        {
            if (cadeteria.Cadetes.Exists(c => c.Nombre == cadete.Nombre))
            {
                cadete = new Cadete();
            }
            else
            {
                break;
            }
        }

        int i = 1;
        if (cadeteria.Cadetes.Count > 0)
        {
            foreach (var item in cadeteria.Cadetes)
            {
                i = item.Id + 1;
            }
        }
        cadete.Id = i;

        cadeteria.Cadetes.Add(cadete);
        return RedirectToAction("Index");
    }


    public IActionResult BorrarCadete(int id)
    {
        Cadete cadeteABorrar = cadeteria.Cadetes.Find(cadete => cadete.Id == id);
        cadeteria.Cadetes.Remove(cadeteABorrar);

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View(cadeteria);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
