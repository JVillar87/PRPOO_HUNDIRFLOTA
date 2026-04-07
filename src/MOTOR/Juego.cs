namespace HundirLaFlota.Motor;

using HundirLaFlota.Datos;
using HundirLaFlota.Dominio;
using HundirLaFlota.Presentacion;
using System.Threading;

public class Juego
{
    private enum FaseJuego { Colocacion, Batalla, Terminado }
    private readonly Jugador humano;
    private readonly CPU cpu;
    private Renderizador? renderizador;
    private GestorGuardado? gestorGuardado;
    private FaseJuego fase;

    public Juego()
    {
        humano = new Jugador("Humano");
        cpu = new CPU();
        fase = FaseJuego.Colocacion;
    }

    public void Iniciar()
    {
        Renderizador.Inicializar(humano.Tablero, cpu.Tablero);
        gestorGuardado = new GestorGuardado();
        humano.Tablero.ColocarBarco();
        fase = FaseJuego.Batalla;
        Jugar();
    }

    
}