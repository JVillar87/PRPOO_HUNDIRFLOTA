using HundirLaFlota.Datos;
using HundirLaFlota.Dominio;
using HundirLaFlota.Presentacion;
using System;
using System.Collections.Generic;

namespace HundirLaFlota.Motor;

public class Juego
{
    private enum FaseJuego { Colocacion, Batalla, Terminado }
    private readonly Jugador humano;
    private readonly CPU cpu;
    private readonly ConfigJuego configJuego; 
    private FaseJuego fase;

    public Juego(ConfigJuego configuracion)
    {
        this.configJuego = configuracion;
        humano = new Jugador(configuracion.NombreJugador);
        cpu = new CPU();
        fase = FaseJuego.Colocacion;
    }

    public void Iniciar()
    {
        Renderizador.MostrarBienvenida();
        ProcesarColocacion();
        fase = FaseJuego.Batalla;
        BuclePrincipal();
        FinalizarPartida();
    }
    private void ProcesarColocacion()
    {
        //CPU COLOCA FLOTA ALEATORIAMENTE
        cpu.ColocarFlotaAleatoria(Flota.CrearFlota());

        //PREGUNTAMOS A HUMANO SI QUIERE COLOCAR FLOTA ALEATORIAMENTE O MANUALMENTE
        Renderizador.MostrarMensaje("¿Deseas colocar tus barcos aleatoriamente? (S/N): ");
        string respuesta = Console.ReadLine()?.Trim().ToUpper() ?? "N";

        if (respuesta == "S")
        {
            ColocarFlotaHumanaAleatoria();
        }
        else
        {
            ColocarFlotaHumanaManual();
        }

        Renderizador.MostrarMensaje("\n¡Flota lista! Presiona una tecla para empezar la batalla...");
        Console.ReadKey();
    }

    private void ColocarFlotaHumanaManual()
    {
        var barcosAColocar = Flota.CrearFlota();
        foreach (var barco in barcosAColocar)
        {
            bool colocado = false;
            while (!colocado)
            {
                Renderizador.MostrarTablerosBatalla(humano.Tablero, cpu.Tablero);
                Renderizador.MostrarMensaje($"Colocando {barco.Nombre} ({barco.Size} casillas)");

                var (fila, columna) = Renderizador.PedirCoordenadas();

                // Intenta Horizontal, si no, intenta Vertical
                if (humano.Tablero.ColocarBarco(barco, fila, columna, true)) colocado = true;
                else if (humano.Tablero.ColocarBarco(barco, fila, columna, false)) colocado = true;
                else Renderizador.MostrarError("No cabe en ninguna dirección o hay un barco allí.");
            }
        }
        Renderizador.MostrarMensaje("¡Flota lista! Presiona Enter para la batalla...");
        Console.ReadKey();
    }

    private void ColocarFlotaHumanaAleatoria()
    {
        Random rnd = new Random();
        var barcosAColocar = Flota.CrearFlota();

        foreach (var barco in barcosAColocar)
        {
            bool colocado = false;
            while (!colocado)
            {
                int f = rnd.Next(0, 10);
                int c = rnd.Next(0, 10);
                // Elige aleatoriamente entre Horizontal (true) o Vertical (false)
                bool horizontal = rnd.Next(0, 2) == 0;

                if (humano.Tablero.ColocarBarco(barco, f, c, horizontal))
                {
                    colocado = true;
                }
            }
        }
        //FLOTA COLOCADA, MOSTRAMOS TABLEROS PARA QUE VEAN SU POSICIÓN
        Renderizador.MostrarTablerosBatalla(humano.Tablero, cpu.Tablero);
        Renderizador.MostrarMensaje("Tu flota ha sido desplegada por el alto mando.");
    }

    private void BuclePrincipal()
    {
        while (fase == FaseJuego.Batalla)
        {
            Renderizador.MostrarTablerosBatalla(humano.Tablero, cpu.Tablero);

            bool disparoValido = false;
            while (!disparoValido)
            {
                var (f, c) = Renderizador.PedirCoordenadaDisparo();
                var resultado = cpu.Tablero.Disparar(f, c);

                if (resultado != ResultadoDisparo.YaDisparado)
                {
                    humano.RegistrarDisparo(resultado);
                    Renderizador.MostrarResultadoDisparo(resultado, "Humano");
                    disparoValido = true;
                }
            }

            if (cpu.Tablero.TodosHundidos) { fase = FaseJuego.Terminado; break; }

            // TURNO CPU
            Renderizador.MostrarMensaje("CPU pensando...");
            var (fCPU, cCPU) = cpu.ElegirObjetivo();
            var resCpu = humano.Tablero.Disparar(fCPU, cCPU);

            cpu.RegistrarDisparo(resCpu);
            // Asegúrate que Renderizador tenga este método exacto:
            Renderizador.MostrarDisparoCPU(fCPU, cCPU, resCpu);

            if (humano.Tablero.TodosHundidos) fase = FaseJuego.Terminado;
        }
    }

    private void FinalizarPartida()
    {
        bool ganaHumano = cpu.Tablero.TodosHundidos;
        Renderizador.MostrarResultadoFinal(ganaHumano, humano, cpu);

        double puntuacionFinal = humano.Aciertos * 100.0;
    }
}