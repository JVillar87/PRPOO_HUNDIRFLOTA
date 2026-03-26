namespace HundirLaFlota.Presentacion;

using HundirLaFlota.Dominio;

public static class Renderizador
{
    public static void MostrarTableros(Tablero propio, Tablero enemigo)
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

    private static void DibujarCasilla(Casilla c, bool ocultarBarco)
    {
        if (c.EsImpacto()) { Console.ForegroundColor = ConsoleColor.Yellow; Console.Write("X "); }
        else if (c.EsAgua()) { Console.ForegroundColor = ConsoleColor.Blue; Console.Write("~ "); }
        else if (!c.EstaVacia() && !ocultarBarco) { Console.ForegroundColor = ConsoleColor.Green; Console.Write("S "); }
        else { Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(". "); }
        Console.ResetColor();
    }

    public static (int f, int c) PedirCoordenada()
    {
        while (true)
        {
            Console.Write("\nCoordenada (ej. B7): ");
            string input = Console.ReadLine()?.ToUpper() ?? "";
            if (input.Length >= 2 && input[0] >= 'A' && input[0] <= 'J' && int.TryParse(input.Substring(1), out int col) && col >= 1 && col <= 10)
            {
                return (input[0] - 'A', col - 1);
            }
            Console.WriteLine("Coordenada inválida.");
        }
    }
}