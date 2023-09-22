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

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var resultado = _Organizador.Tarefas.Find(id);
            return Ok(resultado);

        }
        [HttpPut("{id}")]
        public IActionResult Editar(Tarefa t)
        {
            var tarefa = _Organizador.Tarefas.Find(t.Id);

            tarefa.Titulo = t.Titulo;
            tarefa.Descricao = t.Descricao;
            tarefa.Data = t.Data;
            tarefa.Status = t.Status;

            _Organizador.Tarefas.Update(tarefa);
            _Organizador.SaveChanges();
            return Ok(t);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var resultado = _Organizador.Tarefas.Find(id);
            _Organizador.Tarefas.Remove(resultado);

            return Ok(resultado);
        }



        [HttpGet("ObterTodos")]
        public IActionResult RetornarTabela()
        {
            var resultado = _Organizador.Tarefas;
            return Ok(resultado);
        }
        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo)
        {
            var resultado = _Organizador.Tarefas.Where(tarefa => tarefa.Titulo == titulo).ToList();
            return Ok(resultado);
        }
        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data)
        {
            var resultado = _Organizador.Tarefas.Where(tarefa => tarefa.Data == data).ToList();
            return Ok(resultado);
        }
        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(EnumStatusTarefa status)
        {
            var resultado = _Organizador.Tarefas.Where(tarefa => tarefa.Status == status).ToList();
            return Ok(resultado);
        }


        [HttpPost]
        public IActionResult Criar(Tarefa t)
        {
            _Organizador.Add(t);
            _Organizador.SaveChanges();
            return Ok(t);
        }
    }
}