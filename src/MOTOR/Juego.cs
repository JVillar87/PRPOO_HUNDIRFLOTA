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
        //CPU coloca su flota de forma aleatoria
        cpu.ColocarFlotaAleatoria(Flota.CrearFlota());
        var barcosAColocar = Flota.CrearFlota();

            foreach (var barco in barcosAColocar)
            {
                bool colocado = false;
                    while (!colocado)
                    {
                        Renderizador.MostrarTablerosBatalla(humano.Tablero, cpu.Tablero);
                        Renderizador.MostrarMensaje($"Colocando {barco.Nombre} ({barco.Size} casillas)");

                        var (fila, columna) = Renderizador.PedirCoordenadas();

                        // Lógica: Intenta Horizontal(true), si no puede, intenta Vertical(false)
                        if (humano.Tablero.ColocarBarco(barco, fila, columna, true))
                        {
                            colocado = true;
                        }
                        else if (humano.Tablero.ColocarBarco(barco, fila, columna, false))
                        {
                            colocado = true;
                        }
                        else
                        {
                            Renderizador.MostrarError("No cabe en ninguna dirección o hay un barco allí.");
                        }
                    }
                }
                Renderizador.MostrarMensaje("¡Flota lista! Presiona Enter para la batalla...");
                Console.ReadKey();
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