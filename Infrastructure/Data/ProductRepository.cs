using System;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class ProductRepository : IProductRepository
	{
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
		{
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProducstAsync()
            => await _context.Products.ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id)
            => await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
    }
}

