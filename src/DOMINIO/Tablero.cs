
   public class Tablero
{     
public static void CreaTablero()

{ 
   Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════╗");
   Console.WriteLine("║                          HUNDIR LA FLOTA                              ║");
   Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════╣");
   Console.WriteLine("║     TU TABLERO                          MAR ENEMIGO                   ║");
   Console.WriteLine("║      1  2  3  4  5  6  7  8  9  10    1  2  3  4  5  6  7  8  9  10   ║");
   Console.WriteLine("║  A   .  .  .  .  .  .  .  .  .  .   A   .  .  .  .  .  .  .  .  .  .  ║");
   Console.WriteLine("║  B   .  S  S  S  S  .  .  .  .  .   B   .  .  ~  .  .  .  .  .  .  .  ║");
   Console.WriteLine("║  C   .  .  .  .  .  .  .  .  .  .   C   .  .  .  .  X  .  .  .  .  .  ║");
   Console.WriteLine("║  D   .  .  .  .  .  .  .  .  .  .   D   .  .  .  .  .  .  ~  .  .  .  ║");
   Console.WriteLine("║  E   .  .  S  .  .  .  .  .  .  .   E   .  .  .  .  .  .  .  .  .  .  ║");
   Console.WriteLine("║  F   .  .  S  .  .  .  .  .  .  .   F   .  .  .  X  .  .  .  .  .  .  ║");
   Console.WriteLine("║  G   .  .  S  .  .  .  .  .  .  .   G   .  .  .  .  .  .  .  .  .  .  ║");
   Console.WriteLine("║  H   .  .  .  .  .  .  .  .  .  .   H   .  .  ~  .  .  .  .  .  .  .  ║");
   Console.WriteLine("║  I   .  .  .  .  .  .  S  S  .  .   I   .  .  .  .  .  .  .  .  .  .  ║");
   Console.WriteLine("║  J   .  .  .  .  .  .  .  .  .  .   J   .  .  .  .  .  .  .  .  .  .  ║");
   Console.WriteLine("╠═══════════════════════════════════════════════════════════════════════╣");
   Console.WriteLine("║  Disparos: 6   Aciertos: 2   Fallos: 4   Precisión: 33.3 %            ║");
   Console.WriteLine("║  Barcos hundidos: 0 / 5       Barcos enemigos restantes: 5            ║");
   Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════╝");

 }
}
// Colores y símbolos
/*? indica la posición provisional del barco antes de confirmar.
La posición se muestra en verde si es válida y en rojo si es inválida.
/*| Símbolo | Estado | Color de consola |

| . | Casilla vacía | Gris oscuro | | S | Barco propio visible | Verde | | ~ | 
Agua (disparo fallado) | Azul | | X | Impacto en barco | Amarillo | 
| # | Barco hundido | Rojo |*/