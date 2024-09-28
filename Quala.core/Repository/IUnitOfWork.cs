using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quala.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEntidadService Entidades { get; }
        IMonedaService Monedas { get; }
        Task<int> CompleteAsync();
    }
}
