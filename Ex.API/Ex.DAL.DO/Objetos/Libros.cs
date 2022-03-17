using System;
using System.Collections.Generic;
using System.Text;

namespace Ex.DAL.DO.Objetos
{
   public partial class Libros
    {
        public Libros()
        {

        }

        public int id { get; set; }

        public string Titulo { get; set; }

        public int AutorId { get; set; }

        public DateTime Creacion { get; set; }

        public byte[] Activo { get; set; }

        public DateTime Desactivacion { get; set; }

        public string DesactivadoPor { get; set; }

        public string CreadoPor { get; set; }

    }
}
