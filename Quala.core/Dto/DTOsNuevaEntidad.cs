using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quala.Core.Dto
{
    public class NuevaEntidadCreateDto
    {
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public int MonedaId { get; set; }
    }

    public class NuevaEntidadUpdateDto
    {
        public int Codigo { get; set; } 
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public int MonedaId { get; set; }
    }

    public class NuevaEntidadDto
    {
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public string Identificacion { get; set; }
        public string NombreMoneda { get; set; } 
    }



}
