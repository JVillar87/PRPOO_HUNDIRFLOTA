public class Flota
{
    private List<Barco> flota;
    
    public Flota()
    {
        flota = new List<Barco>()
        {
            new Barco("Portaaviones", 5),
            new Barco("Acorazado", 4),
            new Barco("Destructor", 3),
            new Barco("Submarino", 3),
            new Barco("Patrullera", 2)
        };
    }

    public void AddBarco(Barco barco)
    {
        if (barco != null)
        {
            flota.Add(barco);
        }
    }

}