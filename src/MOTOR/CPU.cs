namespace HundirLaFlota.Motor;
using HundirLaFlota.Dominio;

public class CPU : Jugador
{
    private List<(int f, int c)> disparosPendientes;

    public CPU() : base("CPU")
    {
        disparosPendientes = new List<(int, int)>();
        for (int f = 0; f < 10; f++)
            for (int c = 0; c < 10; c++)
                disparosPendientes.Add((f, c));

        // Fisher-Yates shuffle
        Random rnd = new();
        for (int i = disparosPendientes.Count - 1; i > 0; i--)
        {
            int j = rnd.Next(i + 1);
            (disparosPendientes[i], disparosPendientes[j]) = (disparosPendientes[j], disparosPendientes[i]);
        }
    }

    public (int f, int c) ElegirObjetivo()
    {
        var target = disparosPendientes[0];
        disparosPendientes.RemoveAt(0);
        return target;
    }

    public void ColocarFlotaAleatoria()
    {
        Random rnd = new();
        var tipos = new (string Name, int Size)[] {
            ("Portaaviones", 5), 
            ("Acorazado", 4), 
            ("Destructor", 3), 
            ("Submarino", 3), 
            ("Patrullera", 2)
        };

        foreach (var tipo in tipos)
        {
            bool colocado = false;
            while (!colocado)
            {
                int f = rnd.Next(10), c = rnd.Next(10);
                bool hor = rnd.Next(2) == 0;
                if (Tablero.PuedeColocar(f, c, tipo.Size, hor))
                {
                    Tablero.ColocarBarco(new Barco(tipo.Name, tipo.Size), f, c, hor);
                    colocado = true;
                }
            }
        }
    }
}