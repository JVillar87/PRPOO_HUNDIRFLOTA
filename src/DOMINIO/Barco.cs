public class Barco
{
    public string Name {get; set;}
    public int Size {get; set;} 
    public int Impact {get; set;}
    private List<Casilla> casillas = new List<Casilla>();
    public Barco (string name, int size, int Impact, List<Casilla> casillas)
    {
        this.Name = name;
        this.Size = size;
        this.Impact = 0;
        this.casillas = casillas;
    } 
    
     public Barco (string name, int size)
    {
        this.Name = name;
        this.Size = size;
     
    } 

    public void RegistrarImpacto()
    {
        Impact++;
    }

    public bool EstaHundido()
    {
        return Impact >= casillas.Count;
    }
}