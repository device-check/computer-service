using application.Interfaces;
using domain.Entities;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Repositories
{
    public class ComputerTypeRepository : IComputerTypeRepository
    {
        private readonly ComputerDbContext _context;

        public ComputerTypeRepository(ComputerDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            return await _context.ComputerType.CountAsync();
        }

        public async Task<List<ComputerType>> GetAsync(int page, int pageSize)
        {
            var computerTypes = await _context.ComputerType
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return computerTypes;
        }
    }
}
