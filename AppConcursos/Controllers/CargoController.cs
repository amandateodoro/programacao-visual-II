using AppConcursos.Contexto;
using AppConcursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppConcursos.Controllers
{
    public class CargoController : Controller
    {
        private readonly ContextoBD _context;

        public CargoController(ContextoBD context)
        {
            _context = context;
        }

        // Lista todos os cargos
        public async Task<List<Cargo>> ListaCargos()
        {
            var cargos = await _context.Cargos.Include(x => x.Inscricoes).ToListAsync();
            return cargos;
        }

        // Adiciona um novo cargo
        public async Task Add(Cargo cargo)
        {
            if (cargo == null)
            {
                throw new ArgumentNullException(nameof(cargo), "O cargo não pode ser nulo");
            }

            await _context.Cargos.AddAsync(cargo);
        }

        // Salva as alterações no banco de dados
        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
