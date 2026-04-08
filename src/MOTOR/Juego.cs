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
        // Barcos invisibles para CPU
        cpu.ColocarFlotaAleatoria(Flota.CrearFlota());
        var barcosAColocar = Flota.CrearFlota();

        // 2. El usuario coloca sus barcos uno a uno
        foreach (var barco in barcosAColocar)
        {
            bool colocado = false;
            while (!colocado)
            {
                Renderizador.MostrarTablerosBatalla(humano.Tablero, cpu.Tablero);

                Renderizador.MostrarMensaje($"Posicionando {barco.Nombre} ({barco.Size} casillas)");
                Renderizador.MostrarMensaje("Se intentará colocar en Horizontal; si no cabe, en Vertical.");

                
                var (fila, columna) = Renderizador.PedirCoordenadas();

                //Colocamos primero en Horizontal (true)
                if (humano.Tablero.ColocarBarco(barco, fila, columna, true))
                {
                    colocado = true;
                }
                // Si falla, intentamos en Vertical (false)
                else if (humano.Tablero.ColocarBarco(barco, fila, columna, false))
                {
                    colocado = true;
                }
                else
                {
                    Renderizador.MostrarError("El barco no cabe en esa posición (ni H ni V) o hay otro barco.");
                }
            }
        }

        Renderizador.MostrarMensaje("¡Flota desplegada! Presiona una tecla para empezar la batalla...");
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