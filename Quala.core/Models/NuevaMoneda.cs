using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quala.Core.Models
{
    public class NuevaMoneda
    {
        public int IdMoneda { get; set; }
        public string CodigoMoneda { get; set; }
        public string NombreMoneda { get; set; }
        public ICollection<NuevaEntidad> NuevaEntidades { get; set; }
    }
}
