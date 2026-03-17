public class Barco
{
    public string Name {get; set;}
    public int Size {get; set;} 
    public int Impact {get; set;} 

    public Barco (string name, int size, int Impact)
    {
        this.Name = name;
        this.Size = size;
        this.Impact = 0;
    }
    public class Casillas
    {
        List<Casillas> casillas = new List<Casillas>();
    }


}