namespace POO.Models;

public class Perro
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Raza { get; set; }
    public DateOnly FechaDeNacimiento { get; set; }
    public string Color { get; set; }
    public string Tamaño { get; set; } // pequeño, mediano, grande
    public bool Genero { get; set; }
    public int Edad { get; }

    public Perro(
        string nombre,
        string raza,
        DateOnly fechaDeNacimiento,
        string color,
        string tamaño,
        bool genero)
    {
        Id = new Random().Next(1, 100);
        Nombre = nombre.ToLower().Trim();
        Raza = raza.ToLower().Trim();
        FechaDeNacimiento = fechaDeNacimiento;
        Color = color.ToLower().Trim();
        Tamaño = tamaño.ToLower().Trim();
        Genero = genero;
        Edad = DateTime.Now.Year - FechaDeNacimiento.Year;
    }

    public void Hablar()
    {
        Console.WriteLine("El perro dice Wauf");
    }     
    
    public void Comer()
    {
        Console.WriteLine("El perro come de todo");
    } 
    
    public void Correr()
    {
        Console.WriteLine("El perro corre mucho");
    } 
}


//ENUMS