using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Emit;
using System.Text;

namespace SistemaCitasConsole
{
    public class CitaService
    {
        public static Cita CrearCita()
        {
            Console.WriteLine("Número de identificador del paciente: ");
            int nume = int.Parse(Console.ReadLine());
            Console.WriteLine("Nombre Paciente: ");
            string nombre = Console.ReadLine();

            int numero;
            Random random = new Random();
            //Generar primera fecha aleatoria
            numero = random.Next(1, 30);
            DateTime fecha = DateTime.Now.AddDays(numero);
            //Validar que no sea fin de semana
            while (fecha.DayOfWeek == DayOfWeek.Saturday || fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                numero = random.Next(1, 30);
                fecha = DateTime.Now.AddDays(numero);
            }

            //Generar hora aleatoria (horario laboral)
            int horaRandom = random.Next(8, 18);
            string hora = $"{horaRandom}:00";
            //En este caso como el método es static
            //es decir que se puede usar el método sin crear un objeto
            //CitaService cita = new citaService();

            bool continuar = true;

            do
            {
                string tipoEstudio = "";


                Console.WriteLine("Seleccione el tipo de estudio a realizar");
                Console.WriteLine("1. Rayos X");
                Console.WriteLine("2. Sangre");
                Console.WriteLine("3. Ultrasonido");
                int option = int.Parse(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        tipoEstudio = "Rayos X";
                        Console.WriteLine("Elegiste Rayos X");
                        break;
                    case 2:
                        tipoEstudio = "Sangre";
                        Console.WriteLine("Elegiste Sangre");
                        break;
                    case 3:
                        tipoEstudio = "Ultrasonido";
                        Console.WriteLine("Elegiste Ultrasonido");
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }

                if (tipoEstudio == "")
                {
                    string opti;
                    Console.WriteLine("No se seleccionó un tipo de estudio válido");
                    Console.WriteLine("Desea elegir de nuevo el estudio (S/N)");
                    opti = Console.ReadLine();

                    if (opti == "N")
                    {
                        return null; //Cancela la cita
                    }
                }
                else
                {
                    Cita nueva = new Cita(nume, nombre, fecha, hora, tipoEstudio);
                    return nueva; //Termina correctamente y agendada la cita
                }
            }
            while (continuar);

            return null;
        }

        public static void mostrarCitas(List<Cita> citas)
        {

            if (citas.Count == 0)
            {
                Console.WriteLine("No hay citas agregadas");
            }
            else
            {
                foreach (var cita in citas)
                {
                    Console.WriteLine($"ID: {cita.Id} - Cliente: {cita.NombreCliente} - Fecha: {cita.Fecha.ToShortDateString()} - Hora: {cita.Hora} - Estudio: {cita.tipoEstudio}");
                }
            }
        }

        public static List<Cliente> CrearCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            char opcions;
            do
            {
                Console.WriteLine("Ingresa el ID del cliente: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa el nombre del cliente: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingresa la edad del cliente: ");
                int edad = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingresa el correo del cliente: ");
                string correo = Console.ReadLine();

                Cliente nuevo = new Cliente(id, nombre, edad, correo);
                clientes.Add(nuevo);

                Console.WriteLine("¿Desea crear otro cliente? (s/n)");
                opcions = char.Parse(Console.ReadLine().ToLower());

            } while (opcions == 's');
            return clientes;
        }

