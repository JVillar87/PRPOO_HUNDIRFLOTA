using System.Reflection.Metadata;

public class Tablero
{    
    private int Espacios = 10;
    private Casilla[,] marJugador = new Casilla[10, 10];
    private Casilla[,] marEnemigo = new Casilla[10, 10];

    public Tablero()
    {
      StartTableros();
    }

    private void StartTableros()
   {
      for (int i = 0; i < Espacios; i++)
      {
         marJugador[i,j] = new Casilla();
         marEnemigo[i,j] = new Casilla();
      }
   }

   public void Dibujar()
{
    
    Console.WriteLine("TABLERO DEL JUGADOR");
    Console.WriteLine("A B C D E F G H I J"); 
    Console.WriteLine("---------------------");

    for (int fila = 0; fila < 10; fila++)
    {
        
        Console.Write((fila + 1).ToString().PadLeft(2) + "| ");

        for (int col = 0; col < 10; col++)
        {
            
            Casilla c = marJugador[fila, col];

            
            if (!(c.Disparada && c.Barco)) 
                Console.Write("X "); //DISPARO
            else if (c.Disparada) 
                Console.Write("~ "); //AGUA
                else 
                Console.Write(". "); //VACIA
        }
        Console.WriteLine("|"); 
    }
    Console.WriteLine("  ---------------------");
}

}

// Colores y símbolos
/*? indica la posición provisional del barco antes de confirmar.
La posición se muestra en verde si es válida y en rojo si es inválida.
/*| Símbolo | Estado | Color de consola |

| . | Casilla vacía | Gris oscuro | | S | Barco propio visible | Verde | | ~ | 
Agua (disparo fallado) | Azul | | X | Impacto en barco | Amarillo | 
| # | Barco hundido | Rojo |*/

