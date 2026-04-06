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

    public void Colocacion()
    {
        var barcos = humano.Tablero.Flota.CrearFlota();

        foreach (var barco in barcos)
        {
            bool colocado = false;

            while (!colocado)
            {
                var (int fila, int columna, bool esHorizontal) = renderizador!.PedirCoordenadasBarco(barco);
                if (humano.Tablero.PuedeColocar(barco, int fila, int columna, bool esHorizontal))
                {
                    humano.Tablero.ColocarBarco(barco, int fila, int columna, bool esHorizontal);
                    colocado = true;
                    renderizador!.MostrarTablero(humano.Tablero, mostrarBarcos: true);
                }
                else
                {
                    renderizador!.MostrarMensaje("No se puede colocar el barco ahí. Intenta de nuevo.");
                }
            }
        }

        Thread.Sleep(1000);
        fase = FaseJuego.Batalla;
    }
}