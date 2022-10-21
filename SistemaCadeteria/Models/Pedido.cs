namespace SistemaCadeteria.Models;

public class Pedido
{
    //numero, obs, cliente, estado
    private int nroPedido;
    private string observaciones;
    private status estado;
    private Cliente costumer;

    public int NroPedido { get => nroPedido; set => nroPedido = value; }
    public string Observaciones { get => observaciones; set => observaciones = value; }
    internal status Estado { get => estado; set => estado = value; }
    public Cliente Costumer { get => costumer; set => costumer = value; }

    public Pedido()
    {
        this.NroPedido = 0;
        this.Observaciones = "";
        this.Estado = (status)1;
        this.Costumer = new Cliente();
    }

    public Pedido(int i, int est, Cliente cos)
    {
        this.NroPedido = i;

        Console.Write("¿Alguna observación acerca del pedido?: ");
        this.Observaciones = Console.ReadLine();

        this.Estado = (status)est;

        this.Costumer = cos;
    }
}

enum status
{
    En_Preparación = 1,
    En_Camino = 2,
    Entregado = 3,
}