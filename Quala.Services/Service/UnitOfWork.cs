using Quala.Core.Repository;
using Quala.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quala.Services.Service
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IEntidadService Entidades { get; private set; }
        public IMonedaService Monedas { get; private set; }

        public UnitOfWork(AppDbContext context, IEntidadService entidadService, IMonedaService monedaService)
        {
            _context = context;
            Entidades = entidadService;
            Monedas = monedaService;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
