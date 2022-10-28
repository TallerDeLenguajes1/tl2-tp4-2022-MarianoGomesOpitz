namespace SistemaCadeteria.Models;

public class Cliente : Persona
{
    private string datosReferenciaDireccion;

    public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

    public Cliente() : base()
    {
        this.DatosReferenciaDireccion = "";
    }

    public Cliente(int i, string name, string direcc, string tel, string datosRef)
    {
        this.Id = i;
        this.Nombre = name;
        this.Direccion = direcc;
        this.Telefono = tel;
        this.DatosReferenciaDireccion = datosRef;
    }
}