using HundirLaFlota.Dominio;
using HundirLaFlota.Motor;
namespace HundirLaFlota.Datos;

public class Marcador
{
    public string NombreJugador { get; set; }
    public int Disparos { get; set; }
    public double Precision { get; set; }
    public double Puntuacion { get; set; }
    public DateTime Fecha { get; set; }

    public Marcador(string nombreJugador, int disparos, double precision, double puntuacion, DateTime fecha)
    {
        NombreJugador = nombreJugador;
        Disparos = disparos;
        Precision = precision;
        Puntuacion = puntuacion;
        Fecha = fecha;
    }

    public double CalcularPrecision(int aciertos)
    {
        return Disparos == 0 ? 0 : Math.Round((double)aciertos / Disparos * 100, 1);
    }
}