namespace HundirLaFlota.Motor;
using HundirLaFlota.Dominio;

public class Jugador
{
    public string Nombre { get; }
    public Tablero Tablero { get; }
    public int Disparos { get; private set; } = 0;
    public int Aciertos { get; private set; } = 0;
    public int Fallos { get; private set; } = 0;

    public double Precision => Disparos == 0 ? 0 : Math.Round((double)Aciertos / Disparos * 100, 1);

    public Jugador(string nombre)
    {
        Nombre = nombre;
        Tablero = new Tablero();
    }

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