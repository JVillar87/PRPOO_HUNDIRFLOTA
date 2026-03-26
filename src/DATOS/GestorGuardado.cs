using System.Text.Json;
namespace HundirLaFlota.Datos;

public class GestorGuardado
{
    private const string NombreArchivo = "partida_guardada.json";

    public static void Guardar(EstadoPartida estado)
    {
        try
        {
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(estado, opciones);
            File.WriteAllText(NombreArchivo, jsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error de guardado: {ex.Message}");
        }
    }

    public static EstadoPartida? Cargar()
    {
        if (!File.Exists(NombreArchivo)) return null;
        try
        {
            string jsonString = File.ReadAllText(NombreArchivo);
            return JsonSerializer.Deserialize<EstadoPartida>(jsonString);
        }
        catch
        {

            return null; //ARCHIVO CORRUPTO
        }
    }

    public bool ExistPartida => File.Exists(NombreArchivo);

    public static void EliminarGuardado()
    {
        if (File.Exists(NombreArchivo))
        {
            File.Delete(NombreArchivo);
        }
    }
}