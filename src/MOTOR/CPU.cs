namespace HundirLaFlota.Motor;

using HundirLaFlota.Dominio;

public class CPU : Jugador
{
    private List<(int f, int c)> disparosPendientes;
    private static readonly Random rnd = new();

    public CPU() : base("CPU")
    {
        disparosPendientes = new List<(int, int)>();

        //Lista de coordenadas
        for (int f = 0; f < 10; f++)
            for (int c = 0; c < 10; c++)
            {
                disparosPendientes.Add((f, c));
            }

        //Fisher-Yates DENTRO del constructor
        for (int i = disparosPendientes.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (disparosPendientes[i], disparosPendientes[j]) =
            (disparosPendientes[j], disparosPendientes[i]);
        }
    }

    /// <summary>
    /// Devuelve la siguiente coordenada de la lista.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public (int f, int c) ElegirObjetivo()
    {
        if (disparosPendientes.Count == 0)
            throw new InvalidOperationException("No hay coordenadas para disparar.");

        var objetivo = disparosPendientes[0];
        disparosPendientes.RemoveAt(0);

        return objetivo;
    }

    /// <summary>
    /// Coloca todos los barcos aleatoriamente.
    /// </summary>
    /// <param name="flota"></param>
    public void ColocarFlotaAleatoria(List<Barco> flota)
    {
        foreach (var barco in flota)
        {
            bool colocado = false;

            while (!colocado)
            {
                int f = rnd.Next(10);
                int c = rnd.Next(10);
                bool esHorizontal = rnd.Next(2) == 0;

                if (Tablero.PuedeColocar(barco, f, c, esHorizontal))
                {
                    Tablero.ColocarBarco(barco, f, c, esHorizontal);
                    colocado = true;
                }
            }
        }
    }
}