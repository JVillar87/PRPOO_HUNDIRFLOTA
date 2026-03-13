public class Flota
{
    List<Barco> flota;
    
    public Flota()
    {
        flota = new List<Barco>();
    }

    public void AnadirBarco(Barco barco)
    {
        flota.Add(barco);
    }
}