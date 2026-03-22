

class program
{
    //Contadores Globales
    static int totalEvaluados = 0;
    static int publicados = 0;             //LLevan static por que así se pueden utilizar en cualquier funcion de la clase
    static int ajustes = 0;
    static int revision = 0;
    static int rechazados = 0;

    static int impactoAlto = 0;
    static int impactoMedio = 0;
    static int impactoBajo = 0;
    static void Main()
    {
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
                    EvaluarContenido();
                    totalEvaluados++;
                    break;
                case 2:
                    Console.WriteLine("Usted ha elegido Mostrar reglas del sistema");
                    MostrarReglas();
                    break;
                case 3:
                    Console.WriteLine("Usted ha elegido Mostrar estadísticas");
                    MostrarEstadisticas();
                    break;
                case 4:
                    Console.WriteLine("Usted ha elegido Reiniciar estadísticas");
                    ReiniciarEstadistica();
                    break;
                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opcion Invalida");
                    break;
            }
        } while (opcion != 5);
    }
    //FUNCIONES PARA PEDIR LOS DATOS
    // Pedir tipo de contenido
    static int PedirTipo()
    {
        int tipo = 0;
        while (tipo <1 || tipo >4)
        {
            Console.WriteLine("¿Que tipo de contenido es ?");
            Console.WriteLine("1. Película");
            Console.WriteLine("2. Serie");
            Console.WriteLine("3. Documental");
            Console.WriteLine("4. Evento en vivo");
            tipo = int.Parse(Console.ReadLine());
        }
        return tipo;
    }
    //Pedir Duracion 
    static int PedirDuracion ()
    {
        int duracion = 0;
        while (duracion <= 0)
        {
            Console.WriteLine("Ingrese el tiempo en minutos");
            duracion = int.Parse(Console.ReadLine());
        }
        return duracion;

    }
    //Pedir la clasificacion del contenido
    static int PedirClasificacion ()
    {
        int clasificacion = 0;
        while (clasificacion < 1 || clasificacion > 3)
        {
            Console.WriteLine("¿Qué tipo de clasificación tiene?");
            Console.WriteLine("1. Todo público");
            Console.WriteLine("2. +13");
            Console.WriteLine("3. +18");
            clasificacion = int.Parse(Console.ReadLine());
        }
        return clasificacion;
    }
    //Pedir el horario programado
    static int PedirHora()
    {
        int hora = -1;
        while (hora < 0 || hora > 23)
        {
            Console.WriteLine("Ingrese hora (0-23): ");
            hora = int.Parse(Console.ReadLine());
        }
        return hora;
    }
    //Pedir el nivel de produccion 
    static int PedirProduccion()
    {
        int produccion = 0;
        while (produccion < 1 || produccion > 3)
        {
            Console.WriteLine("¿Que nivel de produccion tiene?");
            Console.WriteLine("1. Bajo");
            Console.WriteLine("2. Medio");
            Console.WriteLine("3. Alto");
            produccion = int.Parse(Console.ReadLine());
        }
        return produccion;
    }
    //VALIDACION TECNICA
    static bool ValidacionTecnica(int tipo, int duracion, int clasificacion, int hora, int produccion)
    {
        bool valido = true;
        //Horario
       
        if (clasificacion == 3 && !(hora >= 22 || hora <= 5))
        {
            Console.WriteLine("Rechazado. Contenido +18 solo entre 22:00 y 5:00 (hrs)");
            valido = false;
        }
        else if (clasificacion == 2 && !(hora >= 6 && hora <= 22))
        {
            Console.WriteLine("Rechazado. Contenido +13 solo entre 6:00 y 22:00");
            valido = false;
        }
        // Duracion 
        if (tipo == 1 && !(duracion >= 60 && duracion <= 180))
        {
            Console.WriteLine("Rechazado. La duración tiene que ser de 60 a 180 minutos.");
            valido = false;
        }
        else if (tipo == 2 && !(duracion >= 20 && duracion <= 90))
        {
            Console.WriteLine("Rechazado. La duración tiene que ser de 20 a 90 minutos.");
            valido = false;
        }
        else if (tipo == 3 && !(duracion >= 30 && duracion <= 120))
        {
            Console.WriteLine("Rechazado. La duración tiene que ser de 30 a 120 minutos.");
            valido = false;
        }
        else if (tipo == 4 && !(duracion >= 30 && duracion <= 240))
        {
            Console.WriteLine("Rechazado. La duración tiene que ser de 30 a 240 minutos.");
            valido = false;
        }
        // Producción
        if (produccion == 1 && clasificacion == 3)
        {
            valido = false;
            Console.WriteLine("Rechazado. Producción Baja no permite contenido +18");
        }
        return valido;
    }
    //FUNCION PARA EVALUAR EL CONTENIDO Y CLASIFICAR EL IMPACTO
    static void EvaluarContenido()
    {
        int tipo = PedirTipo();
        int duracion = PedirDuracion();
        int clasificacion = PedirClasificacion();
        int hora = PedirHora();
        int produccion = PedirProduccion();
        // 
        for (int i = 1; i<=3; i++)
        {
            Console.WriteLine("Procesando evaluación... Paso " + i);
        }
        bool valido = ValidacionTecnica(tipo, duracion, clasificacion, hora, produccion);

        string impacto = " ";

        if (valido == true)
        {
            //Clasificacion de Impacto
            //Alto
            if (produccion == 3 || duracion > 120 || (hora >= 20 && hora <= 23))
            {
                impacto = "Alto";
                impactoAlto++;
            }
            //Medio
            else if (produccion == 2 || (duracion >= 60 && duracion <= 120))
            {
                impacto = "Medio";
                impactoMedio++;
            }
            //Bajo
            else  
            {
                impacto = "Bajo";
                impactoBajo++;
            }
            //Decisión Final
            if (impacto == "Alto") 
            {
                Console.WriteLine("Enviado a revisión");
                Console.WriteLine("Razón: Impacto Alto");
                revision++;
            }
            else
            {
                if (
                         (tipo == 1 && (duracion == 60 || duracion == 180)) ||
                         (tipo == 2 && (duracion == 20 || duracion == 90)) ||
                         (tipo == 3 && (duracion == 30 || duracion == 120)) ||
                         (tipo == 4 && (duracion == 30 || duracion == 240))
                   )
                {
                    Console.WriteLine("Se puede publicar pero necesita ajustes");
                    Console.WriteLine("Razón: Está en el límite permitido");
                    ajustes++;
                }    
                else
                {
                    Console.WriteLine("Se puede publicar.");
                    Console.WriteLine("Cumple con todos los requisitos");
                    publicados++;
                }
            }
           
        }
        else
        {
            Console.WriteLine("Contenido Rechazado");
            Console.WriteLine("Razón: No cumple con las reglas técnicas");
            rechazados++;
        }

    }
    //PROCEDIMIENTO PARA MOSTRAR REGLAS
    static void MostrarReglas()
    {
        
        Console.WriteLine("--------REGLAS DEL SISTEMA--------");
        Console.WriteLine("Contenido +18 solo en horarios de 22 y 5 hrs");
        Console.WriteLine("Contenido +13 solo en horarios de 6 y 22 hrs");
        Console.WriteLine("Contenido para todo público a cualquier hora");
        Console.WriteLine("Duración peliculas: 60-180 minutos");
        Console.WriteLine("Duración series: 20-90 minutos");
        Console.WriteLine("Duración Documental: 30-120 minutos");
        Console.WriteLine("Duración Evento en vivo: 30-240 minutos");
        Console.WriteLine("Producción baja solo válida para Todo público o +13");
        Console.WriteLine("Producción media o alta válida para cualquier clasificación");
        Console.WriteLine("Si incumple una regla, se rechazará por completo la solicitud de publicar el contenido");
    }
    //PROCEDIMIENTO PARA MOSTRAR ESTADISTICAS
    static void MostrarEstadisticas()
    {
        Console.WriteLine("Total evaluados: " + totalEvaluados);
        Console.WriteLine("Publicados: " + publicados);
        Console.WriteLine("En revisión: " + revision);
        Console.WriteLine("Con ajustes: " + ajustes);
        Console.WriteLine("Rechazados: " + rechazados);

        //Definir el impacto predominante
        string impactoPredominante = "Bajo";

        if (impactoAlto >= impactoMedio && impactoAlto>= impactoBajo)
        {
            impactoPredominante = "Alto";
        }
        else if (impactoMedio >= impactoAlto && impactoMedio >= impactoBajo)
        {
            impactoPredominante = "Medio";
        }
        Console.WriteLine("Impacto Predominante :" + impactoPredominante);

        //Definir el porcentaje de aprobación
        double porcentaje = 0;
        if (totalEvaluados>0)
        {
            porcentaje = (publicados * 100.0) / totalEvaluados;
        }
        Console.WriteLine("Porcentaje de aprobación: " + porcentaje + "%");
    }
    //PROCEDIMIENTO PARA REINICIAR ESTADÍSTICAS
    static void ReiniciarEstadistica()
    {
        publicados = 0;
        ajustes = 0;
        revision = 0;
        rechazados = 0;
        totalEvaluados = 0;
        impactoAlto = 0;
        impactoMedio = 0;
        impactoBajo = 0;    
        Console.WriteLine("Se han reiniciado las estadisticas :)");
    }
}






