using POO.Data;
using POO.Models;

Console.Title = "🐶 Registro de Perros";

while (true)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("══════════════════════════════════════════════");
    Console.WriteLine("🐾 MENÚ PRINCIPAL - GESTIÓN DE PERROS 🐾");
    Console.WriteLine("══════════════════════════════════════════════");
    Console.ResetColor();
    Console.WriteLine("1. Registrar nuevo perro");
    Console.WriteLine("2. Salir");
    Console.Write("👉 Seleccione una opción: ");
    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            RegistrarPerro();
            break;

        case "2":
            Console.WriteLine("\n👋 ¡Hasta luego!");
            return;

        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ Opción no válida. Intente de nuevo.\n");
            Console.ResetColor();
            break;
    }
}
static void RegistrarPerro()
{
    try
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("══════════════════════════════════════════════");
        Console.WriteLine("🐶 REGISTRO DE NUEVO PERRO");
        Console.WriteLine("══════════════════════════════════════════════");
        Console.ResetColor();

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine()?.Trim() ?? "";

        Console.Write("Raza: ");
        string raza = Console.ReadLine()?.Trim() ?? "";

        DateOnly fechaNacimiento;
        while (true)
        {
            Console.Write("Fecha de nacimiento (dd/MM/yyyy): ");
            if (DateOnly.TryParse(Console.ReadLine(), out fechaNacimiento))
            {
                if (fechaNacimiento > DateOnly.FromDateTime(DateTime.Now))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️ La fecha no puede ser posterior a hoy. Intente nuevamente.");
                    Console.ResetColor();
                    continue;
                }

                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠️ Fecha inválida. Intente nuevamente.");
                Console.ResetColor();
            }
        }

        Console.Write("Color: ");
        string color = Console.ReadLine()?.Trim() ?? "";

        string tamaño;
        while (true)
        {
            Console.Write("Tamaño (pequeño / mediano / grande): ");
            tamaño = Console.ReadLine()?.Trim().ToLower() ?? "";
            if (tamaño == "pequeño" || tamaño == "mediano" || tamaño == "grande")
                break;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ Tamaño inválido. Escriba: pequeño, mediano o grande.");
            Console.ResetColor();
        }

        bool genero;
        while (true)
        {
            Console.Write("Género (M para macho / H para hembra): ");
            string input = Console.ReadLine()?.Trim().ToUpper() ?? "";
            if (input == "M")
            {
                genero = true;
                break;
            }
            else if (input == "H")
            {
                genero = false;
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("⚠️ Opción inválida. Use M o H.");
            Console.ResetColor();
        }

        // Crear el perro
        Perro nuevoPerro = new Perro(nombre, raza, fechaNacimiento, color, tamaño, genero);
        Database.Perros.Add(nuevoPerro);
        Console.Clear();
        nuevoPerro.MostrarInformacion();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"❌ Ha ocurrido un error inesperado: {ex.Message}");
        Console.ResetColor();
    }

    Console.WriteLine("Presione una tecla para volver al menú principal...");
    Console.ReadKey();
    Console.Clear();
}