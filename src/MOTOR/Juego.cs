namespace HundirLaFlota.Motor;

using HundirLaFlota.Dominio;
using HundirLaFlota.Presentacion;

public class Juego
{
    private enum FaseJuego { Colocacion, Batalla, Terminado }

    private readonly Jugador humano;
    private readonly CPU cpu;
    private FaseJuego faseActual;

    public Juego(string nombreJugador)
    {
        humano = new Jugador(nombreJugador);
        cpu = new CPU();
        faseActual = FaseJuego.Colocacion;
    }

    public void Iniciar()
    {
        // 1. Fase de Colocación
        ConfigurarPartida();

        // 2. Fase de Batalla
        faseActual = FaseJuego.Batalla;
        BucleBatalla();

        // 3. Fase Final
        FinalizarPartida();
    }

    private void ConfigurarPartida()
    {
        // La CPU coloca siempre automático
        cpu.ColocarFlotaAleatoria();

        // El jugador podría elegir, aquí usamos una colocación simplificada para el ejemplo
        // En una versión completa, aquí llamarías a Renderizador.PedirPosicion() en un bucle
        var barcos = Flota.CrearFlota();
        foreach (var b in barcos)
        {
            // Lógica de ejemplo: coloca barcos en filas consecutivas
            // Deberías implementar la lógica interactiva aquí
            humano.Tablero.ColocarBarco(b, barcos.IndexOf(b), 0, true);
        }
    }

    private void BucleBatalla()
    {
        while (!EsFinDePartida())
        {
            Renderizador.MostrarTableros(humano.Tablero, cpu.Tablero);

            // --- TURNO HUMANO ---
            var (f, c) = Renderizador.PedirCoordenada();
            var resultadoH = cpu.Tablero.Disparar(f, c);
            humano.RegistrarDisparo(resultadoH);

            if (EsFinDePartida()) break;

            // --- TURNO CPU ---
            var coordCpu = cpu.ElegirObjetivo();
            var resultadoC = humano.Tablero.Disparar(coordCpu.f, coordCpu.c);
            cpu.RegistrarDisparo(resultadoC);

            // Pausa breve para que el humano vea qué hizo la CPU
            Thread.Sleep(800);
        }
    }

    private bool EsFinDePartida() => humano.Tablero.TodosHundidos || cpu.Tablero.TodosHundidos;

    private void FinalizarPartida()
    {
        bool ganaHumano = cpu.Tablero.TodosHundidos;
        // Aquí llamarías a Renderizador.MostrarResultadoFinal(ganaHumano, humano);
        Console.Clear();
        Console.WriteLine(ganaHumano ? "¡VICTORIA MAGNÍFICA!" : "HAS SIDO DERROTADO...");
    }
}