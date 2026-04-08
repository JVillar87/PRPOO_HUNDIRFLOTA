namespace HundirLaFlota.Datos;

public class Marcador
{
    public string NombreJugador { get; set; }
    public int Disparos { get; set; }
    public double Precision { get; set; }
    public double Puntuacion { get; set; }
    public DateTime Fecha { get; set; }

    //Constructor JSON (igual que EstadoPartida)
    public Marcador() { }

    public Marcador(string nombreJugador, int disparos, double precision, double puntuacion, DateTime fecha)
    {
        NombreJugador = nombreJugador;
        Disparos = disparos;
        Precision = precision;
        Puntuacion = puntuacion;
        Fecha = fecha;
    }

    /// <summary>
    /// Calcula la precisión de aciertos total disparos.
    /// </summary>
    /// <param name="aciertos"></param>
    /// <returns></returns>

    public double CalcularPrecision(int aciertos, int disparosTotales)
    {
        return disparosTotales == 0 ? 0 : Math.Round((double)aciertos / disparosTotales * 100, 1);
    }
}