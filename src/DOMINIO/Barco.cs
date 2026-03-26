namespace HundirLaFlota.Dominio;

public class Barco
{
    public string Nombre { get; }
    public int Size{ get; }
    public int Impactos { get; private set; } = 0;
    public List<Casilla> Casillas { get; } = new();

    public Barco(string nombre, int size)
    {
        Nombre = nombre;
        Size= size;
    }

    public void RecibirImpacto()
    {
        Impactos++;
    }
    public bool EstaHundido()
    {
        return Impactos >= Size;
    }
}