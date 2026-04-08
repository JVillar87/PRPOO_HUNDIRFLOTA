namespace HundirLaFlota.Datos;
/// <summary>
/// Registro de una entrada en el marcador, con el nombre del jugador, número de disparos, precisión, puntuación y fecha.
/// </summary>
/// <param name="Nombre"></param>
/// <param name="Disparos"></param>
/// <param name="Precision"></param>
/// <param name="Puntuacion"></param>
/// <param name="Fecha"></param>
public record EntradaMarcador(
    string Nombre,
    int Disparos, 
    double Precision,
    double Puntuacion, 
    DateTime Fecha);
