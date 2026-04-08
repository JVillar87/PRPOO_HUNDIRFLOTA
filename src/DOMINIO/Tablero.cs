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

    public Casilla ObtenerCasilla(int f, int c) 
    {
        return matriz[f, c];
    }

    public bool ColocarBarco(Barco barco, int fila, int columna, bool esHorizontal)
    {
        if (!PuedeColocar(barco, fila, columna, esHorizontal)) return false;

        for (int i = 0; i < barco.Size; i++)
        {
            int f = esHorizontal ? fila : fila + i;
            int c = esHorizontal ? columna + i : columna;

            matriz[f, c].Barco = barco;
            barco.Casillas.Add(matriz[f, c]);
        }
        navios.Add(barco);
        return true;
    }


    public bool PuedeColocar(Barco barco, int fila, int columna, bool esHorizontal)
    {
        int filaFinal = esHorizontal ? fila : fila + barco.Size - 1;
        int columnaFinal = esHorizontal ? columna + barco.Size - 1 : columna;

        //Comprobar límites
        if (fila < 0 || filaFinal >= 10 || columna < 0 || columnaFinal >= 10) return false;

        for (int i = 0; i < barco.Size; i++)
        {
            int r = esHorizontal ? fila : fila + i;
            int c = esHorizontal ? columna + i : columna;

            // Regla de adyacencia
            for (int df = -1; df <= 1; df++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    int nr = r + df, nc = c + dc;
                    if (nr >= 0 && nr < 10 && nc >= 0 && nc < 10 && !matriz[nr, nc].EstaVacia())
                        return false;
                }
            }
        }
        return true;
    }

    public ResultadoDisparo Disparar(int f, int c)
    {
        var casilla = matriz[f, c];
        if (casilla.Disparada) return ResultadoDisparo.YaDisparado;

        casilla.Disparada = true;
        if (casilla.EstaVacia()) return ResultadoDisparo.Agua;

        casilla.Barco?.RecibirImpacto();
        if (casilla.Barco != null && casilla.Barco.EstaHundido())
            return ResultadoDisparo.Hundido;
            
        return ResultadoDisparo.Impacto;
    }

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