using GestaoEbook.Aplication.Models.ModelsResponse;
using GestaoEbook.Aplication.Services.EbookCadastroPessoa;
using GestaoEbook.Aplication.Services.EbookCadastroUsuario;
using GestaoEbooks.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestaoEbook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly PessoaContext _context;

        public BookController(PessoaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ObterLivros")]

        public IActionResult ObterLivros()
        {
            var obterLivrosService = new LivrosCadastro(_context);
            var livros = obterLivrosService.ObterLivros();
            if (livros == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(livros);
            }
        }
        [HttpPost]
        [Route("InserirLivros")]
        [Authorize(Roles = "admin,dev")]
        public IActionResult InserirLivros( [FromBody] LivrosRequest request)
        {
            var inserirLivrosService = new LivrosCadastro(_context);
            //  var usuarioID = Convert.ToInt32((((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "usuarioId")?.Value));

            var indentidade = (ClaimsIdentity)HttpContext.User.Identity; 
            var usuarioID = indentidade.FindFirst("usuarioId").Value;
            var sucesso = inserirLivrosService.InserirLivros(Convert.ToInt32(usuarioID), request);

            if (sucesso != null)
            {
                return Ok(sucesso);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("AtualizarLivros/{id}")]
        [Authorize(Roles = "admin,dev")]
        public IActionResult AtualizarLivros([FromRoute] int id, [FromBody] LivrosRequest request)  
        { 
            var usuario = Convert.ToInt32((((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "usuarioId")?.Value));
            var atualizarLivrosService = new LivrosCadastro(_context);
            var sucesso = atualizarLivrosService.AtualizarLivros(id, request);
            var livros = atualizarLivrosService.ObterLivros();
            
            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("DeletarLivros/{id}")]
        [Authorize]
        [Authorize(Roles = "admin")]
        public IActionResult RemoverLivros([FromRoute] int id)
        {
            var removerLivrosService = new LivrosCadastro(_context);
            var sucesso = removerLivrosService.RemoverLivros(id);
            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}