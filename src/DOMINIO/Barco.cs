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
    /// <summary>
    /// Incrementa el contador de impactos. 
    /// </summary>
    public void RecibirImpacto()
    {
        Impactos++;
    }
    public bool EstaHundido()
    {
        return Impactos >= Size;
    }

    public double Salud()
    {
        return Size == 0 ? 0 : Math.Round((double)(Size - Impactos) / Size * 100, 1);
    }
}