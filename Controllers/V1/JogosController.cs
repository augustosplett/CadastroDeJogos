using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using CadastroDeJogos.InputModel;
using CadastroDeJogos.ViewModels;
using CadastroDeJogos.Services;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using CadastroDeJogos.Exceptions;

namespace CadastroDeJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;
        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1,[FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);

            if(jogos.Count() == 0)
            {
                return NoContent();
            }

            return Ok(jogos);
        }
        
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);

            if(jogo == null){
                return NoContent();
            }
            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel JogoInputModel)
        {
            try{
                var jogo = await _jogoService.Inserir(JogoInputModel);
                return Ok(jogo);

            }
            catch(JogoJaCadastradoException ex)
            {
                return UnprocessableEntity("Ja existe um jogo cadastrado com esse noma para essa produtora");
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo,[FromBody] JogoInputModel jogo)
        {
            try{
                await _jogoService.Atualizar(idJogo, jogo);
                return Ok();
            }
            catch(JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");
            }
        }   

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo,[FromRoute] double preco)
        {
            try{
                await _jogoService.Atualizar(idJogo, preco);
                return Ok();
            }
            catch(JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");   
            }
        }

        [HttpDelete]
        public async Task<ActionResult> ApagarJogo([FromRoute]Guid idJogo)
        {
            try{

                await _jogoService.Remover(idJogo);
                return Ok();
            }
            catch(JogoNaoCadastradoException ex)
            {
                return NotFound("Não existe este jogo");   
            }
        }
    }
}