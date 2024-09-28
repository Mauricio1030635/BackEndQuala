using Microsoft.EntityFrameworkCore;
using Quala.Core.Models;
using Quala.Core.Repository;
using Quala.Data;
using Quala.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quala.Services.Service
{   

    public class EntidadService : GenericService<NuevaEntidad>, IEntidadService
    {
        private readonly AppDbContext _context;

        public EntidadService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NuevaEntidad>> GetAllEntidadAsync()
        {
            return await _context.NuevaEntidades
                .Include(e => e.NuevaMoneda) 
                .ToListAsync();
        }


        public async Task<NuevaEntidad> GetEntidadAsync(int id)
        {
            return await _context.NuevaEntidades
                .Include(e => e.NuevaMoneda)
                .SingleOrDefaultAsync(data => data.Codigo == id); 
        }

    }

}
