using GestaoEbook;
using Microsoft.AspNetCore.Mvc;

namespace GestaoLivros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OlaMundoController : ControllerBase
    {
    

        [HttpPost]
        public PessoaResponse InformacoesPessoa([FromBody] LivrosRequest request)

        { 
          var anoAtual = DateTime.Now.Year;
          var idade = anoAtual - request.DataNascimento.Year; 
            

          var resposta = new PessoaResponse();
          resposta.Idade = idade;

            return resposta;
       }
    }
   
}
