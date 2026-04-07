namespace HundirLaFlota.Dominio;

public class Tablero
{
    private Casilla[,] matriz = new Casilla[10, 10];
    private List<Barco> navios = new List<Barco>();

    public Tablero()
    {
        for (int f = 0; f < 10; f++)
            for (int c = 0; c < 10; c++)
                matriz[f, c] = new Casilla(f, c);
    }

    public Casilla ObtenerCasilla(int f, int c) => matriz[f, c];

    public bool PuedeColocar(Barco barco, int fila, int columna, bool esHorizontal)
    {

        for (int i = 0; i < barco.Size; i++)
        {
            int r = esHorizontal ? fila : fila + i;
            int c = esHorizontal ? columna + i : columna;

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

    public void ColocarBarco(Barco barco, int fila, int columna, bool esHorizontal)
    {
        for (int i = 0; i < barco.Size; i++)
        {
            int r = esHorizontal ? fila : fila + i;
            int c = esHorizontal ? columna + i : columna;
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

        casilla.Barco?.RecibirImpacto();
        return casilla.Barco?.EstaHundido() ?? false ? ResultadoDisparo.Hundido : ResultadoDisparo.Impacto;
    }

    public List<Barco> Barcos => navios;

    public int BarcosRestantes
    {
        get
        {
            int count = 0;
            foreach (Barco b in navios)
                if (!b.EstaHundido()) count++;
            return count;
        }
    }

    public bool TodosHundidos
    {
        get
        {
            foreach (Barco b in navios)
                if (!b.EstaHundido()) return false;
            return true;
        }
    }
}