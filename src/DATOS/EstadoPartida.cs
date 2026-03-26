public class EstadoPartida
{
    public string NombreJugador { get; set; } = "Jugador";
    public int DisparosRealizados { get; set; }
    public int AciertosJugador {get; set;}

    public DateTime FechaGuardado {get; set;} = DateTime.Now;
    //GUARDADO COMPLETO: Serializar listas de barcos y estados.
}