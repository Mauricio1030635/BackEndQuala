using Quala.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quala.Core.Repository
{    

    public interface IEntidadService : IGenericService<NuevaEntidad>
    {
        Task<IEnumerable<NuevaEntidad>> GetAllEntidadAsync();
        Task<NuevaEntidad> GetEntidadAsync(int id);
    }
}
