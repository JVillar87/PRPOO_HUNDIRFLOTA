namespace HundirLaFlota.Dominio;

public class Casilla
{
    public int Fila { get; }
    public int Columna { get; }
    public Barco? Barco { get; set; }
    public bool Disparada { get; set; } = false;

    public Casilla(int fila, int columna) { 
        Fila = fila; 
        Columna = columna; 
        }

    public bool EstaVacia()
    {
        return Barco == null;
    }
    public bool EsImpacto()
    {
       return Disparada && Barco != null;
    }
    public bool EsAgua()
    {
        return Disparada && Barco == null;
    }
}