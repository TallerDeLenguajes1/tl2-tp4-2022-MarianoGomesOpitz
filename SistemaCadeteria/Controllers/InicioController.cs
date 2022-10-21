using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaCadeteria.Models;
using System.IO;

namespace SistemaCadeteria.Controllers;

public class InicioController : Controller
{
    private readonly ILogger<InicioController> _logger;

    DBCadeteria cadeteriaDB = CadeteriaSingleton.Instance;

    static int idCadete = 1;

    public InicioController(ILogger<InicioController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(cadeteriaDB);
    }

    public IActionResult CrearCadete()
    {
        Cadete cadete;
        while (true)
        {
                cadete = new Cadete();
            if (!(cadeteriaDB.Cadeteria.Cadetes.Exists(c => c.Nombre == cadete.Nombre)))
            {
                break;
            }
        }

        cadete.Id = idCadete;
        idCadete++;

        cadeteriaDB.Cadeteria.Cadetes.Add(cadete);
        return RedirectToAction("Index");
    }


    public IActionResult BorrarCadete(int id)
    {
        Cadete cadeteABorrar = cadeteriaDB.Cadeteria.Cadetes.Find(cadete => cadete.Id == id);
        cadeteriaDB.Cadeteria.Cadetes.Remove(cadeteABorrar);

        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View(cadeteriaDB);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
