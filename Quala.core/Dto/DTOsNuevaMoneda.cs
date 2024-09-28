using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quala.Core.Dto
{

    public class NuevaMonedaCreateDto
    {
        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
    }


    public class NuevaMonedaUpdateDto
    {
        public int IdMoneda { get; set; } 
        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
    }


    public class NuevaMonedaDto
    {
        public int IdMoneda { get; set; }
        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
    }
}
