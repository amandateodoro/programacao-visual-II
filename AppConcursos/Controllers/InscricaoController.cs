using AppConcursos.Contexto;
using AppConcursos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppConcursos.Controllers
{
    public class InscricaoController : Controller
    {
        private readonly ContextoBD _context;

        public InscricaoController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Inscricao>> ListaInscricoes()
        {
            var inscricoes = await _context.Inscricoes.Include(x => x.Cargo).Include(x => x.Candidato).ToListAsync();
            return inscricoes;
        }

        public async Task Add(Inscricao inscricao)
        {
            await _context.Inscricoes.AddAsync(inscricao);
        } 

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

		public async Task AtualizarNotas(Inscricao inscricao)
		{
			var existente = await _context.Inscricoes
				.Include(i => i.Candidato)
				.Include(i => i.Cargo)
				.FirstOrDefaultAsync(i => i.Id == inscricao.Id);

			if (existente != null)
			{
				existente.NotaConhecimentosEspecificos = inscricao.NotaConhecimentosEspecificos;
				existente.NotaConhecimentosGerais = inscricao.NotaConhecimentosGerais;

				_context.Inscricoes.Update(existente);
			}
		}

	}
}
