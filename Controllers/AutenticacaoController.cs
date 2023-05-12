using GestaoEbook.Aplication.Autenticacao;
using GestaoEbook.Aplication.Models.ModelsRequest;
using GestaoEbooks.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEbook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticationsController : ControllerBase
    {
        private readonly PessoaContext _context;
        public AutenticationsController(PessoaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AutenticacaoRequest request) //Nosso método junto a classe AutenticacaoRequest
        {
            var autenticacaoService = new AutenticacaoServices(_context);
            var resposta = autenticacaoService.Autenticar(request);

            if (resposta == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(resposta);
            }
        }

    }
}


