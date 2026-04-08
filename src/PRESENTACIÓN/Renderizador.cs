using HundirLaFlota.Dominio;
using HundirLaFlota.Motor;

namespace HundirLaFlota.Presentacion;

public static class Renderizador
{
    public static void MostrarBienvenida()
    {
        Console.WriteLine("¡Bienvenido a Hundir la Flota!");
        Console.WriteLine("Coloca tus barcos y prepárate para la batalla.");
        Console.WriteLine("Presiona Enter para comenzar.");
        Console.ReadLine();
    }

    public static void MostrarMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }

    public static void MostrarError(string mensaje)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Error: {mensaje}");
        Console.ResetColor();
    }

    public static void MostrarTablerosBatalla(Tablero propio, Tablero enemigo)
    {
        Console.Clear();
        Console.WriteLine("      TU TABLERO                    MAR ENEMIGO");
        Console.WriteLine("   1 2 3 4 5 6 7 8 9 10        1 2 3 4 5 6 7 8 9 10");

        for (int f = 0; f < 10; f++)
        {
            char letra = (char)('A' + f);
            // Tablero Propio
            Console.Write($"{letra} ");
            for (int c = 0; c < 10; c++)
            {
                var cas = propio.ObtenerCasilla(f, c);
                DibujarCasilla(cas, ocultarBarco: false);
            }

            Console.Write("     ");

            // Tablero Enemigo
            Console.Write($"{letra} ");
            for (int c = 0; c < 10; c++)
            {
                var cas = enemigo.ObtenerCasilla(f, c);
                DibujarCasilla(cas, ocultarBarco: true);
            }
            Console.WriteLine();
        }
    }
    public static void DibujarCasilla(Casilla casilla, bool ocultarBarco)
    {
        if (casilla.Disparada)
        {
            if (casilla.EstaVacia())
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("~ "); // AGUA
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X "); // IMPACTO
            }
        }
        else
        {
            // Si hay barco y no está oculto (tablero propio)
            if (!casilla.EstaVacia() && !ocultarBarco)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("S "); // BARCO PROPIO
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(". "); // VACÍO
            }
        }
        Console.ResetColor();
    }

    public static (int fila, int columna) PedirCoordenadas()
    {
        while (true)
        {
            Console.Write("\nIntroduce posición (Ej: A5): ");
            string input = Console.ReadLine()?.Trim().ToUpper() ?? "";
            if (TryParsePosicion(input, out int f, out int c))
            {
                return (f, c);
            }
            MostrarError("Coordenada no válida. Usa el formato 'A5'.");
        }
    }


    public static (int fila, int columna) PedirCoordenadaDisparo()
    {
        while (true)
        {
            Console.Write("Coordenadas de disparo (Ej: B3): ");
            if (TryParsePosicion(Console.ReadLine()?.Trim().ToUpper(), out int f, out int c)) return (f, c);
            MostrarError("Coordenada no válida.");
        }
    }

    private static bool TryParsePosicion(string input, out int f, out int c)
    {
        f = c = -1;
        if (string.IsNullOrEmpty(input) || input.Length < 2) return false;
        f = input[0] - 'A';
        bool numValido = int.TryParse(input.Substring(1), out int colUser);
        c = colUser - 1;
        return f >= 0 && f < 10 && numValido && c >= 0 && c < 10;
    }

    public static void MostrarResultadoDisparo(ResultadoDisparo resultado, string atacante)
    {
        switch (resultado)
        {
            case ResultadoDisparo.Agua:
                Console.WriteLine("¡Agua!");
                break;
            case ResultadoDisparo.Impacto:
                Console.WriteLine("¡Tocado!");
                break;
            case ResultadoDisparo.Hundido:
                Console.WriteLine("¡Hundido!");
                break;
            case ResultadoDisparo.YaDisparado:
                Console.WriteLine("Intenta de nuevo.");
                break;
        }
    }

    public static void MostrarDisparoCPU(int f, int c, ResultadoDisparo resultado)
    {
        char letra = (char)('A' + f);
        Console.WriteLine($"La CPU dispara a {letra}{c + 1}...");
        MostrarResultadoDisparo(resultado, "La CPU");
    }

    public static void MostrarResultadoFinal(bool jugadorGana, Jugador jugador, CPU cpu)
    {
        Console.WriteLine();
        if (jugadorGana)
            Console.WriteLine($"¡{jugador.Nombre} gana! ¡Felicidades!");
        else
            Console.WriteLine("¡La CPU gana! Mejor suerte la próxima vez.");
    }

}