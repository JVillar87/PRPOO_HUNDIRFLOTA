using System;
using System.Collections.Generic;

namespace HundirLaFlota.Datos;

public class EstadoPartida
{
    public string NombreJugador { get; set; } = "Jugador";
    public int DisparosRealizados { get; set; }
    public int AciertosJugador { get; set; }
    public DateTime FechaGuardado { get; set; } = DateTime.Now;
    //GUARDADO COMPLETO: Serializar listas de barcos y estados.

    //Constructor JSON
    public EstadoPartida() { }

    //Constructor manual
    public EstadoPartida(string nombre, int disparos, int aciertos)
    {
        NombreJugador = nombre;
        DisparosRealizados = disparos;
        AciertosJugador = aciertos;
        FechaGuardado = DateTime.Now;
    }
}