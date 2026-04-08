using System;

namespace HundirLaFlota.Presentacion;

public static class Colores
{
    // Colores de la Interfaz
    public const ConsoleColor Logo = ConsoleColor.Cyan;
    public const ConsoleColor MenuPrincipal = ConsoleColor.White;
    public const ConsoleColor Error = ConsoleColor.Red;
    public const ConsoleColor Mensaje = ConsoleColor.Yellow;

    // Colores del Tablero
    public const ConsoleColor Agua = ConsoleColor.Blue;
    public const ConsoleColor BarcoPropio = ConsoleColor.Gray;
    public const ConsoleColor Impacto = ConsoleColor.Red;
    public const ConsoleColor Fallo = ConsoleColor.DarkCyan;
    public const ConsoleColor Coordenadas = ConsoleColor.DarkGray;

    /// <summary>
    /// Cambia el color de la consola, escribe el texto y restaura el color original.
    /// </summary>
    public static void EscribirConColor(string texto, ConsoleColor color, bool nuevaLinea = true)
    {
        Console.ForegroundColor = color;
        if (nuevaLinea)
            Console.WriteLine(texto);
        else
            Console.Write(texto);
        Console.ResetColor();
    }
}