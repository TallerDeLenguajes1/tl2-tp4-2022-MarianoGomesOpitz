namespace SistemaCadeteria.Models;

public class Persona
{
    private int id;
    private string nombre, direccion, telefono;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    public Persona()
    {
        this.Id = 0;

        var rand = new Random();        //Creo la variable de aleatoriedad a usar en todo el programa
        string archivoNombres = "Csv/Nombres.csv";      //Archivo que contiene nombres, números de teléfonos, y direcciones
        var leer = File.ReadAllLines(archivoNombres);       //Leo el archivo de nombres
        int posicion = rand.Next(leer.Length);     //Obtengo una información aleatoria del archivo
        var eleccion = (leer[posicion]).Split(", ");       //Divido la información para tratarla como un arreglo

        this.Nombre = eleccion[0];
        this.Telefono = eleccion[1];
        this.Direccion = eleccion[2];
    }
}