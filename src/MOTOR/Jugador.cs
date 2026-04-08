using HundirLaFlota.Dominio;

namespace HundirLaFlota.Motor;

public class Jugador
{
    public string Nombre { get; }
    public Tablero Tablero { get; }
    public int Disparos { get; private set; } = 0;
    public int Aciertos { get; private set; } = 0;
    public int Fallos { get; private set; } = 0;

    public double Precision{
        get
        {
            return Disparos == 0 ? 0 : Math.Round((double)Aciertos / Disparos * 100, 1);
        }
    }

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Tablero = new Tablero();
    }

    /// <summary>
    /// Actualiza las estadísticas del jugador según el resultado.
    /// </summary>
    /// <param name="resultado"></param>

    public void RegistrarDisparo(ResultadoDisparo resultado)
    {
        if (resultado == ResultadoDisparo.YaDisparado) return;
        Disparos++;
        if (resultado == ResultadoDisparo.Impacto || resultado == ResultadoDisparo.Hundido)
            Aciertos++;
        else
            Fallos++;
    }
}