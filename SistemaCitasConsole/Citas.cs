using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SistemaCitasConsole
{
    public class Cita
    {   //Atributos o Propiedades de la clase Cita
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string tipoEstudio { get; set; }

        /*Constructor. Es un método especial denteo de 
        una clase que se ejecuta automáticamente al crar 
        una instancia (objeto) de esta. Sirve principlamente
        para inicializar los daros del objeto, asignar valores
        predeterminados y asefurar que el objeto tenga un estado
        válido y consistente desde su creación.
        */

        public Cita(int Id, string NombreCliente, DateTime Fecha, string Hora, string tipoEstudio)
        {
            this.Id = Id;
            this.NombreCliente = NombreCliente;
            this.Fecha = Fecha;
            this.Hora = Hora;
            this.tipoEstudio = tipoEstudio;

        }
    } 
}
