using AppConcursos.Contexto;
using AppConcursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppConcursos.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly ContextoBD _context;

        public CandidatoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Candidato>> ListaCandidatos()
        {
            var candidatos = await _context.Candidatos.Include(x => x.Inscricoes).ToListAsync();
            return candidatos;
        }
        public async Task Add(Candidato candidato)
        {
            await _context.Candidatos.AddAsync(candidato);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
