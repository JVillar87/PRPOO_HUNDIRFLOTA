using HundirLaFlota.Motor;
using HundirLaFlota.Dominio;
using HundirLaFlota.Datos;
using HundirLaFlota;

namespace HundirLaFlota;

class Program
{
    static void Main(string[] args)
    {
        Tablero propio = new Tablero();
        Tablero enemigo = new Tablero();

        Barco b1 = new Barco("Acorazado", 4);
        Barco b2 = new Barco("Destructor", 3);

        propio.ColocarBarco(b1, 1, 1, true);
        propio.ColocarBarco(b2, 4, 2, false);

        enemigo.Disparar(2, 4);
        enemigo.Disparar(5, 5);

        MostrarTablerosBatalla(propio, enemigo);
    }

    static void MostrarTablerosBatalla(Tablero Jugador, Tablero CPU)
    {
        string[] letras = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };

        Console.Write("      ");
        for (int c = 1; c <= 10; c++)
            Console.Write($"{c,3}");
        Console.Write("      ");
        for (int c = 1; c <= 10; c++)
            Console.Write($"{c,3}");
        Console.WriteLine();

        for (int f = 0; f < 10; f++)
        {
            Console.Write($"  {letras[f]}   ");
            for (int c = 0; c < 10; c++)
                ImprimirCasilla(Jugador.ObtenerCasilla(f, c), true);

            Console.Write($"      {letras[f]}   ");
            for (int c = 0; c < 10; c++)
                ImprimirCasilla(CPU.ObtenerCasilla(f, c), false);

            Console.WriteLine();
        }
    }

    static void ImprimirCasilla(Casilla casilla, bool esProprio)
    {
        if (casilla.EsImpacto())
        {
            if (casilla.Barco?.EstaHundido() == true)
                Console.Write("  #");
            else
                Console.Write("  X");
        }
        else if (casilla.EsAgua())
        {
            Console.Write("  ~");
        }
        else if (!casilla.EstaVacia() && esProprio)
        {
            Console.Write("  S");
        }
        else
        {
            Console.Write("  .");
        }
    }
}