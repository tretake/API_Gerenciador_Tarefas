using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Gerenciador_Tarefas.Context;
using API_Gerenciador_Tarefas.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Gerenciador_Tarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly OrganizadorContext _Organizador;

        public TarefaController(OrganizadorContext Banco)
        {
            _Organizador = Banco;
        }

        [HttpPost("CriarTarefa")]
        public IActionResult Criar(Tarefa t)
        {
            _Organizador.Add(t);
            _Organizador.SaveChanges();
            return Ok(t);
        }

        [HttpGet("buscarTarefa/{id}")]
        public IActionResult Teste(int id)
        {
            var resultado = _Organizador.Tarefas.Find(id);
            return Ok(resultado);
        }

        [HttpGet("RetornarTodos")]
        public IActionResult RetornarTabela()
        {
            var resultado = _Organizador.Tarefas;
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var resultado = _Organizador.Tarefas.Find(id);
            _Organizador.Tarefas.Remove(resultado);

            return Ok(resultado);
        }

    }
}