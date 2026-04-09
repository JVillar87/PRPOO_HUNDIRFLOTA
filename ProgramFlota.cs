using HundirLaFlota.Datos;
using HundirLaFlota.Dominio;
using HundirLaFlota.Presentacion;
using HundirLaFlota.Motor;
using System.Threading;

namespace HundirLaFlota
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hundir la Flota - Proyecto POO";
            bool salir = false;

            //MENÚ PRINCIPAL
            while (!salir)
            {
                MostrarMenuPrincipal();
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        IniciarNuevaPartida();
                        break;
                    case "2":
                        CargarPartidaGuardada();
                        break;
                    case "3":
                        MostrarInstrucciones();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Renderizador.MostrarError("Opción no válida. Intente de nuevo.");
                        Thread.Sleep(1500);
                        break;
                }
            }
        }

        static void MostrarMenuPrincipal()
        {
            Console.Clear();
            ArteAscii.MostrarLogo(); // Usamos tu nuevo arte ASCII centrado
            Console.WriteLine("\n" + new string(' ', 15) + "1. Nueva Partida");
            Console.WriteLine(new string(' ', 15) + "2. Cargar Partida");
            Console.WriteLine(new string(' ', 15) + "3. Instrucciones");
            Console.WriteLine(new string(' ', 15) + "4. Salir");
            Console.Write("\n" + new string(' ', 15) + "Seleccione una opción: ");
        }

        
        static void IniciarNuevaPartida()
        {
            Console.Clear();
            Console.WriteLine("Iniciando nueva partida...");
            string nombre = "Jugador"; // Podríamos pedir el nombre al usuario aquí

            ConfigJuego config = new ConfigJuego(nombre, NivelDificultad.Facil);
            Juego partida = new Juego(config);
            partida.Iniciar();
        }

        static void CargarPartidaGuardada()
        {
            Console.Clear();
            Renderizador.MostrarMensaje("Cargando partida guardada...");
            Thread.Sleep(1000); // Simula tiempo de carga

            Console.WriteLine("CARGANDO PARTIDA...");
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }


        static void MostrarInstrucciones()
        {
            Console.Clear();
            Console.WriteLine("INSTRUCCIONES:");
            Console.WriteLine("1. Coloca tus barcos en el tablero.");
            Console.WriteLine("2. Dispara a las coordenadas enemigas para hundir su flota.");
            Console.WriteLine("3. El primer jugador en hundir toda la flota enemiga gana.");
            Console.WriteLine("Presiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}