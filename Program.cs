using POO.Data;
using POO.Models;
using POO.Views;

Console.Title = "🐶 Registro de Perros";

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("══════════════════════════════════════════════");
    Console.WriteLine("🐾 MENÚ PRINCIPAL - GESTIÓN DE PERROS 🐾");
    Console.WriteLine("══════════════════════════════════════════════");
    Console.ResetColor();
    Console.WriteLine("1. Registrar nuevo perro");
    Console.WriteLine("2. Mostrar a todos los perros");
    Console.WriteLine("0. Salir");
    Console.Write("👉 Seleccione una opción: ");
    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            PerrosViews.RegistrarPerro();
            break;
        
        case "2":
            PerrosViews.ListarPerros();
            break;

        case "0":
            Console.WriteLine("\n👋 ¡Hasta luego!");
            return;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ Opción no válida. Intente de nuevo.\n");
            Console.ResetColor();
            break;
    }
}
