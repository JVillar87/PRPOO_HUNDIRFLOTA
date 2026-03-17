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
        }
    
    // public object IsEmpty()
    // {
    //     return IsEmpty => Barco == null;
    // }

    // public object IsImpact()

    // {
    //     if (Disparada = true)
        
    //     return IsImpact => Disparada && Barco != null;
    // }
    // public object IsWater()
    // {
    //     return IsWater => Disparada && Barco == null;
    // }
}
