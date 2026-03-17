
int opcion;
do
{
    Console.WriteLine("SISTEMA DE UNA PLATAFORMA DE STREAMING");
    Console.WriteLine("Seleccione una opcion :)  ");
    Console.WriteLine("1. Evaluar nuevo contenido");
    Console.WriteLine("2. Mostrar reglas del sistema");
    Console.WriteLine("3. Mostrar estadísticas");
    Console.WriteLine("4. Reiniciar estadísticas");
    Console.WriteLine("5. Salir");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1:
            Console.WriteLine("""Usted ha elegido "Evaluar Contenido""");

            break;
        case 2:
            Console.WriteLine("""Usted ha elegido "Mostrar reglas del sistema""");
            break;
        case 3:
            Console.WriteLine("""Usted ha elegido "Mostrar estadísticas""");
            break;
        case 4:
            Console.WriteLine("""Usted ha elegido "Reiniciar estadísticas""");
            break;
        case 5:
            Console.WriteLine("Saliendo...");
            break;
        default:
            Console.WriteLine("Opcion Invalida");
            break;
    }
} while (opcion != 5);




