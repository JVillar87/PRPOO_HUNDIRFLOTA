using HundirLaFlota.Dominio;
using HundirLaFlota.Motor;
using System;
using System.IO;
using System.Text.Json;

namespace HundirLaFlota.Datos;

public enum NivelDificultad
{
    Facil,
    Medio,
    Dificil
}
public class ConfigJuego
{
    public string NombreJugador { get; set; } = "Jugador";
    public NivelDificultad DificultadCPU { get; set; } = NivelDificultad.Medio;
    public DateTime FechaConfiguracion { get; set; } = DateTime.Now;

    public ConfigJuego(string nombreJugador, NivelDificultad dificultadCPU)
    {
        NombreJugador = nombreJugador;
        DificultadCPU = dificultadCPU;
        FechaConfiguracion = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Jugador: {NombreJugador}, Dificultad CPU: {DificultadCPU}, Fecha: {FechaConfiguracion}";
    }
}