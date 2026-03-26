using HundirLaFlota.Motor;

namespace HundirLaFlota;

class Program
{
    static void Main(string[] args)
    {
        Juego miPartida = new Juego("Capitán Nemo");
        miPartida.Iniciar();

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}