using GestaoEbook.Aplication.Models.ModelsRequest;
using GestaoEbook.Aplication.Models.ModelsResponse;
using GestaoEbooks.Repository;
using GestaoEbooks.Repository.Models.ModelsTableBancoDD;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GestaoEbook.Aplication.Services.EbookCadastroPessoa
{
    public class EbookPessoaService
    {
        private readonly PessoaContext _context;

        public EbookPessoaService(PessoaContext context)
        {
            _context = context;
        }

        public CadastroResponse SalvarDadosCadastrais(CadastroRequest request)
        {
            var conferirCadastro = _context.Usuarios.FirstOrDefault(x => x.email == request.email);
            if (conferirCadastro != null)
            {
                return new CadastroResponse()
                {
                    mensagem = "Usuário com o mesmo e-mail já existe."
                };
            }

            var pessoa = new TabUsuario()
            {
                nome = request.nome,
                email = request.email,
                usuario = request.usuario,
                senha = request.senha,
                role = request.role
            };

            _context.Usuarios.Add(pessoa);
            _context.SaveChanges();

            return new CadastroResponse()
            {
                nome = pessoa.nome,
                usuario = pessoa.usuario,
                mensagem = "Usuário cadastrado com sucesso.",
            };
        }

        public TabUsuario ObterUsuario(string email)  //CRUD - READ     LEITURA
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(x => x.email == email); //va na tabela usuario e procura esses id
                return usuario;
            }
            catch (Exception ex)
            {
                return null;   //o null eu tratei na Service sobre bad Request
            }
        }
    }
}
