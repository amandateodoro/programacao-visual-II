
using AppPessoa.Contexto;
using AppPessoa.Models;

namespace AppPessoa.Services
{
    public class PessoaServices
    {
        private readonly ContextBD _context;

        public PessoaServices(ContextBD context)
        {
            _context = context;
        }

        public async Task<List<Pessoa>>? Pessoas()
        {
            var pessoas = _context.Pessoas?.ToList();

            return pessoas;
        }
        public async Task<List<Pessoa>>? PessoasOrdernadas()
        {
            var list = _context.Pessoas.OrderBy(p => p.Nome).ToList();

            return list;
        }

        public async Task<Pessoa>? GetPessoa(int id)
        {
            var pessoa = _context.Pessoas?.Where(p => p.Id == id).FirstOrDefault();

            return pessoa;
        }

        public async Task<Pessoa>? GetPessoa(string cpf)
        {
            var pessoa = _context.Pessoas?.Where(p => p.Cpf == cpf).FirstOrDefault();

            return pessoa;
        }

        public async Task? Add(Pessoa pessoa)
        {
            _context.Pessoas?.Add(pessoa);
            this.Pessoas();
            return;
        }

    }
}