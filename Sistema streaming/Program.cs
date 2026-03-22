
int opcion;
do
{
 
    Console.WriteLine("----------------MENÚ----------------");
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
            Console.WriteLine("Usted ha elegido Evaluar Contenido");
            // Tipo de contenido
            int tipo = 0;
            while (tipo <1 || tipo>4)
            { 
            Console.WriteLine("¿Que tipo de contenido es ?");
            Console.WriteLine("1. Película");
            Console.WriteLine("2. Serie");
            Console.WriteLine("3. Documental");
            Console.WriteLine("4. Evento en vivo");
            tipo = int.Parse(Console.ReadLine());
            }
            // Duración 
            int duracion = 0;
            while (duracion <=0)
            {
                Console.WriteLine("Ingrese el tiempo en minutos");
                duracion = int.Parse(Console.ReadLine());
            }
            // Clasificacion (todo público, +13,+18)
            int clasificacion = 0;
            while (clasificacion <1 || clasificacion >3)
            {
            Console.WriteLine("¿Qué tipo de clasificación tiene?");
            Console.WriteLine("1. Todo público");
            Console.WriteLine("2. +13");
            Console.WriteLine("3. +18");
            clasificacion = int.Parse(Console.ReadLine());
            }
            // Hora programada
            int hora = -1;
            while (hora <0 || hora >23)
            {
                Console.WriteLine("Ingrese hora (0-23): ");
                hora = int.Parse(Console.ReadLine());
            }
            // Nivel de producción
            int produccion = 0;
            while (produccion < 1 || produccion > 3)
            {
                Console.WriteLine("¿Que nivel de produccion tiene?");
                Console.WriteLine("1. Bajo");
                Console.WriteLine("2. Medio");
                Console.WriteLine("3. Alto");
                produccion = int.Parse(Console.ReadLine());
            }
            // VALIDACIÓN DE CONTENIDO
            // validaciónes por clasificación y horario

            bool validacionHorario = false;
            if ( clasificacion == 3 && !(hora >= 22 || hora <=5) )
            {
                
                Console.WriteLine("Rechazado. Contenido +18 solo entre 22:00 y 5:00 (hrs)");
            }
            else if (clasificacion == 2 && !(hora >=6 && hora <22))
            {
                Console.WriteLine("Rechazado. Contenido +13 solo entre 6:00 y 22:00");
            }
            else
            {
                validacionHorario = true;
                Console.WriteLine("Su contenido a sido aprobado");
            }
            // Validación con duración por tipo
            bool validacionDuracion = false;
            if (tipo == 1 && !(duracion >= 60 && duracion <= 180))
            {
                Console.WriteLine("Rechazado. La duración tiene que ser de 60 a 180 minutos.");
            }
            else if (tipo == 2 && !(duracion >=20 && duracion <= 90))
            {
                Console.WriteLine("Rechazado. La duración tiene que ser de 20 a 90 minutos.");
            }
            else if (tipo == 3 && !(duracion >=30 && duracion <= 120))
            {
                Console.WriteLine("Rechazado. La duración tiene que ser de 30 a 120 minutos.");
            }
            else if (tipo == 4 && !(duracion >= 30 && duracion <=240))
            {
                Console.WriteLine("Rechazado. La duración tiene que ser de 30 a 240 minutos.");
            }
            else
            {
                validacionDuracion = true;
                Console.WriteLine("Su contenido a sido aprobado2");
            }
            // Validación con producción 
            bool validacionProduccion = false;
            if (produccion == 1 && clasificacion == 3)
            {
                validacionDuracion = false;
                Console.WriteLine("Rechazado. Producción Baja no permite contenido +18");
            }
            else
            {
                validacionDuracion = true;
                Console.WriteLine("Aprobado3");
            }

            //Clasificación de Impacto
            


        


            break;
        case 2:
            Console.WriteLine("Usted ha elegido Mostrar reglas del sistema");
            break;
        case 3:
            Console.WriteLine("Usted ha elegido Mostrar estadísticas");
            break;
        case 4:
            Console.WriteLine("Usted ha elegido Reiniciar estadísticas");
            break;
        case 5:
            Console.WriteLine("Saliendo...");
            break;
        default:
            Console.WriteLine("Opcion Invalida");
            break;
    }
} while (opcion != 5);





