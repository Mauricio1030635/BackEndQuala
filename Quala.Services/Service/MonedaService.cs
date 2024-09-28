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

    public class MonedaService : GenericService<NuevaMoneda>, IMonedaService
    {
        private readonly AppDbContext _context;

        public MonedaService(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
