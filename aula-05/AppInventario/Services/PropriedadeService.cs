using AppInventario.Context;
using AppInventario.Models;
using Microsoft.EntityFrameworkCore;

namespace AppInventario.Services
{
    public class PropriedadeService
    {
        private readonly ContextDB _context;

        public PropriedadeService(ContextDB con)
        {
            _context = con;
        }

        public async Task Add(List<Propriedade> bens)
        {
            if (bens != null)
            {
                await _context.Propriedades.AddRangeAsync(bens);
            }
        }

        public async Task Add(Propriedade bens)
        {
            if (bens != null)
            {
                await _context.Propriedades.AddAsync(bens);
            }
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        //Com Include, o nome do dono da propriedade também será carregado
        public async Task<List<Propriedade>> Propriedades()
        {
            var p = await _context.Propriedades.Include(p => p.Pessoa).ToListAsync();
            return p;
        }
    }
}
