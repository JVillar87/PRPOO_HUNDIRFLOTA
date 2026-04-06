namespace HundirLaFlota.Presentacion;

using HundirLaFlota.Dominio;
using HundirLaFlota.Motor;

public static class Renderizador
{
    public static void MostrarBienvenida()
    {
        Console.WriteLine("¡Bienvenido a Hundir la Flota!");
        Console.WriteLine("Coloca tus barcos y prepárate para la batalla.");
        Console.WriteLine("Presiona Enter para comenzar.");
        Console.ReadLine();
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

    public static void MostrarTableroColocacion(Tablero tablero)
    {
        Console.Clear();
        Console.WriteLine("      COLOCA TUS BARCOS");
        Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");

        for (int f = 0; f < 10; f++)
        {
            char letra = (char)('A' + f);
            Console.Write($"{letra} ");
            for (int c = 0; c < 10; c++)
            {
                var cas = tablero.ObtenerCasilla(f, c);
                DibujarCasilla(cas, ocultarBarco: false);
            }
            Console.WriteLine();
        }
    }

    public static void DibujarCasilla(Casilla casilla, bool ocultarBarco)
    {
        if (casilla.Disparada)
        {
            if (casilla.EstaVacia())
                Console.Write("~ ");
            else
                Console.Write("X ");
        }
        else
        {
            if (!casilla.EstaVacia() && !ocultarBarco)
                Console.Write("O ");
            else
                Console.Write(". ");
        }
    }

    public static void PedirCoordenadas(out int fila, out int columna)
    {
        while (true)
        {
            Console.Write("Introduce coordenadas (Ej: A5): ");
            string input = Console.ReadLine()?.Trim().ToUpper() ?? "";
            if (input.Length >= 2 &&
                char.IsLetter(input[0]) &&
                int.TryParse(input.Substring(1), out int col) &&
                col >= 1 && col <= 10)
            {
                fila = input[0] - 'A';
                columna = col - 1;
                return;
            }
            Console.WriteLine("Entrada inválida. Intenta de nuevo.");
        }
    }

    public static void PedirPosicionBarco(Barco barco, out int fila, out int columna, out bool esHorizontal)
    {
        while (true)
        {
            Console.Write($"Coloca tu {barco.Nombre} (tamaño {barco.Size}). Ej: A5 H: ");
            string input = Console.ReadLine()?.Trim().ToUpper() ?? "";
            if (input.Length >= 3 &&
                char.IsLetter(input[0]) &&
                int.TryParse(input.Substring(1, input.Length - 2), out int col) &&
                col >= 1 && col <= 10 &&
                (input.EndsWith("H") || input.EndsWith("V")))
            {
                fila = input[0] - 'A';
                columna = col - 1;
                esHorizontal = input.EndsWith("H");
                return;
            }
            Console.WriteLine("Entrada inválida. Intenta de nuevo.");
        }
    }

    public static void MostrarResultadoDisparo(ResultadoDisparo resultado)
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

    public static void MostrarDisparoCPU((int f, int c) objetivo, ResultadoDisparo resultado)
    {
        char letra = (char)('A' + objetivo.f);
        Console.WriteLine($"La CPU dispara a {letra}{objetivo.c + 1}...");
        MostrarResultadoDisparo(resultado);
    }

    public static void MostrarResultadoFinal(Jugador jugador, CPU cpu)
    {
        Console.WriteLine();
        if (jugador.Tablero.BarcosRestantes == 0)
            Console.WriteLine("¡La CPU gana! Mejor suerte la próxima vez.");
        else
            Console.WriteLine($"¡{jugador.Nombre} gana! ¡Felicidades!");
    }

    public static void MostrarError(string mensaje)
    {
        Console.WriteLine($"Error: {mensaje}");
    }
}