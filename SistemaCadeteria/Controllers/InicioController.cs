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

    public IActionResult Crear()
    {
        return View(cadeteriaDB);
    }

    [HttpPost]
    public IActionResult CrearCadete(string name, string adress, string phone)
    {
        cadeteriaDB.Cadeteria.Cadetes.Add(new Cadete(idCadete, name, adress, phone));
        idCadete++;

        return RedirectToAction("Index");
    }

    public IActionResult Editar(int id)
    {
        return View(cadeteriaDB.Cadeteria.Cadetes.Find(x => x.Id == id));
    }

    [HttpPost]
    public IActionResult EditarCadete(int id, string name, string adress, string phone)
    {
        Cadete cadeteEditar = cadeteriaDB.Cadeteria.Cadetes.Find(c => c.Id == id);
        cadeteEditar.Nombre = name;
        cadeteEditar.Direccion = adress;
        cadeteEditar.Telefono = phone;

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
