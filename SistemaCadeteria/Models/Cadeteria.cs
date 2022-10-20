namespace SistemaCadeteria.Models;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

    public Cadeteria()
    {
        var rand = new Random();
        string archivoCadeterias = "Csv/Cadeterias.csv";        //Archivo que contiene el nombre, y teléfono de cadeterías
        var lectura = File.ReadAllLines(archivoCadeterias);     //Leo el archivo
        int posicion = rand.Next(lectura.Length);       //Obtengo una cadetería aleatoria
        var eleccion = (lectura[posicion]).Split(", ");     //La trato como un arreglo

        this.Nombre = eleccion[0];
        this.Telefono = eleccion[1];
        this.Cadetes = null;
    }

    public Cadeteria(string nombreCadeteria, string tel)
    {
        this.Nombre = nombreCadeteria;
        this.Telefono = tel;
    }
}

public class CadeteriaSingleton
{
    private static Cadeteria cadeteria = new Cadeteria();

    private CadeteriaSingleton() { }

    public static Cadeteria Instance
    {
        get { return cadeteria; }
    }
}