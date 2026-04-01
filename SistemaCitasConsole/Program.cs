using SistemaCitasConsole;

int opcion;

List<Cita> citas = new List<Cita>();
List<Cliente> clientes = new List<Cliente>();

do
{
    do
    {
        Console.WriteLine("**********  MENÚ PARA AGENDAR CITA  **********\n");

        Console.WriteLine("1.Crear Cita");
        Console.WriteLine("2.Mostrar Cita");
        Console.WriteLine("3.Crear Cliente");
        Console.WriteLine("4.Buscar Cliente por ID");
        Console.WriteLine("5.Modificar Cita");
        Console.WriteLine("6.Eliminar Cita");
        Console.WriteLine("7.Salir\n");

        Console.Write("Elige una opción(1-7):");
        opcion = int.Parse(Console.ReadLine());
        Console.WriteLine("\n");

        if (opcion < 1 || opcion > 7)
        {
            Console.WriteLine("Opción inválida, intente de nuevo.\n");
        }
    } while (opcion < 1 || opcion > 7);


            string respuesta = "";

    switch (opcion)
    {
        case 1:
            string continuar;
            do {
                Cita nueva = CitaService.CrearCita();

                if (nueva != null)
                {
                    citas.Add(nueva);
                    Console.WriteLine("Cita creada correctamente.\n");
                }
                else
                {
                    Console.WriteLine("Operación cancelada");
                }
                Console.WriteLine("¿Desea agendar otr cita? (S/N)");
                continuar = Console.ReadLine().ToUpper();

            } while (continuar == "S");

                break;

        case 2:
            CitaService.mostrarCitas(citas);

            if (citas.Count == 0)
            {
                do
                {

                    Console.WriteLine("¿Desea agregar una cita? (S/N)");
                    respuesta = Console.ReadLine();
                    respuesta = respuesta.ToUpper();
                } while (respuesta != "S" && respuesta != "N");

                Cita nuewa = CitaService.CrearCita();

                if (nuewa != null)
                {
                    citas.Add(nuewa);
                    Console.WriteLine("Cita creada correctamente");

                }
                else
                {
                    Console.WriteLine("Operación cancelada");
                }
            }
            break;
        case 3:
            List<Cliente> nuevosClientes = CitaService.CrearCliente();
            clientes.AddRange(nuevosClientes);
            Console.WriteLine($"Clientes agregados:");
            foreach(var c in clientes)
            {
                Console.WriteLine($"ID: {c.Id} - {c.Nombre}");
            }
            break;
        case 4:
            CitaService.BuscarCliente(clientes);
            break;
        case 5:
            CitaService.modificarCita(citas);
            break;
        case 6:
            CitaService.eliminarCita(citas);
            break;
        case 7:
            Console.WriteLine("Saliendo del sistema...");
            break;
        default:
            Console.WriteLine("Opción inválida");
            break;

    }

} while (opcion != 7);
