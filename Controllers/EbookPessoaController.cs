using GestaoEbook.Aplication.Models.ModelsRequest;
using GestaoEbook.Aplication.Models.ModelsResponse;
using GestaoEbook.Aplication.Services;
using GestaoEbook.Aplication.Services.EbookCadastroPessoa;
using GestaoEbooks.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GestaoEbook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class bookController : ControllerBase
    {
        private readonly PessoaContext _context;

        public bookController(PessoaContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("CadastroUsuario")]
        public CadastroResponse SalvarDadosCadastrais([FromBody] CadastroRequest request)
        {
            try
            {
                var pessoaService = new EbookPessoaService(_context);
                var usuario = pessoaService.SalvarDadosCadastrais(request);
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpGet]
        [Route("ObterUsuario/{email}")]
         public IActionResult ObterUsuario(string email)
        {
            var usuarioService = new EbookPessoaService(_context);
            var usuario = usuarioService.ObterUsuario(email);
            if (usuario == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(usuario);
            }
        }
    }
}
