using HundirLaFlota.Dominio;
using HundirLaFlota.Motor;
namespace HundirLaFlota.Datos;

public class ConfigJuego
{
    public string NombreJugador { get; set; } = "Jugador";
    public NivelDificultad DificultadCPU { get; set; } = NivelDificultad.Medio;
    public DateTime FechaConfiguracion { get; set; } = DateTime.Now;

    public ConfigJuego() { }

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

    public void Guardar(string rutaArchivo)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(this);
        File.WriteAllText(rutaArchivo, json);
    }
}