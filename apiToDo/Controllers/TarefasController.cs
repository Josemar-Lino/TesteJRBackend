using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as operações CRUD de tarefas
    /// Implementa os padrões REST para operações com recursos de tarefas
    /// </summary>
    [ApiController]
    [Route("api/[controller]")] // Define o prefixo da rota como 'api/tarefas'
    public class TarefasController : ControllerBase
    {
        // Instância da classe Tarefas para manipulação dos dados
        private readonly Tarefas _tarefas;

        /// <summary>
        /// Construtor da classe TarefasController
        /// Inicializa a instância da classe Tarefas
        /// </summary>
        public TarefasController()
        {
            _tarefas = new Tarefas();
        }

        /// <summary>
        /// Endpoint para listar todas as tarefas
        /// Método HTTP: GET
        /// Rota: api/tarefas
        /// </summary>
        /// <returns>Lista de todas as tarefas cadastradas</returns>
        [HttpGet]
        public ActionResult<List<TarefaDTO>> Get()
        {
            try
            {
                // Obtém a lista de todas as tarefas
                var listaTarefas = _tarefas.lstTarefas();
                // Retorna a lista com status 200 (OK)
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna status 400 (Bad Request) com a mensagem de erro
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para obter uma tarefa específica pelo ID
        /// Método HTTP: GET
        /// Rota: api/tarefas/{id}
        /// </summary>
        /// <param name="id">ID da tarefa a ser recuperada</param>
        /// <returns>Tarefa correspondente ao ID informado</returns>
        [HttpGet("{id}")]
        public ActionResult<TarefaDTO> GetById(int id)
        {
            try
            {
                // Busca a tarefa pelo ID
                var tarefa = _tarefas.ObterTarefaPorId(id);
                // Retorna a tarefa encontrada com status 200 (OK)
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna status 400 (Bad Request) com a mensagem de erro
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para criar uma nova tarefa
        /// Método HTTP: POST
        /// Rota: api/tarefas
        /// </summary>
        /// <param name="tarefa">Objeto TarefaDTO contendo os dados da nova tarefa</param>
        /// <returns>Lista atualizada de todas as tarefas</returns>
        [HttpPost]
        public ActionResult<List<TarefaDTO>> Post([FromBody] TarefaDTO tarefa)
        {
            try
            {
                // Insere a nova tarefa
                _tarefas.InserirTarefa(tarefa);
                // Obtém a lista atualizada de tarefas
                var listaTarefas = _tarefas.lstTarefas();
                // Retorna a lista atualizada com status 200 (OK)
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna status 400 (Bad Request) com a mensagem de erro
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para atualizar uma tarefa existente
        /// Método HTTP: PUT
        /// Rota: api/tarefas
        /// </summary>
        /// <param name="tarefa">Objeto TarefaDTO contendo os dados atualizados da tarefa</param>
        /// <returns>Lista atualizada de todas as tarefas</returns>
        [HttpPut]
        public ActionResult<List<TarefaDTO>> Put([FromBody] TarefaDTO tarefa)
        {
            try
            {
                // Atualiza a tarefa existente
                _tarefas.AtualizarTarefa(tarefa);
                // Obtém a lista atualizada de tarefas
                var listaTarefas = _tarefas.lstTarefas();
                // Retorna a lista atualizada com status 200 (OK)
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna status 400 (Bad Request) com a mensagem de erro
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Endpoint para excluir uma tarefa
        /// Método HTTP: DELETE
        /// Rota: api/tarefas/{id}
        /// </summary>
        /// <param name="id">ID da tarefa a ser excluída</param>
        /// <returns>Lista atualizada de todas as tarefas</returns>
        [HttpDelete("{id}")]
        public ActionResult<List<TarefaDTO>> Delete(int id)
        {
            try
            {
                // Remove a tarefa pelo ID
                _tarefas.DeletarTarefa(id);
                // Obtém a lista atualizada de tarefas
                var listaTarefas = _tarefas.lstTarefas();
                // Retorna a lista atualizada com status 200 (OK)
                return Ok(listaTarefas);
            }
            catch (Exception ex)
            {
                // Em caso de erro, retorna status 400 (Bad Request) com a mensagem de erro
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
