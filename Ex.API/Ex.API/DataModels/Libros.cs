using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex.API.DataModels
{
    public class Libros
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
