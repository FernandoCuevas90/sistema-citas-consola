using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCitasConsole
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public string Correo { get; set; }

        public Cliente(int id, string nombre, int edad, string correo)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Edad = edad;
            this.Correo = correo;
        }
    }
}
