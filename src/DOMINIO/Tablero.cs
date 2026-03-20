public class Tablero
    {
        private const int BOARD = 10;
        private Casilla[,] celdas = new Casilla[BOARD, BOARD];
        private List<Barco> barcosEnTablero = new List<Barco>();

        public Tablero()
        {
            
            for (int f = 0; f < BOARD; f++)
            {
                for (int c = 0; c < BOARD; c++)
                {
                    celdas[f, c] = new Casilla(f, c);
                }
            }
        }
        
        public int BarcosRestantes => barcosEnTablero.Count(b => !b.EstaHundido());

        public bool TodosHundidos => barcosEnTablero.Count > 0 && barcosEnTablero.All(b => b.EstaHundido());

        public Casilla ObtenerCasilla(int fila, int columna)
        {
            if (fila < 0 || fila >= BOARD || columna < 0 || columna >= BOARD) return null;
            return celdas[fila, columna];
        }

        public bool PuedeColocar(Barco barco, int fila, int columna, bool esHorizontal)
        {
            int longitud = barco.Size;

            for (int i = 0; i < barco.Size; i++)
            {
                int fActual = esHorizontal ? fila : fila + i;
                int cActual = esHorizontal ? columna + i : columna;

               
                if (fActual >= BOARD || cActual >= BOARD || fActual < 0 || cActual < 0) 
                    return false;

                if (!EstaZonaDespejada(fActual, cActual))
                    return false;
            }
            return true;
        }

        private bool EstaZonaDespejada(int fila, int columna)
        {
            
            for (int f = fila - 1; f <= fila + 1; f++)
            {
                for (int c = columna - 1; c <= columna + 1; c++)
                {
                    // Si la vecina está dentro del tablero y tiene un barco
                    if (f >= 0 && f < BOARD && c >= 0 && c < BOARD)
                    {
                        if (celdas[f, c].TieneBarco) return false;
                    }
                }
            }
            return true;
        }

        public void ColocarBarco(Barco barco, int fila, int columna, bool esHorizontal)
        {
            if (!PuedeColocar(barco, fila, columna, esHorizontal))
                throw new InvalidOperationException("Posición no válida por límites o adyacencia.");

            for (int i = 0; i < barco.Longitud; i++)
            {
                int f = esHorizontal ? fila : fila + i;
                int c = esHorizontal ? columna + i : columna;

                celdas[f, c].AsignarBarco(barco);
            }
            barcosEnTablero.Add(barco);
        }

        public ResultadoDisparo Disparar(int fila, int columna)
        {
            Casilla casilla = ObtenerCasilla(fila, columna);
            if (casilla == null || casilla.FueDisparada