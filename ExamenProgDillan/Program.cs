using System;

class Program
{
    static string[] placas = new string[15];
    static int[] vehiculos = new int[15];
    static double[] tarifas = new double[15] { 0, 50, 70, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650 };
    static double[] recaudacion = new double[15];
    private static int numMaxRegistros;

    static void Main(string[] args)
    {
        int opcion = 0;

        while (opcion != 4)
        {
            Console.Clear();
            Console.WriteLine("Menú Principal del Sistema:");
            Console.WriteLine("1. Inicializar Vectores");
            Console.WriteLine("2. Registrar Paso de Vehículo");
            Console.WriteLine("3.Consulta de vehículos por número de placa");
            Console.WriteLine("4.Modificar datos de vehiculos por número de placa");
            Console.WriteLine("5. Ver Recaudación por Tipo de Vehículo");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    InicializarVectores();
                    break;
                case 2:
                    RegistrarPaso();
                    break;
                case 3:
                    ConsultarVehiculosPorPlaca();
                    break;
                case 4:
                    ModificarDatosVehiculo();
                    break;
                case 5:
                    VerRecaudacion();
                    break;
                case 6:
                    Console.WriteLine("¡Hasta la vista!");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void InicializarVectores()
    {
        for (int i = 0; i < vehiculos.Length; i++)
        {
            vehiculos[i] = 0;
            recaudacion[i] = 0;
        }

        Console.WriteLine("Vectores inicializados correctamente.");
    }

    static void RegistrarPaso()
    {
        Console.WriteLine("Registro de Paso de Vehículos");

        const int MAX_REGISTROS = 15;

        int[] numFactura = new int[MAX_REGISTROS];
        string[] numPlaca = new string[MAX_REGISTROS];
        DateTime[] fecha = new DateTime[MAX_REGISTROS];
        TimeSpan[] hora = new TimeSpan[MAX_REGISTROS];
        int[] tipoVehiculo = new int[MAX_REGISTROS];
        int[] numCaseta = new int[MAX_REGISTROS];
        double[] montoAPagar = new double[MAX_REGISTROS];
        double[] pagaCon = new double[MAX_REGISTROS];
        double[] vuelto = new double[MAX_REGISTROS];

        int numRegistros = 0;
        bool continuar = true;

        while (continuar)
        {
            if (numRegistros >= MAX_REGISTROS)
            {
                Console.WriteLine("Se ha alcanzado el número máximo de registros.");
                break;
            }

            Console.WriteLine($"Registro de paso {numRegistros + 1}");
            Console.Write("Número de factura: ");
            numFactura[numRegistros] = int.Parse(Console.ReadLine());
            Console.Write("Número de placa: ");
            numFactura[numRegistros] = int.Parse(Console.ReadLine());



            Console.Write("Fecha (yyyy-mm-dd): ");
            fecha[numRegistros] = DateTime.Parse(Console.ReadLine());
            Console.Write("Hora (hh:mm:ss): ");
            hora[numRegistros] = TimeSpan.Parse(Console.ReadLine());

            Console.WriteLine("Tabla de precios:");
            Console.WriteLine(" Moto - 500");
            Console.WriteLine(" Vehículo Liviano - 700");
            Console.WriteLine(" Camión o Pesado - 2700");
            Console.WriteLine(" Autobús - 3700");
            Console.WriteLine("Tipos de Vehículo:");
            Console.WriteLine("1. Moto");
            Console.WriteLine("2. Vehículo Liviano");
            Console.WriteLine("3. Camión o Pesado");
            Console.WriteLine("4. Autobús");
            Console.Write("Seleccione el tipo de vehículo: ");
            
            tipoVehiculo[numRegistros] = int.Parse(Console.ReadLine());
            montoAPagar[numRegistros] = CalcularMontoAPagar(tipoVehiculo[numRegistros]);

            Console.Write("Número de caseta (1, 2 o 3): ");
            numCaseta[numRegistros] = int.Parse(Console.ReadLine());

            Console.Write("Monto a pagar: ");
            montoAPagar[numRegistros] = double.Parse(Console.ReadLine());

            Console.Write("Paga con: ");
            pagaCon[numRegistros] = double.Parse(Console.ReadLine());
            vuelto[numRegistros] = pagaCon[numRegistros] - montoAPagar[numRegistros];

            Console.WriteLine("el vuelto es de :" + vuelto[numRegistros]);
            Console.WriteLine($"Registro de paso {numRegistros + 1} guardado exitosamente.");
            

            numRegistros++;

            Console.Write("¿Desea continuar registrando pasos? (s/n): ");
            continuar = Console.ReadLine().ToLower() == "s";
        }
    }

    static double CalcularMontoAPagar(int tipoVehiculo)
    {
        switch (tipoVehiculo)
        {
            case 1:
                return 10.0;
            case 2:
                return 20.0;
            case 3:
                return 30.0;
            case 4:
                return 40.0;
            default:
                throw new Exception("Tipo de vehículo inválido.");
        }
    }

    static void VerRecaudacion()
    {
        Console.WriteLine("Recaudación por Tipo de Vehículo");
        Console.WriteLine("Tipos de Vehículo\tRecaudación");

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine("{0}\t\t\t{1}", i, recaudacion[i]);
        }
    }
    static void ConsultarVehiculosPorPlaca()
    {
        Console.WriteLine("Consulta de Vehículos por Número de Placa");
        Console.Write("Ingrese la placa a buscar: ");
        string placa = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < placas.Length; i++)
        {
            if (placas[i] == placa)
            {
                encontrado = true;
                Console.WriteLine($"Vehículo encontrado en la posición {i} del vector.");
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún vehículo con la placa ingresada.");
        }
    }
    static void ModificarDatosVehiculo()
    {
        Console.WriteLine("Modificar Datos de Vehículo");
        Console.Write("Ingrese la placa del vehículo a modificar: ");
        string placa = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < placas.Length; i++)
        {
            if (placas[i] == placa)
            {
                encontrado = true;
                Console.WriteLine($"Vehículo encontrado en la posición {i} del vector.");
                Console.WriteLine($"Placa: {placas[i]}");
                Console.WriteLine($"Tipo de vehículo: {vehiculos[i]}");
                Console.WriteLine($"Recaudación: {recaudacion[i]}");

                Console.WriteLine("Ingrese los nuevos datos del vehículo:");
                Console.Write("Placa: ");
                placas[i] = Console.ReadLine();
                Console.WriteLine("Tipos de Vehículo:");
                Console.WriteLine("1. Automóvil");
                Console.WriteLine("2. Camioneta");
                Console.WriteLine("3. Camión");
                Console.Write("Seleccione el nuevo tipo de vehículo: ");
                vehiculos[i] = int.Parse(Console.ReadLine());
                recaudacion[i] = tarifas[vehiculos[i]];

                Console.WriteLine("Datos modificados correctamente.");
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún vehículo con la placa ingresada.");
        }
    }
}






