  public class Casilla
{
        public int Fila { get; }
        public int Columna { get; }

        public Barco? Barco { get; set; }
        public bool Disparada { get; set; }

        public Casilla(int fila, int columna)
        {
            Fila = fila;
            Columna = columna;
            Disparada = false;
        }

    public Casilla()
    {
    }

    public bool AsignarBarco(Barco barco)
    {
        Barco = barco;
    }
    public bool EstaVacia()
    {
        return Barco == null;
    }

    public bool EsImpacto()
    {
        return Disparada && Barco != null;
    }

    public bool EsAgua()
    {
        return Disparada && Barco == null;
    }

    public void RegistroDisparoo()
    {
        Disparada = true;
    }

}

