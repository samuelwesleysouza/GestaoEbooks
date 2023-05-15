using GestaoEbook.Aplication.Models.ModelsResponse;
using GestaoEbooks.Repository;
using GestaoEbooks.Repository.Models.ModelsTableBancoDD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GestaoEbook.Aplication.Services.EbookCadastroUsuario
{
    public class LivrosCadastro
    {
        private readonly PessoaContext _context;

        public LivrosCadastro(PessoaContext context)
        {
            _context = context;
        }

        public LivrosResponse InserirLivros(int idUsuario, LivrosRequest request)
        {
            try
            {
                var conferirCadastro = _context.tabEbooks.FirstOrDefault(x => x.livros.Equals(request.livros));

                if (conferirCadastro != null)
                {
                    return new LivrosResponse()
                    {
                        livros = null,
                        mensagem = "Livro já cadastrado."
                    };
                }

                var livro = new TabEbook()
                {
                    idUsuario = idUsuario,
                    livros = request.livros,
                    DATACAD= DateTime.Now
                };

                _context.tabEbooks.Add(livro);
                _context.SaveChanges();

                return new LivrosResponse()
                {
                    livros = livro.livros,
                    mensagem = "Livro cadastrado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new LivrosResponse()
                {
                    livros = null,
                    mensagem = "Erro ao cadastrar o livro."
                };
            }
        }

        public List<TabEbook> ObterLivros()
        {
            try
            {
                var livros = _context.tabEbooks.OrderBy(x => x.livros).ToList();
                return livros;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool AtualizarLivros(int id, LivrosRequest request)
        {
            try
            {
                if (!_context.tabEbooks.Any(x => x.id == id))
                    return false;
                var livrosDb = _context.tabEbooks.FirstOrDefault(x => x.id == id);
                if (livrosDb == null)
                    return false;
                livrosDb.livros = request.livros;
                _context.tabEbooks.Update(livrosDb);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RemoverLivros(int id)
        {
            try
            {
                var livrosDb = _context.tabEbooks.FirstOrDefault(x => x.id == id);
                if (livrosDb == null)
                    return false;

                _context.tabEbooks.Remove(livrosDb);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
