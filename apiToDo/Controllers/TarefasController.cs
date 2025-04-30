using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly Tarefas _tarefas;

        public TarefasController()
        {
            _tarefas = new Tarefas();
        }

        /// <summary>
        /// Retorna todas as tarefas
        /// </summary>
        [HttpGet]
        [Authorize]
        public ActionResult<List<TarefaDTO>> Get()
        {
            try
            {
                var listaTarefas = _tarefas.lstTarefas();
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Retorna uma tarefa específica pelo ID
        /// </summary>
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<TarefaDTO> GetById(int id)
        {
            try
            {
                var tarefa = _tarefas.ObterTarefaPorId(id);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Cria uma nova tarefa
        /// </summary>
        [HttpPost]
        [Authorize]
        public ActionResult<List<TarefaDTO>> Post([FromBody] TarefaDTO tarefa)
        {
            try
            {
                _tarefas.InserirTarefa(tarefa);
                var listaTarefas = _tarefas.lstTarefas();
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Atualiza uma tarefa existente
        /// </summary>
        [HttpPut]
        [Authorize]
        public ActionResult<List<TarefaDTO>> Put([FromBody] TarefaDTO tarefa)
        {
            try
            {
                _tarefas.AtualizarTarefa(tarefa);
                var listaTarefas = _tarefas.lstTarefas();
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Remove uma tarefa
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<List<TarefaDTO>> Delete(int id)
        {
            try
            {
                _tarefas.DeletarTarefa(id);
                var listaTarefas = _tarefas.lstTarefas();
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
