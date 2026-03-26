namespace HundirLaFlota.Dominio;

public class Tablero
{
    private readonly Casilla[,] matriz = new Casilla[10, 10];
    public List<Barco> Barcos { get; } = new();

    public Tablero()
    {
        for (int f = 0; f < 10; f++)
            for (int c = 0; c < 10; c++)
                matriz[f, c] = new Casilla(f, c);
    }

    public Casilla ObtenerCasilla(int f, int c) => matriz[f, c];

    public bool PuedeColocar(int fila, int col, int tam, bool horizontal)
    {
        for (int i = 0; i < tam; i++)
        {
            int r = horizontal ? fila : fila + i;
            int c = horizontal ? col + i : col;

            if (r < 0 || r >= 10 || c < 0 || c >= 10) 
            {
                return false;
            }

            // Regla de adyacencia (incluye diagonales)
            for (int df = -1; df <= 1; df++)
                for (int dc = -1; dc <= 1; dc++)
                {
                    int nr = r + df, nc = c + dc;
                    if (nr >= 0 && nr < 10 && nc >= 0 && nc < 10 && !matriz[nr, nc].EstaVacia())
                        return false;
                }
        }
        return true;
    }

    public void ColocarBarco(Barco barco, int fila, int col, bool horizontal)
    {
        for (int i = 0; i < barco.Size; i++)
        {
            int r = horizontal ? fila : fila + i;
            int c = horizontal ? col + i : col;
            matriz[r, c].Barco = barco;
            barco.Casillas.Add(matriz[r, c]);
        }
        Barcos.Add(barco);
    }

    public ResultadoDisparo Disparar(int f, int c)
    {
        var casilla = matriz[f, c];
        if (casilla.Disparada) return ResultadoDisparo.YaDisparado;

        casilla.Disparada = true;
        if (casilla.EstaVacia()) return ResultadoDisparo.Agua;

        casilla.Barco!.RecibirImpacto();
        return casilla.Barco.EstaHundido() ? ResultadoDisparo.Hundido : ResultadoDisparo.Impacto;
    }

    public bool TodosHundidos => Barcos.All(b => b.EstaHundido());
}