        public static void BuscarCliente(List<Cliente> clientes)
        {
            char opcion;

            do
            {
                bool encontrado = false;

                Console.WriteLine("Ingresa el ID del cliente: ");
                int idBuscado = int.Parse(Console.ReadLine());

                Console.WriteLine($"Clientes en lista: {clientes.Count}");

                foreach (var cliente in clientes)
                {
                    if (cliente.Id == idBuscado)
                    {
                        Console.WriteLine("Cliente encontrado: ");
                        Console.WriteLine($"ID: {cliente.Id}");
                        Console.WriteLine($"Nombre: {cliente.Nombre}");
                        Console.WriteLine($"Edad: {cliente.Edad}");
                        Console.WriteLine($"Correo: {cliente.Correo}");

                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    Console.WriteLine("Cliente no encontrado");
                }

                string input;

                do
                {
                  Console.WriteLine("¿Desea buscar otro cliente?(S/N)");
                    input = Console.ReadLine().ToLower();

                } while (string.IsNullOrEmpty(input) || (input[0] != 's' && input[0] != 'n'));

                opcion = input[0];

            } while (opcion == 's');
        }

        public static void modificarCita(List<Cita> citas)
        {
            char opcionsita;
            do
            {
                int idBuscado;
                
                Console.WriteLine("Ingresa el ID del paciente: ");
                idBuscado = int.Parse(Console.ReadLine());

                bool encontrado = false;

                foreach (var cita in citas)
                {
                    if (cita.Id == idBuscado)
                    {
                        encontrado = true;

                        int opc = 0;
                        Console.WriteLine("Qué desea modificar?: \n");
                        Console.WriteLine("1.Nombre\n");
                        Console.WriteLine("2.Tipo de Estudio\n");
                        opc = int.Parse(Console.ReadLine());

                        switch (opc)
                        {
                            case 1:
                                Console.WriteLine("Ingresa el nuevo nombre: ");
                                string nombreNuevo = Console.ReadLine();
                                cita.NombreCliente = nombreNuevo;
                                Console.WriteLine("Nombre modificado correctamente");
                                break;
                            case 2:
                                char opciones;
                                do
                                {
                                    int opci = 0;

                                    Console.WriteLine("Selecciona el nuevo estudio: ");
                                    Console.WriteLine("1.Rayos X\n");
                                    Console.WriteLine("2.Sangre\n");
                                    Console.WriteLine("3.Ultrasonido\n");
                                    opci = int.Parse(Console.ReadLine());
                                    switch (opci)
                                    {
                                        case 1:
                                            cita.tipoEstudio = "Rayos X";
                                            Console.WriteLine("Estudio modificado correctamente");
                                            break;
                                        case 2:
                                            cita.tipoEstudio = "Sangre";
                                            Console.WriteLine("Estudio modificado correctamente");
                                            break;
                                        case 3:
                                            cita.tipoEstudio = "Ultrasonido";
                                            Console.WriteLine("Estudio modificado correctamente");
                                            break;
                                        default:
                                            Console.WriteLine("Opción inválida");
                                            break;
                                    }
                                    Console.WriteLine("Desea volver a intentarlo? (S/N)");
                                    opciones = char.Parse(Console.ReadLine().ToLower());
                                } while (opciones == 's');
                                break;
                            default:
                                Console.WriteLine("Opción inválida");
                                break;
                        }

                        Console.WriteLine($"ID: {cita.Id} - Cliente: {cita.NombreCliente} - Fecha: {cita.Fecha.ToShortDateString()} - Hora: {cita.Hora} - Estudio: {cita.tipoEstudio}");

                        break;
                    }

                }
                if (!encontrado)
                {
                    Console.WriteLine("No se encontró la cita");
                }
                Console.WriteLine("Desea buscar otra cita? (S/N)");
                opcionsita = char.Parse(Console.ReadLine().ToLower());
            }
            while(opcionsita == 's');
            }
        public static void eliminarCita(List<Cita> citas)
        {
            char opt;
            do
            {
                Cita citaAEliminar = null;
                
                Console.WriteLine("Ingresa el ID a eliminar");
                int idBusca = int.Parse(Console.ReadLine());

                foreach (var cita in citas)
                {
                    if (cita.Id == idBusca)
                    {
                        citaAEliminar = cita;
                        break;
                    }
                }
                if (citaAEliminar != null)
                {
                    citas.Remove(citaAEliminar);
                    Console.WriteLine("Cita eliminada correctamente");
                }
                else
                {
                    Console.WriteLine("Cita no encontrada");
                }
                Console.WriteLine("Desea hacer otra búsqueda? (S/N)");
                opt = char.Parse(Console.ReadLine().ToLower());

            } while (opt == 's');
        }
    }
    }

    


